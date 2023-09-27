using Lab1.SortedList;

var sortedList = new SortedList<int>();

sortedList.OnAdd += (sender, args) => Console.WriteLine("Element added!");
sortedList.OnRemove += (sender, args) => Console.WriteLine("Element removed!");
sortedList.OnClear += (sender, args) => Console.WriteLine("List cleared!");

Console.WriteLine(sortedList.Count);
Console.WriteLine("Add items");
sortedList.Add(2);
sortedList.Add(1);
sortedList.Add(-1);
sortedList.Add(0);
sortedList.Add(0);
sortedList.Add(2);
sortedList.Add(-9);
Console.WriteLine(sortedList.Count);

sortedList.Remove(0);

var arr = new int[sortedList.Count];
sortedList.CopyTo(arr, 0);
Console.WriteLine(string.Join(", ", arr));

Console.WriteLine(sortedList.Count);
Console.WriteLine(sortedList);
Console.WriteLine(sortedList.Remove(-9));
Console.WriteLine(sortedList.Remove(-8));
sortedList.Clear();

Console.WriteLine(sortedList.Count);
Console.WriteLine(sortedList);