using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace System.Ini
{
    /// <summary>
    /// Represents a collection for IniSection that can be accessed by header or index.
    /// </summary>
    public class IniSectionCollection : ICollection<IniSection>
    {
        public IniSectionCollection(IniDocument document)
        {
            if (document == null)
                throw new ArgumentNullException("document");

            ownerDocument = document;
            this.sections = new List<IniSection>();
        }

        protected IList<IniSection> sections;

        internal IniDocument ownerDocument;

        /// <summary>
        /// Gets an IniCategory by its index.
        /// </summary>
        /// <param name="index">The index of the IniCategory.</param>
        /// <returns></returns>
        public IniSection this[int index]
        {
            get { return this.sections[index]; }
        }

        /// <summary>
        /// Gets an IniCategory by its header.
        /// </summary>
        /// <param name="header">The title of the IniCategory.</param>
        /// <returns></returns>
        public IniSection this[string header]
        {
            get
            {
                return this.sections.Single(c => c.Header == header);
            }
        }

        /// <summary>
        /// Adds a new IniSection to the collection.
        /// </summary>
        /// <param name="item"></param>
        public void Add(IniSection item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            foreach (IniSection c in this.sections)
                if (c.Header == item.Header)
                    throw new ArgumentException("There is already a section in the document with this header.");

            item.Document = ownerDocument;
            this.sections.Add(item);
        }

        /// <summary>
        /// Removes all items from the collection.
        /// </summary>
        public void Clear()
        {
            this.sections.Clear();
        }

        /// <summary>
        /// Determines whether the collection contains a specified IniSection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(IniSection item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            return this.sections.Contains(item);
        }

        public void CopyTo(IniSection[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            this.sections.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the number of items contained in the collection.
        /// </summary>
        public int Count
        {
            get { return this.sections.Count; }
        }

        /// <summary>
        /// Gets the value indicating the collection is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.sections.IsReadOnly; }
        }

        /// <summary>
        /// Removes the first occorrence of a specific object from the collection.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(IniSection item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            return this.sections.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IniSection> GetEnumerator()
        {
            return this.sections.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.sections.GetEnumerator();
        }
    }
}
