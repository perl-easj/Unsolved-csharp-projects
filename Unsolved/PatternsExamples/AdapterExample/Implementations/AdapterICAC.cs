using System.Collections.Generic;
using System.Linq;
using AdapterExample.Interfaces;

namespace AdapterExample.Implementations
{
    public class AdapterICAC<T> : IIndexedCollection<T>
    {
        private IArrayCollection<T> _adaptee;

        public AdapterICAC()
        {
            _adaptee = new ArrayCollection<T>();
        }

        public AdapterICAC(IArrayCollection<T> adaptee)
        {
            _adaptee = adaptee;
        }

        public int Count
        {
            get { return _adaptee.GetSize(); }
        }

        public List<T> All
        {
            get { return _adaptee.GetArray().ToList(); }
        }

        public void Add(T obj)
        {
            _adaptee.Insert(obj, _adaptee.GetSize());
        }

        public void Remove()
        {
            _adaptee.Delete(_adaptee.GetSize() - 1);
        }

        public void InsertAt(T obj, int pos)
        {
            _adaptee.Insert(obj, pos);
        }

        public void DeleteAt(int pos)
        {
            _adaptee.Delete(pos);
        }

        public T At(int pos)
        {
            return _adaptee.ElementAt(pos);
        }
    }
}