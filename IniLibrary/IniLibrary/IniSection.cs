using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace System.Ini
{
    /// <summary>
    /// Represents an INI category.
    /// </summary>
    public class IniSection : IEnumerable<IniParameter>
    {
        public IniSection(string header)
        {
            if (header == null)
                throw new ArgumentNullException("header");

            this.Header = header;
            this.CommentLines = new List<string>();
            this.Parameters = new IniParameterCollection(this);
        }

        /// <summary>
        /// Gets or sets a property in the Values Dictionary by its name.
        /// </summary>
        /// <param name="key">The name of the value to get or set.</param>
        /// <returns></returns>
        public object this[string key]
        {
            get { return this.Parameters[key].Value; }
            set { this.Parameters[key].Value = value; }
        }

        /// <summary>
        /// Gets or sets the title of the category.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets the a list of commentlines attached to this section.
        /// </summary>
        public IList<string> CommentLines { get; private set; }

        /// <summary>
        /// Gets all the Name-Value pairs of the category.
        /// </summary>
        public IniParameterCollection Parameters { get; private set; }

        /// <summary>
        /// Gets the owner document.
        /// </summary>
        public IniDocument Document { get; internal set; }

        /// <summary>
        /// Adds a new property to the Dictionary.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <param name="value">The value of the property.</param>
        public void AddParameter(string name, object value)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            this.Parameters.Add(new IniParameter(name, value));
        }

        /// <summary>
        /// Gets a property from the Dictionary by its name.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns></returns>
        public object GetParameter(string key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            return this.Parameters[key].Value;
        }

        /// <summary>
        /// Gets a property from the Dictionary by its name and casts it to the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The name of the property.</param>
        /// <returns></returns>
        public T GetParameter<T>(string key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            return (T)this.Parameters[key].Value;
        }

        /// <summary>
        /// Sets a property by its name.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <param name="value">The new value to set.</param>
        public void SetParameter(string key, object value)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            this.Parameters[key].Value = value;
        }

        /// <summary>
        /// Determines whether the Values Dictionary contains a property with the specified name.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        /// <returns></returns>
        public bool ContainsParameter(string key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            return this.Parameters.Any(i => i.Name == key);
        }

        /// <summary>
        /// Removes a property with the specified name.
        /// </summary>
        /// <param name="key">The name of the property.</param>
        public void RemoveParameter(string key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            this.Parameters.Remove(this.Parameters.First(p => p.Name == key));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IniParameter> GetEnumerator()
        {
            return this.Parameters.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Parameters.GetEnumerator();
        }
    }
}
