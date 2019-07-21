using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace System.Ini
{
    /// <summary>
    /// Represents a writer that provides a forward-only means of generating streams or files containing INI data.
    /// </summary>
    public class IniWriter : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of IniWriter.
        /// </summary>
        /// <param name="tw"></param>
        public IniWriter(TextWriter tw)
        {
            if (tw == null)
                throw new ArgumentNullException("tw");

            this.writer = tw;

            this.SyntaxDefinition = new IniSyntaxDefinition();
            this.Formatting = new IniWriterFormattingSettings();

            this.WriteComments = true;
        }
        public IniWriter(Stream strm)
            : this(new StreamWriter(strm))
        { }
        public IniWriter(string fileName)
            : this(new FileStream(fileName, FileMode.CreateNew))
        { }

        protected TextWriter writer;

        #region Properties
        /// <summary>
        /// Gets or sets syntax definitions used during document writing.
        /// </summary>
        public IniSyntaxDefinition SyntaxDefinition { get; set; }

        /// <summary>
        /// Gets or sets the formatting settings applied in output.
        /// </summary>
        public IniWriterFormattingSettings Formatting { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to write comments.
        /// </summary>
        public bool WriteComments { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Writes out the whole document.
        /// </summary>
        /// <param name="iniDocument"></param>
        public void WriteDocument(IniDocument iniDocument)
        {
            if (iniDocument == null)
                throw new ArgumentNullException("iniDocument");

            // Dokumentumhoz tartozó kommentek
            if (this.WriteComments && iniDocument.CommentLines.Count > 0)
            {
                this.WriteCommentLines(iniDocument.CommentLines);
                writer.WriteLine();
            }
            
            // Szekciók kiírása
            foreach (IniSection s in this.Formatting.SortSections
                ? iniDocument.Sections.OrderBy(s => s.Header)
                : iniDocument.Sections as IEnumerable<IniSection>
            )
                this.WriteSection(s);
        }

        /// <summary>
        /// Writes out a whole section.
        /// </summary>
        /// <param name="section"></param>
        public void WriteSection(IniSection section)
        {
            if (section == null)
                throw new ArgumentNullException("section");

            if (this.Formatting.PlaceSectionCommentsBeforeHeader && this.WriteComments)
                this.WriteCommentLines(section.CommentLines);

            // Cím
            this.WriteSectionHeader(section.Header);

            if (!this.Formatting.PlaceSectionCommentsBeforeHeader && this.WriteComments)
                this.WriteCommentLines(section.CommentLines);

            // Paraméterek
            foreach (IniParameter p in this.Formatting.SortParameters
                ? section.Parameters.OrderBy(s => s.Name)
                : section.Parameters as IEnumerable<IniParameter>
            )
                this.WriteParameter(p);

            if (this.Formatting.SeparateSections)
                writer.WriteLine();
        }

        /// <summary>
        /// Writes out a paramter with its value and description (if allowed).
        /// </summary>
        /// <param name="parameter"></param>
        public void WriteParameter(IniParameter parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            if (this.Formatting.IndentParameters)
                writer.Write('\t');

            // Név
            this.WriteParameterName(parameter.Name);

            if (this.Formatting.SpaceBeforeDelimiter)
                writer.Write(' ');

            // Elválasztó
            writer.Write(this.SyntaxDefinition.NameValueDelimiter);

            if (this.Formatting.SpaceAfterDelimiter)
                writer.Write(' ');

            // Érték
            this.WriteParameterValue(parameter.Value);

            // Leírás
            if (this.WriteComments && parameter.Description != null)
            {
                if (this.Formatting.SpaceBeforeCommentStart)
                    writer.Write(' ');

                this.WriteComment(parameter.Description);
            }

            writer.WriteLine();
        }

        /// <summary>
        /// Writes out the section header enclosed in brackets.
        /// </summary>
        /// <param name="header"></param>
        public void WriteSectionHeader(string header)
        {
            if (header == null)
                throw new ArgumentNullException("header");

            writer.WriteLine("[{0}]", header);
        }

        /// <summary>
        /// Writes out the name of a parameter.
        /// </summary>
        /// <param name="name"></param>
        public void WriteParameterName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            writer.Write(name);
        }

        /// <summary>
        /// Writes out the value of a parameter.
        /// </summary>
        /// <param name="value"></param>
        public void WriteParameterValue(object value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            string valueAsString = value.ToString();
            bool useQuotes = this.SyntaxDefinition.RequireQuotes ||
                valueAsString.Contains(' ') ||
                valueAsString.Contains(this.SyntaxDefinition.QuoteChar) ||
                valueAsString.Contains(this.SyntaxDefinition.CommentStartChar);

            if (useQuotes)
            {
                writer.Write(this.SyntaxDefinition.QuoteChar);

                // Escape
                valueAsString = this.EscapeParameterValue(valueAsString);

                writer.Write(valueAsString);

                if (useQuotes)
                    writer.Write(this.SyntaxDefinition.QuoteChar);
            }
            else
                writer.Write(value);
        }

        /// <summary>
        /// Writes out a comment.
        /// </summary>
        /// <param name="comment"></param>
        public void WriteComment(string comment)
        {
            if (comment == null)
                throw new ArgumentNullException("comment");

            writer.Write(this.SyntaxDefinition.CommentStartChar);

            if (this.Formatting.SpaceAfterCommentStart)
                writer.Write(' ');

            writer.Write(comment);
        }

        /// <summary>
        /// Writes out a list of commentlines.
        /// </summary>
        /// <param name="comments"></param>
        public void WriteCommentLines(IEnumerable<string> comments)
        {
            if (comments == null)
                throw new ArgumentNullException("comments");

            foreach (string c in comments)
            {
                this.WriteComment(c);
                writer.WriteLine();
            }
        }

        /// <summary>
        /// Escapes the value of a parameter.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal string EscapeParameterValue(string value)
        {
            char[] canBeEscaped = new char[] {
                '\\', this.SyntaxDefinition.CommentStartChar, this.SyntaxDefinition.NameValueDelimiter, this.SyntaxDefinition.QuoteChar,
            };

            foreach (char ch in canBeEscaped)
                value = value.Replace(ch.ToString(), String.Format("\\{0}", ch));

            value = value.Replace("\n", "\\n").
                Replace("\r", "\\r").
                Replace("\t", "\\t")
            ;

            return value;
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
                this.writer.Dispose();
            }
        }
    }
}
