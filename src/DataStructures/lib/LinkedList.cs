namespace DataStructures.lib
{
    public class CustomLinkedList<T>
    {
        private Node? _head;
        private Node? _tail;
        private int _length;

        public class Node(T value)
        {
            public T Value = value;
            public Node? Next { get; set; } // How does this line work? What does this syntax mean??
        }

        public void Append(T value)
        {
            Node newNode = new(value);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
                _length = 1;
            }
            else
            {
                _tail!.Next = newNode;
                _tail = newNode;
                _length++;
            }
        }

        public int Length()
        {
            return _length;
        }

        public Node? Find(T value)
        {
            Node? current = _head;
            while (current is not null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public Node? Find(int index)
        {
            int listIndex = index;
            Node? current = _head;

            if (index > _length - 1)
            {
                throw new ArgumentOutOfRangeException($"Index out of range: {index}");
            }

            if (index < 0)
            {
                listIndex = 0;
            }

            if (current is null)
            {
                return null;
            }

            for (int i = 0; i < listIndex; i++)
            {
                if (current.Next is not null)
                {
                    current = current.Next;
                }
            }

            return current;
        }

        public T? Pop()
        {
            if (_length == 1)
            {
                Node? temp = _head;
                _head = null;
                _tail = null;
                _length--;
                return temp!.Value;
            }
            else if (_tail is not null)
            {
                Node temp = _tail;
                Node? newTail = Find(_length - 2);
                newTail!.Next = null;
                _tail = newTail;
                _length--;
                return temp.Value;
            }

            return default;
        }

        public override string ToString()
        {
            Node? current = _head;

            string output = "";
            if (current is null)
            {
                return output;
            }

            for (int i = 0; i < _length; i++)
            {
                output += $"{current.Value}";
                if (current.Next is not null)
                {
                    current = current.Next;
                    output += ", ";
                }
                else
                {
                    break;
                }
            }

            return output;
        }

        ///<summary>Removes the first instance of a node with a matching value</summary>
        public void Remove(T value) { }
    }
}
