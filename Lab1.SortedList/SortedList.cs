using System.Collections;

namespace Lab1.SortedList;

public class SortedList<T> : ICollection<T> where T : IComparable<T>
{
    private Node<T>? _head;
    public int Count { get; private set; }
    public bool IsReadOnly => false;

    public event EventHandler? OnAdd;
    public event EventHandler? OnRemove;
    public event EventHandler? OnClear;
    
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
        ArgumentNullException.ThrowIfNull(item);
        
        Count++;
        var newNode = new Node<T>
        {
            Value = item
        };

        if (_head is null || item.CompareTo(_head.Value) < 0)
        {
            newNode.Next = _head;
            _head = newNode;
            return;
        }

        var node = _head;
        while (node.Next is not null && item.CompareTo(node.Next.Value) > 0)
        {
            node = node.Next;
        }

        newNode.Next = node.Next;
        node.Next = newNode;
        
        OnAdd?.Invoke(this, EventArgs.Empty);
    }

    public T? Find(Predicate<T> match)
    {
        foreach (var item in this)
        {
            if (match(item))
            {
                return item;
            }
        }

        return default;
    }

    public void Clear()
    {
        _head = null;
        Count = 0;
        
        OnClear?.Invoke(this, EventArgs.Empty);
    }

    public bool Contains(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        
        foreach (var node in this)
        {
            if (node.CompareTo(item) == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }
        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException("Destination array is not long enough to copy all the items in the collection.");
        }
        
        var i = arrayIndex;
        foreach (var item in this)
        {
            array[i] = item;
            i++;
        }
    }

    public bool Remove(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        
        var node = _head;
        if (node is null) return false;
        
        if (node.Value.CompareTo(item) == 0)
        {
            Count--;
            _head = node.Next;
        
            OnRemove?.Invoke(this, EventArgs.Empty);
            return true;
        }
        
        while (node.Next is not null)
        {
            if (node.Next.Value.CompareTo(item) == 0)
            {
                Count--;
                node.Next = node.Next.Next;
        
                OnRemove?.Invoke(this, EventArgs.Empty);
                return true;
            }
            
            node = node.Next;
        }

        return false;
    }

    public override string ToString()
    {
        return string.Join(", ", this);
    }
}

public class Node<T>
{
    public required T Value { get; init; }
    public Node<T>? Next { get; set; }
}