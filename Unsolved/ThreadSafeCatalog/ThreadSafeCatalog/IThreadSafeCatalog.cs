using System.Collections.Generic;

namespace ThreadSafeCatalog
{
    public interface IThreadSafeCatalog<TKey, TValue>
    {
        void Add(TKey key, TValue value);
        bool ContainsKey(TKey key);
        TValue Get(TKey key);
        List<TKey> Keys { get; }
        List<TValue> Values { get; }
        int Count { get; }
    }
}