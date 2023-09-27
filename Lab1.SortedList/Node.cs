namespace Lab1.SortedList;

public class Node<T>
{
    public required T Value { get; init; }
    public Node<T>? Next { get; set; }
}