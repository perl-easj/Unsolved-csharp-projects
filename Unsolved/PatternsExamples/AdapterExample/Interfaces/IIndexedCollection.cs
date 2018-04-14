using System.Collections.Generic;

namespace AdapterExample.Interfaces
{
    public interface IIndexedCollection<T>
    {
        int Count { get; }
        List<T> All { get; }
        void Add(T obj);
        void Remove();
        void InsertAt(T obj, int pos);
        void DeleteAt(int pos);
        T At(int pos);
    }
}