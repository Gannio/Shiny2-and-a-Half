using System.IO;
using System.Text;

namespace System.Ini
{
    /// <summary>
    /// Represents a reader that provides forward-only access to INI data.
    /// </summary>
    public class IniReader : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of IniReader.
        /// </summary>
        /// <param name="tr"></param>
        public IniReader(TextReader tr)
        {
            if (tr == null)
                throw new ArgumentNullException("tr");

            this.reader = tr;

            this.SyntaxDefinition = new IniSyntaxDefinition();
        }
        public IniReader(Stream strm)
            : this(new StreamReader(strm))
        { }
        public IniReader(string fileName)
            : this(new FileStream(fileName, FileMode.Open))
        { }

        protected TextReader reader;

        #region Properties
        /// <summary>
        /// Gets the current line number offset.
        /// </summary>
        public int CurrentLineNumber { get; protected set; }

        /// <summary>
        /// Gets the current line position offset.
        /// </summary>
        public int CurrentLinePosition { get; protected set; }

        /// <summary>
        /// Gets the content of the current line.
        /// </summary>
        public string CurrentLineText { get; protected set; }

        /// <summary>
        /// Gets or sets syntax definitions used during document loading.
        /// </summary>
        public IniSyntaxDefinition SyntaxDefinition { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to ignore comments.
        /// </summary>
        public bool IgnoreComments { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to clear the content of the IniDocument before reading.
        /// </summary>
        public bool ClearDocument { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Reads the whole document.
        /// </summary>
        public void ReadDocument(IniDocument document)
        {
            if (document == null)
                throw new ArgumentNullException("document");

            // Tartalom törlése
            if (this.ClearDocument)
            {
                document.Sections.Clear();
                document.CommentLines.Clear();
            }

            // Nullázás
            this.CurrentLineNumber = this.CurrentLinePosition = 0;
            this.CurrentLineText = String.Empty;

            IniSection currentSection = null;

            while (true)
            {
                // Újabb sor beolvasása
                this.CurrentLineText = reader.ReadLine();

                // Megszakítás
                if (this.CurrentLineText == null)
                    break;
                
                this.CurrentLineNumber++;
                this.CurrentLinePosition = 0;

                string trimmedLine = this.CurrentLineText.TrimStart();

                // Üres sor
                if (trimmedLine.Length == 0)
                    continue;

                // Szekció beolvasása
                if (trimmedLine.StartsWith("["))
                {
                    // Előző szekció hozzáadása a dokumentumhoz
                    if (currentSection != null)
                        document.Sections.Add(currentSection);

                    this.CurrentLinePosition = this.CurrentLineText.IndexOf('[') + 1;

                    // Új szekció hozzáadása
                    currentSection = new IniSection(this.ReadSectionHeader());

                    // Hiányzó ]
                    if (this.ReadChar() != ']')
                        throw new IniReadException("Missing ']'.", this.CurrentLineNumber, this.CurrentLinePosition);
                }

                // Komment beolvasása
                else if (trimmedLine.StartsWith(";"))
                {
                    this.CurrentLinePosition = this.CurrentLineText.IndexOf(';');

                    if (currentSection != null)
                        currentSection.CommentLines.Add(this.ReadComment());
                    else
                        document.CommentLines.Add(this.ReadComment());
                }

                // Paraméter beolvasása
                else
                {
                    // White space átugrása
                    this.ReadWhiteSpace();

                    // Név
                    string name = this.ReadParameterName();

                    if (name.Length == 0)
                        throw new IniReadException("Parameter name is missing.", this.CurrentLineNumber, this.CurrentLinePosition);

                    this.ReadWhiteSpace();

                    // Név/érték elválasztó
                    if (this.ReadChar() != this.SyntaxDefinition.NameValueDelimiter)
                        throw new IniReadException("Parameter name can contain only alphabetical and numerical characters.", this.CurrentLineNumber, this.CurrentLinePosition);

                    this.ReadWhiteSpace();

                    // Érték
                    string value = this.ReadParameterValue();

                    if (value.Length == 0)
                        throw new IniReadException("Parameter value is missing.", this.CurrentLineNumber, this.CurrentLinePosition);

                    this.ReadWhiteSpace();

                    // Komment
                    string description = null;

                    if (this.ReadChar() == this.SyntaxDefinition.CommentStartChar)
                        description = this.ReadComment();

                    // Új paraméter hozzáadása
                    currentSection.Parameters.Add(
                        new IniParameter(name, value) { Description = description }
                    );
                }
            }

            if (currentSection != null)
                document.Sections.Add(currentSection);
        }

        /// <summary>
        /// Reads the next char.
        /// </summary>
        /// <returns></returns>
        public char ReadChar()
        {
            return (
                this.CurrentLinePosition < this.CurrentLineText.Length ? this.CurrentLineText[this.CurrentLinePosition++] : '\0'
            );
        }

        /// <summary>
        /// Reads the next char without changing the state of the reader.
        /// </summary>
        /// <returns></returns>
        public char PeekChar()
        {
            return (
                this.CurrentLinePosition < this.CurrentLineText.Length ? this.CurrentLineText[this.CurrentLinePosition] : '\0'
            );
        }

        /// <summary>
        /// Reads white space.
        /// </summary>
        public void ReadWhiteSpace()
        {
            while (this.CurrentLinePosition < this.CurrentLineText.Length && Char.IsWhiteSpace(this.CurrentLineText[this.CurrentLinePosition]))
                this.CurrentLinePosition++;
        }

        /// <summary>
        /// Reads the header of a section.
        /// </summary>
        /// <returns>The name of the section.</returns>
        public string ReadSectionHeader()
        {
            StringBuilder buffer = new StringBuilder();

            while (this.CurrentLinePosition < this.CurrentLineText.Length)
            {
                char ch = this.CurrentLineText[this.CurrentLinePosition];

                // Záró karakter
                if (ch == ']')
                    break;

                // Olvasás
                if (Char.IsLetterOrDigit(ch) || ch == '.')
                    buffer.Append(ch);
                else
                    throw new IniReadException("Section header can contain only alphabetical and numerical characters.", this.CurrentLineNumber, this.CurrentLinePosition);

                this.CurrentLinePosition++;
            }

            return buffer.ToString().Trim();
        }

        /// <summary>
        /// Reads the name of a parameter.
        /// </summary>
        /// <returns>The name of the parameter.</returns>
        public string ReadParameterName()
        {
            StringBuilder buffer = new StringBuilder();

            while (this.CurrentLinePosition < this.CurrentLineText.Length)
            {
                char ch = this.CurrentLineText[this.CurrentLinePosition];

                // Olvasás
                if (Char.IsLetterOrDigit(ch) || ch == '.')
                    buffer.Append(ch);
                else break;

                this.CurrentLinePosition++;
            }

            return buffer.ToString().Trim();
        }

        /// <summary>
        /// Reads the value of a paramter.
        /// </summary>
        /// <returns>The value of the parameter.</returns>
        public string ReadParameterValue()
        {
            StringBuilder buffer = new StringBuilder();

            bool isInQuotes = false,
                isEscaped = false;
            char quoteChar = '\0';

            // Idézőjel-teszt
            char first = this.PeekChar();

            if (first == '"' || first == '\'')
            {
                isInQuotes = true;

                quoteChar = this.ReadChar();
            }
            else
            {
                if (this.SyntaxDefinition.RequireQuotes)
                    throw new IniReadException("The paramter values must be enclosed in quotation marks.", this.CurrentLineNumber, this.CurrentLinePosition);
            }

            // Olvasás
            while (this.CurrentLinePosition < this.CurrentLineText.Length)
            {
                char ch = this.CurrentLineText[this.CurrentLinePosition];

                // Escape
                if (ch == '\\')
                {
                    isEscaped = true;
                    this.CurrentLinePosition++;

                    // Idézőjel
                    if (this.PeekChar() == quoteChar)
                    {
                        buffer.Append(quoteChar);
                        this.CurrentLinePosition++;
                    }
                    else
                        buffer.Append(this.ReadEscape());

                    continue;
                }

                // Idézőjelpár
                if (ch == quoteChar)
                {
                    if (isInQuotes)
                    {
                        this.CurrentLinePosition++;
                        break;
                    }
                    else
                        throw new IniReadException("Unexpected quotation mark.", this.CurrentLineNumber, this.CurrentLinePosition);
                }

                // Whitespace
                if (Char.IsWhiteSpace(ch) && !isInQuotes)
                    break;

                // Komment
                if (ch == this.SyntaxDefinition.CommentStartChar && (!isInQuotes || !isEscaped))
                    break;

                // Karakter hozzáadása
                buffer.Append(ch);

                this.CurrentLinePosition++;
                isEscaped = false;
            }

            return buffer.ToString().Trim();
        }

        /// <summary>
        /// Reads a comment from the input.
        /// </summary>
        /// <returns></returns>
        public string ReadComment()
        {
            return (this.IgnoreComments ? String.Empty : this.CurrentLineText.Substring(this.CurrentLinePosition + 1).Trim());
        }

        /// <summary>
        /// Reads the escaped part of a parameter value.
        /// </summary>
        /// <returns></returns>
        public string ReadEscape()
        {
            char ch = this.ReadChar();

            // Dinamikus
            if (ch == this.SyntaxDefinition.CommentStartChar)
                return this.SyntaxDefinition.CommentStartChar.ToString();

            // Statikus
            switch (ch)
            {
                // Carriage return / New line
                case 'r':
                    {
                        if (this.PeekChar() == '\\' &&
                            this.CurrentLinePosition + 1 < this.CurrentLineText.Length && this.CurrentLineText[this.CurrentLinePosition + 1] == 'n')
                            this.CurrentLinePosition += 2;

                        return Environment.NewLine;
                    }

                // New line
                case 'n':
                    return Environment.NewLine;

                // Tab
                case 't':
                    return "\t";

                // Unicode characters
                case 'x':
                    if (this.CurrentLinePosition + 4 < this.CurrentLineText.Length)
                    {                        
                        string uChar = Char.ConvertFromUtf32(
                            Convert.ToInt32(this.CurrentLineText.Substring(this.CurrentLinePosition, 4), 16)
                        );

                        this.CurrentLinePosition += 4;

                        return uChar;
                    }
                    else
                        throw new IniReadException("Unicode character isn't in the correct format.", this.CurrentLineNumber, this.CurrentLinePosition);

                // Null character
                case '0':
                    return "\0";

                // Escape char
                case '\\':
                    return "\\";

                default:
                    throw new IniReadException(
                        String.Format("Character '{0}' can't be escaped.", ch), this.CurrentLineNumber, this.CurrentLinePosition
                    );
            }
        }
        #endregion

        /// <summary>
        /// Releases all resources used by an IniReader object.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all managed/unmanaged resources.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.reader.Dispose();
            }
        }
    }
}
