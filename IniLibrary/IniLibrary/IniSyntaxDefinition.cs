using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Ini
{
    /// <summary>
    /// Represents a class for describing Ini syntax.
    /// </summary>
    public class IniSyntaxDefinition
    {
        /// <summary>
        /// Creates a new instance of IniSyntaxDefinition with the default settings.
        /// </summary>
        public IniSyntaxDefinition()
        {
            this.RequireQuotes = false;
            this.QuoteChar = '"';
            this.NameValueDelimiter = '=';
            this.CommentStartChar = ';';
        }

        /// <summary>
        /// Gets or sets the property of requiring quotes during document loading and using during saving.
        /// </summary>
        public bool RequireQuotes { get; set; }

        /// <summary>
        /// Gets or sets the quotation mark user to enclose the value of a parameter.
        /// </summary>
        public char QuoteChar { get; set; }

        /// <summary>
        /// Gets or sets the property name/value delimiter char.
        /// </summary>
        public char NameValueDelimiter { get; set; }

        /// <summary>
        /// Gets or sets the character that indicates the start of a comment.
        /// </summary>
        public char CommentStartChar { get; set; }
    }
}
