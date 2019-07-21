namespace System.Ini
{
    /// <summary>
    /// Represents a class for configuring IniWriter output format.
    /// </summary>
    public class IniWriterFormattingSettings
    {
        /// <summary>
        /// Creates a new instance of IniWriterFormattingSettings with default settings.
        /// </summary>
        public IniWriterFormattingSettings()
        {
            this.SeparateSections = true;
            this.SpaceAfterDelimiter = true;
            this.SpaceBeforeDelimiter = true;
            this.SpaceBeforeCommentStart = false;
            this.SpaceAfterCommentStart = true;
            this.PlaceSectionCommentsBeforeHeader = false;
            this.SortSections = false;
            this.SortParameters = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use a space before name/value delimiter.
        /// </summary>
        public bool SpaceBeforeDelimiter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use a space after name/value delimiter.
        /// </summary>
        public bool SpaceAfterDelimiter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether serparate sections with an empty line.
        /// </summary>
        public bool SeparateSections { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use a space between the parameter value and the comment start.
        /// </summary>
        public bool SpaceBeforeCommentStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use a space after the comment start character.
        /// </summary>
        public bool SpaceAfterCommentStart { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to indent parameters.
        /// </summary>
        public bool IndentParameters { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to place section comments before section headers.
        /// </summary>
        public bool PlaceSectionCommentsBeforeHeader { get; set; }

        /// <summary>
        /// Write sections ordered by name.
        /// </summary>
        /// <returns></returns>
        public bool SortSections { get; set; }

        /// <summary>
        /// Write parameters ordered by name
        /// </summary>
        /// <returns></returns>
        public bool SortParameters { get; set; }
    }
}
