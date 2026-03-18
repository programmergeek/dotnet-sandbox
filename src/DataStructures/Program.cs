using DataStructures.lib;

CustomLinkedList<string> custom = new();
custom.Append("first");
custom.Append("second");
custom.Append("third");

Console.WriteLine($"List: {custom}");
Console.WriteLine($"Length: {custom.Length()}");
Console.WriteLine(custom.Pop());
Console.WriteLine($"List: {custom}");
Console.WriteLine($"Length: {custom.Length()}");
Console.WriteLine(custom.Pop());
Console.WriteLine($"List: {custom}");
Console.WriteLine($"Length: {custom.Length()}");
Console.WriteLine(custom.Pop());
Console.WriteLine($"List: {custom}");
Console.WriteLine($"Length: {custom.Length()}");
