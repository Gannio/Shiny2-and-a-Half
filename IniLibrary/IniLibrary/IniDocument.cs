using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace System.Ini
{
    /// <summary>
    /// Represents an INI document.
    /// </summary>
    public class IniDocument : IEnumerable<IniSection>
    {
        /// <summary>
        /// Initializes a new instance of IniDocument.
        /// </summary>
        public IniDocument()
        {
            this.Sections = new IniSectionCollection(this);
            this.CommentLines = new List<string>();

            this.SyntaxDefinition = new IniSyntaxDefinition();
        }

        #region Properties
        /// <summary>
        /// Gets all the categories of the document.
        /// </summary>
        public IniSectionCollection Sections { get; protected set; }

        /// <summary>
        /// Gets or sets syntax definitions.
        /// </summary>
        public IniSyntaxDefinition SyntaxDefinition { get; set; }

        /// <summary>
        /// Gets the list of commentlines attached to the document.
        /// </summary>
        public IList<string> CommentLines { get; private set; }
        #endregion

        #region Methods
        /// <summary>
        /// Loads the INI content by a specified IniReader.
        /// </summary>
        /// <param name="ir"></param>
        public void Load(IniReader ir)
        {
            if (ir == null)
                throw new ArgumentNullException("ir");

            ir.ReadDocument(this);
        }
        /// <summary>
        /// Loads the INI content from a specified TextReader.
        /// </summary>
        /// <param name="tr"></param>
        public void Load(TextReader tr)
        {
            if (tr == null)
                throw new ArgumentNullException("tr");

            this.Load(
                new IniReader(tr) {
                    SyntaxDefinition = this.SyntaxDefinition
                }
            );
        }
        /// <summary>
        /// Loads the INI content from a specified System.IO.Stream.
        /// </summary>
        /// <param name="strm">The stream containing the INI document to load.</param>
        public void Load(Stream strm)
        {
            if (strm == null)
                throw new ArgumentNullException("strm");

            using (StreamReader sr = new StreamReader(strm))
                this.Load(sr);
        }
        /// <summary>
        /// Loads the INI content from a specified URL.
        /// </summary>
        /// <param name="path">URL for the file containing the INI document to load.</param>
        public void Load(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            this.Load(new FileStream(path, FileMode.Open));
        }

        /// <summary>
        /// Saves the INI document by a specified IniWriter.
        /// </summary>
        /// <param name="iw"></param>
        public void Save(IniWriter iw)
        {
            if (iw == null)
                throw new ArgumentNullException("iw");

            iw.WriteDocument(this);
        }
        /// <summary>
        /// Saves the INI document to the specified TextWriter.
        /// </summary>
        /// <param name="tw">The TextWriter to which you want to save.</param>
        /// <param name="formatting">Formatting options used to render the content.</param>
        public void Save(TextWriter tw, IniWriterFormattingSettings formatting)
        {
            if (tw == null)
                throw new ArgumentNullException("tw");

            if (formatting == null)
                throw new ArgumentNullException("formatting");

            using (IniWriter iw = new IniWriter(tw))
            {
                iw.SyntaxDefinition = this.SyntaxDefinition;
                iw.Formatting = formatting;

                this.Save(iw);
            }
        }
        /// <summary>
        /// Saves the INI document to the specified TextWriter.
        /// </summary>
        /// <param name="tw">The TextWriter to which you want to save.</param>
        public void Save(TextWriter tw)
        {
            this.Save(tw, new IniWriterFormattingSettings());
        }
        /// <summary>
        /// Saves the INI document to the specified stream.
        /// </summary>
        /// <param name="strm">The stream to which you want to save.</param>
        public void Save(Stream strm, IniWriterFormattingSettings formatting)
        {
            if (strm == null)
                throw new ArgumentNullException("strm");

            if (formatting == null)
                throw new ArgumentNullException("formatting");

            using (TextWriter sw = new StreamWriter(strm))
                this.Save(sw, formatting);
        }
        /// <summary>
        /// Saves the INI document to the specified stream.
        /// </summary>
        /// <param name="strm">The stream to which you want to save.</param>
        public void Save(Stream strm)
        {
            this.Save(strm, new IniWriterFormattingSettings());
        }
        /// <summary>
        /// Saves the INI document to the specified file.
        /// </summary>
        /// <param name="fileName">The location of the file where you want to save the document.</param>
        public void Save(string fileName, IniWriterFormattingSettings formatting)
        {
            if (fileName == null)
                throw new ArgumentNullException("fileName");

            if (formatting == null)
                throw new ArgumentNullException("formatting");

            this.Save(new FileStream(fileName, FileMode.CreateNew));
        }
        /// <summary>
        /// Saves the INI document to the specified file.
        /// </summary>
        /// <param name="fileName">The location of the file where you want to save the document.</param>
        public void Save(string fileName)
        {
            this.Save(fileName, new IniWriterFormattingSettings());
        }
        #endregion

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IniSection> GetEnumerator()
        {
            return this.Sections.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Sections.GetEnumerator();
        }
    }
}
