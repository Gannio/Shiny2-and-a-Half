using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace System.Ini
{
    /// <summary>
    /// Represents a collection for IniParameter that can be accessed by name or index.
    /// </summary>
    public class IniParameterCollection : ICollection<IniParameter>
    {
        public IniParameterCollection(IniSection section)
        {
            if (section == null)
                throw new ArgumentNullException("section");

            ownerSection = section;
            this.parameters = new List<IniParameter>();
        }

        protected IList<IniParameter> parameters;

        internal IniSection ownerSection;

        /// <summary>
        /// Gets or sets an item in the collection by its item.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IniParameter this[string name]
        {
            get
            {
                return this.parameters.Single(p => p.Name == name);
            }
            set
            {
                this.parameters.Single(p => p.Name == name).Value = value;
            }
        }

        /// <summary>
        /// Adds a new IniParameter to the collection.
        /// </summary>
        /// <param name="item"></param>
        public void Add(IniParameter item)
        {
            foreach (IniParameter p in this.parameters)
                if (p.Name == item.Name)
                    throw new ArgumentException("There is already a paramter in the collection with this name.");

            item.Section = ownerSection;
            this.parameters.Add(item);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            this.parameters.Clear();
        }

        /// <summary>
        /// Determines whether the collection contains a specific value.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(IniParameter item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            return this.parameters.Contains(item);
        }

        public void CopyTo(IniParameter[] array, int arrayIndex)
        {
            this.parameters.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of items contained in the collection.
        /// </summary>
        public int Count
        {
            get { return this.parameters.Count; }
        }

        /// <summary>
        /// Gets the value indicating the collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.parameters.IsReadOnly; }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(IniParameter item)
        {
            return this.parameters.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IniParameter> GetEnumerator()
        {
            return this.parameters.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.parameters.GetEnumerator();
        }
    }
}
