using System.Collections;

namespace Lab1.SortedList;

public class SortedList<T> : ICollection<T> where T : IComparable<T>
{
    private Node<T>? _head;
    
    public IEnumerator<T> GetEnumerator()
    {
        var node = _head;
        while (node is not null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public T? Find(Predicate<T> predicate)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public int Count { get; }
    public bool IsReadOnly { get; }
}

public class Node<T>
{
    public required T Value { get; set; }
    public Node<T>? Next { get; set; }
}