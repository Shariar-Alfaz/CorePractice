using System.Text;

namespace LinkedList
{
    public class SinglyLinkedList<T> where T : IComparable<T>
    {
        private SinglyNode<T> Head { get; set; } = null;

        public SinglyNode<T> GetHead() => Head;

        public void Add(T data)
        {
            var newNode = new SinglyNode<T>(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                var current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void Add(params T[] data)
        {
            foreach (var item in data)
            {
                Add(item);
            }
        }

        public int Length()
        {
            int count = 0;
            var current = Head;
            while (current != null)
            {
                ++count;
                current = current.Next;
            }
            return count;
        }

        public static int Length(SinglyNode<T> node)
        {
            int count = 0;
            var current = Head;
            while (current != null)
            {
                ++count;
                current = current.Next;
            }
            return count;
        }

        public void Print()
        {
            var current = Head;
            while (current != null)
            {
                if (current.Next == null)
                {
                    Console.WriteLine(current.Data);
                }
                else
                {
                    Console.Write(current.Data + " -> ");
                }
                current = current.Next;
            }

        }

        public void RemoveDuplicates()
        {
            var current = Head;
            HashSet<T> seen = new();
            SinglyNode<T> previous = null;
            while (current != null)
            {
                if (seen.Contains(current.Data))
                {
                    previous.Next = current.Next; // Remove current node
                }
                else
                {
                    seen.Add(current.Data);
                    previous = current;
                }
                current = current.Next;
            }
        }

        // Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.
        public T GetKthLast(int k)
        {
            var first = Head;
            var second = Head;

            for (int i = 0; i < k; i++)
            {
                if (first == null) return default;
                first = first.Next;
            }

            while (first != null)
            {
                first = first.Next;
                second = second.Next;
            }
            return second.Data;
        }

        // Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but
        // the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
        // that node.
        public void DeleteMiddle()
        {
            var fast = Head;
            var slow = Head;
            SinglyNode<T> previous = null;
            while (fast != null && fast.Next != null)
            {
                previous = slow;
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            if (previous != null && slow != null)
            {
                previous.Next = slow.Next; // Remove middle node
            }
        }


        // Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
        // before all nodes greater than or equal to x. If x is contained within the list, the values of x only need
        // to be after the elements less than x (see below). The partition element x can appear anywhere in the
        // "right partition"; it does not need to appear between the left and right partitions.
        public void Partition(T data)
        {
            SinglyNode<T> beforeHead = null;
            SinglyNode<T> beforeTail = null;
            SinglyNode<T> afterHead = null;
            SinglyNode<T> afterTail = null;
            var current = Head;

            while (current != null)
            {
                var next = current.Next;
                current.Next = null; // Break the link

                if (current.Data.CompareTo(data) < 0)
                {
                    if (beforeHead == null)
                    {
                        beforeHead = current;
                        beforeTail = beforeHead;
                    }
                    else
                    {
                        beforeTail.Next = current;
                        beforeTail = current;
                    }
                }
                else
                {
                    if (afterHead == null)
                    {
                        afterHead = current;
                        afterTail = afterHead;
                    }
                    else
                    {
                        afterTail.Next = current;
                        afterTail = current;
                    }
                }
                current = next;
            }
            if (beforeHead == null)
            {
                Head = afterHead;
            }
            else
            {
                beforeTail.Next = afterHead;
                Head = beforeHead;
            }
        }

        // Sum Lists: You have two numbers represented by a linked list, where each node contains a single
        // digit. The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
        // function that adds the two numbers and returns the sum as a linked list.
        public static SinglyNode<int> SumList(SinglyNode<int> l1, SinglyNode<int> l2)
        {
            SinglyNode<int> dummyHead = new(0);
            var current = dummyHead;
            int carry = 0;
            while (l1 != null || l2 != null || carry != 0)
            {
                int sum = carry;
                if (l1 != null)
                {
                    sum += l1.Data;
                    l1 = l1.Next;
                }
                if (l2 != null)
                {
                    sum += l2.Data;
                    l2 = l2.Next;
                }
                carry = sum / 10;
                current.Next = new SinglyNode<int>(sum % 10);
                current = current.Next;
            }
            return dummyHead.Next;
        }

        public static void PrintFromHead(SinglyNode<T> head)
        {

            while (head != null)
            {
                if (head.Next == null)
                {
                    Console.WriteLine(head.Data);
                }
                else
                {
                    Console.Write(head.Data + " -> ");
                }
                head = head.Next;
            }
        }

        //Suppose the digits are stored in forward order. Repeat the above problem.
        public static SinglyNode<int> SumListForward(SinglyNode<int> l1, SinglyNode<int> l2)
        {
            StringBuilder sb1 = new();
            StringBuilder sb2 = new();
            SinglyNode<int> dummy = new(0);
            var current = dummy;
            while (l1 != null || l2 != null)
            {
                if (l1 != null)
                {
                    sb1.Append(l1.Data);
                    l1 = l1.Next;
                }
                if (l2 != null)
                {
                    sb2.Append(l2.Data);
                    l2 = l2.Next;
                }
            }

            int sum = int.Parse(sb1.ToString()) + int.Parse(sb2.ToString());
            List<int> digits = new();
            while (sum > 0)
            {
                digits.Add(sum % 10);
                sum /= 10;
            }
            digits.Reverse();
            foreach (var digit in digits)
            {
                current.Next = new SinglyNode<int>(digit);
                current = current.Next;
            }
            return dummy.Next;
        }

        // Intersection: Given two (singly) linked lists, determine if the two lists intersect. Return the intersecting
        // node. Note that the intersection is defined based on reference, not value. That is, if the kth
        // node of the first linked list is the exact same node (by reference) as the jth node of the second
        // linked list, then they are intersecting.
        public static SinglyNode<T>? GetIntersection(SinglyNode<T> head1, SinglyNode<T> head2)
        {
            int length1 = Length(head1);
            int length2 = Length(head2);
            int diff = Math.Abs(length1 - length2);
            if (length1 > length2)
                for (int i = 0; i < diff; i++) head1 = head1.Next;
            else
                for (int i = 0; i < diff; i++) head2 = head2.Next;
            while (head1 != null && head2 != null)
            {
                if (head1 == head2) return head1;
                head1 = head1.Next;
                head2 = head2.Next;
            }
            return null; // No intersection
        }

        // Loop Detection: Given a circular linked list, implement an algorithm that returns the node at the
        // beginning of the loop.
        // DEFINITION
        // Circular linked list: A (corrupt) linked list in which a node's next pointer points to an earlier node, so
        // as to make a loop in the linked list.
        public static SinglyNode<T> GetLoopStart(SinglyNode<T> singlyNode)
        {
            var slow = singlyNode;
            var fast = singlyNode;
            // Find the meeting point
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
                if (slow == fast) break;
            }
            if (fast == null || fast.Next == null) return null; // No loop
            // Move slow to head and keep fast at meeting point
            slow = singlyNode;
            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next;
            }
            return slow; // Start of loop
        }
    }
}
