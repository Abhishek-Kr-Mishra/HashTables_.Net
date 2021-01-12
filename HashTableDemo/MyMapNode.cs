using System;
using System.Collections.Generic;
using System.Text;

namespace HashTableDemo
{
    class MyMapNode<K, V>
    {
        ///Variable
        public readonly int size;
        ///Linked list of type key & value.
        public readonly LinkedList<keyValue<K, V>>[] items;
        /// <summary>
        /// Initializes a new instance of the <see cref="MyMapNode{K, V}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<keyValue<K, V>>[size];
        }
        /// <summary>
        /// Gets and sets the values.
        /// </summary>
        /// <typeparam name="k"></typeparam>
        /// <typeparam name="v"></typeparam>
        public struct keyValue<k, v>
        {
            public k key { get; set; }
            public v value { get; set; }
        }
        /// <summary>
        /// Gets the linkedlist.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        protected LinkedList<keyValue<K, V>> GetLinkedlist(int position)
        {
            LinkedList<keyValue<K, V>> linkedLlist = items[position];
            if (linkedLlist == null)
            {
                linkedLlist = new LinkedList<keyValue<K, V>>();
                items[position] = linkedLlist;
            }
            return linkedLlist;
        }
        /// <summary>
        /// Gets the array postion.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        protected int GetArrayPostion(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public void Add(K key, V value)
        {
            int position = GetArrayPostion(key);
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);

            keyValue<K, V> item = new keyValue<K, V>() { key = key, value = value };
            linkedlist.AddLast(item);
        }
        /// <summary>
        ///Gives the count the of word provided.
        /// </summary>
        public int GetFrequency(V value)
        {
            int frequency = 0;
            ///Iterating to get the key value of each item.
            foreach (LinkedList<keyValue<K, V>> list in items)
            {
                ///Checking if key is not null 
                if (list == null)
                    continue;
                ///Iterating to get the value of the item in linked list.
                foreach (keyValue<K, V> item in list)
                {
                    if (item.Equals(null))
                        continue;
                    if (item.value.Equals(value))
                        frequency++;
                }
            }
            return frequency;
        }
    }
}
