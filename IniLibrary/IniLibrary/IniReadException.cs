using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Ini
{
    /// <summary>
    /// Represents errors that occur during INI content reading.
    /// </summary>
    [Serializable]
    public class IniReadException : Exception
    {
        public IniReadException(string message, int line, int pos) : base(message)
        {
            this.LineNumberOffset = line;
            this.LinePositionOffset = pos;
        }

        /// <summary>
        /// Gets the line number where the error occurred.
        /// </summary>
        public int LineNumberOffset { get; protected set; }

        /// <summary>
        /// Gets the line position where the error occurred.
        /// </summary>
        public int LinePositionOffset { get; protected set; }
    }
}
