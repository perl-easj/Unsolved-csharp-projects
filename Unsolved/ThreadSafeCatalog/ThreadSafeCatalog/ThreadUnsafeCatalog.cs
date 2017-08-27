using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ThreadSafeCatalog
{
    public class ThreadUnsafeCatalog : IThreadSafeCatalog<long, long>
    {
        private Dictionary<long, long> _dictionary;

        public ThreadUnsafeCatalog()
        {
            _dictionary = new Dictionary<long, long>();
        }

        public void Add(long key, long value)
        {
                _dictionary[key] = value;
        }

        public bool ContainsKey(long key)
        {
            return _dictionary.ContainsKey(key);
        }

        public long Get(long key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                throw new ArgumentException();
            }

            return _dictionary[key];
        }

        public List<long> Keys
        {
            get { return _dictionary.Keys.ToList(); }
        }

        public List<long> Values
        {
            get { return _dictionary.Values.ToList(); }
        }

        public int Count
        {
            get { return _dictionary.Count; }
        }
    }
}