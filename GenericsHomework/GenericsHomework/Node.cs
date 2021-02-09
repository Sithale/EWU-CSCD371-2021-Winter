using System;

namespace GenericsHomework
{
    public class Node<N>
    {
        private N? _Data;
        private Node<N>? _Next;
        public N Data { get => _Data!; private set => _Data = value; }

        public Node<N> Next
        {
            get => _Next!;
            set { value._Next = this; _Next = value; }

        }

        public Node(N node)
        {
            this.Data = node;
            this.Next = this;

        }

        public override string ToString()
        {
            if (Data == null)
                throw new ArgumentNullException(nameof(Data), "Data is null in ToString");

            return this.Data.ToString() ?? "";

        }

        public void Insert(N value)
        {
            Node<N> addNode = new Node<N>(value);
            this.Next = addNode;

        }
        public void Clear()
        {
            this.Next = this;

            /* This will close the loop of the linked list. As a result, the garbage collector
            will be unable to reach the references of the nodes. They will eventually be collected
            while the loop remains open. This will still allow the insertion and deletion of future nodes. */

        }
    }
}
