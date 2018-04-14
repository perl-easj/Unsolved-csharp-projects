using System;
using AdapterExample.Interfaces;

namespace AdapterExample.Implementations
{
    public class ArrayCollection<T> : IArrayCollection<T>
    {
        private T[] _array;
        private int _size;
        private int _length;

        public ArrayCollection()
        {
            _size = 0;
            _length = 100;
            _array = new T[_length];
        }

        public int GetSize()
        {
            return _size;
        }

        public T[] GetArray()
        {
            T[] arrayCopy = new T[_size];

            for (int i = 0; i < _size; i++)
            {
                arrayCopy[i] = _array[i];
            }

            return arrayCopy;
        }

        public void Insert(T obj, int pos)
        {
            ValidatePos(pos, _size);

            if (_size == _length)
            {
                ExtendArray();
            }

            MoveAndInsert(obj, pos);
        }

        public void Delete(int pos)
        {
            ValidatePos(pos, _size - 1);
            MoveAndDelete(pos);
        }

        public T ElementAt(int pos)
        {
            ValidatePos(pos, _size - 1);
            return _array[pos];
        }

        private void ValidatePos(int pos, int maxPos)
        {
            if (pos < 0)
            {
                throw new ArgumentException($"ArrayCollection: negative index not allowed");
            }

            if (pos > maxPos)
            {
                throw new ArgumentException($"ArrayCollection: index {pos} is out of range");
            }
        }

        private void ExtendArray()
        {
            T[] newArray = new T[_length * 2];

            for (int i = 0; i < _length; i++)
            {
                newArray[i] = _array[i];
            }

            _length = _length * 2;
            _array = newArray;
        }

        private void MoveAndInsert(T obj, int pos)
        {
            for (int i = _size; i > pos; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[pos] = obj;
            _size++;
        }

        private void MoveAndDelete(int pos)
        {
            for (int i = pos; i < (_size - 1); i++)
            {
                _array[i] = _array[i + 1];
            }

            _size--;
        }
    }
}