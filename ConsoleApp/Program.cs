using Lab1.SortedList;

var sortedList = new SortedList<int>();

sortedList.OnAdd += (sender, args) => Console.WriteLine("Element added!");
sortedList.OnRemove += (sender, args) => Console.WriteLine("Element removed!");
sortedList.OnClear += (sender, args) => Console.WriteLine("List cleared!");

sortedList.Add(2);
sortedList.Add(1);
sortedList.Add(-1);
sortedList.Add(0);
sortedList.Add(0);
sortedList.Add(2);
sortedList.Add(-9);

sortedList.Remove(0);
var nine = sortedList.Find(x => x == -9);

// sortedList.CopyTo(arr, 0);

Console.WriteLine(sortedList.Count);
Console.WriteLine(sortedList);
Console.WriteLine(sortedList.Remove(-9));
Console.WriteLine(sortedList.Remove(-8));
sortedList.Clear();

Console.WriteLine(sortedList.Count);
Console.WriteLine(sortedList);