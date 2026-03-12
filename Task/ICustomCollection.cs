namespace Task;

public interface ICustomCollection<T>
{
        public void AddFirst(T value);
        public void AddLast(T value);
        public void AddInsert(int index, T value);
        public void AddRange(T[] values);
        public void Print();
        public void RemoveFirst();
        public void RemoveLast();
        public void RemoveAt(int index);
        public void RemoveSecond();
        public void RemoveRange(int index);
        public void RemoveAllOccurrences(T value);
        public void Reverse();
        public int Size();
        public bool IsEmpty();
        public bool Contains(T value);
        public void FindAllIndices(T value);
}