namespace AdapterExample.Interfaces
{
    public interface IArrayCollection<T>
    {
        int GetSize();
        T[] GetArray();
        void Insert(T obj, int pos);
        void Delete(int pos);
        T ElementAt(int pos);
    }
}