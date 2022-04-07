using System;

namespace Generic
{
    class Program
    {
        static void Main(string[] args)
        { }
            class CustomList<T>
        {
            private T[] _arr;
            private int _count;
            public int Capacity { get; set; } = 0;
            public int Count { get => _count; }
            public int Length { get => _arr.Length; }
            public CustomList()
            {
                _count = 0;
                _arr = new T[0];
            }
            public void Add(T input)
            {
                Resizable(_count == _arr.Length);
                _arr[Count] = input;
                _count++;
            }
            public void Clear()
            {
                _arr = new T[0];
                _count = 0;
            }
            public bool Exists(Predicate<T> expression)
            {
                for (int i = 0; i < _arr.Length; i++)
                {
                    if (expression(_arr[i]))
                    {
                        return true;
                    }
                }
                return false;
            }
            public bool Remove(T item)
            {

                T[] newArr = new T[0];
                _count = 0;
                if (!_arr.Contains(item))
                {
                    return false;
                }
                for (int i = 0; i < _arr.Length; i++)
                {
                    if (!_arr[i].Equals(item))
                    {
                        _count++;
                        newArr[_count] = _arr[i];
                    }
                }
                _arr = newArr;
                Resizable(_count == _arr.Length);
                return true;
            }
            public void Reverse()
            {
                for (int i = 0; i < _arr.Length - i; i++)
                {
                    var value = _arr[_arr.Length - i - 1];
                    _arr[_arr.Length - i - 1] = _arr[i];
                    _arr[i] = value;
                }
            }
            public int IndexOf(T item, int index)
            {
                for (int i = index; i < _arr.Length; i++)
                {
                    if (_arr[i].Equals(item))
                    {
                        return i;
                    }
                }
                return -1;
            }
            public int LastIndexOf(T item, int index)
            {
                for (int i = _arr.Length - 1; i >= index; i++)
                {
                    if (_arr[i].Equals(item))
                    {
                        return i;
                    }
                }
                return -1;
            }
            private void Resizable(bool b)
            {
                if (b) Array.Resize(ref _arr, (_arr.Length == 0 ? 1 : _arr.Length) * 2);
            }
        }
    }
}
