// @djanesh : https://github.com/djanesh/LinkedList-in-Csharp/tree/master/linked-list1

namespace ETML.Utils.LinkedList
{
    public class Node
    {
        /* Constructor
         * [x] Node(object data, Node next)
         *
         * Private Fields :
         * [x]object data - contain the data of the node, what we want to store in the list
         * [x]Node next  - reference to the next node in the list
         *
         * Public Properties:
         * [x] Data - get / set the data field
         * [x] next - get / set the next field
         */

        public Node(object data)
        {
            this.Data = data;
            this.Next = null;
        }

        public Node(object data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }

        public object Data { get; set; }

        public Node Next { get; set; }
    }
}
