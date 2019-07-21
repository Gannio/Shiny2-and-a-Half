namespace System.Ini
{
    /// <summary>
    /// Represents a parameter in an IniSection.
    /// </summary>
    public class IniParameter
    {
        public IniParameter(string name, object value)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets the section where the IniParameter is.
        /// </summary>
        public IniSection Section { get; internal set; }

        /// <summary>
        /// Gets or sets the description for the parameter. It will be printed into the output stream as a comment.
        /// </summary>
        public string Description { get; set; }
    }
}
