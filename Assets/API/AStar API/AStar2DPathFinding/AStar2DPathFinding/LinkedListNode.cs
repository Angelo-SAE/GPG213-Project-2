using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar2DPathFinding
{
    public class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T> next, previous;
    }
}
