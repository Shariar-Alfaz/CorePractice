package LinkedList;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;

public class SinglyLinkedList<T extends Comparable<T>> {
    private SinglyNode<T> head;

    public SinglyNode<T> getHead() {
        return head;
    }

    public SinglyLinkedList() {
        this.head = null;
    }

    public void add(T data) {
        if (head == null) {
            head = new SinglyNode<>(data);
        } else {
            SinglyNode<T> newNode = new SinglyNode<>(data);
            SinglyNode<T> current = head;
            while (current.next != null) {
                current = current.next;
            }
            current.next = newNode;
        }
    }

    public void add(List<T> list) {
        for (var i : list) {
            add(i);
        }
    }

    public void display() {
        var current = head;
        while (current != null) {
            if (current.next == null) {
                System.out.println(current.data);
            } else {
                System.out.print(current.data + "->");
            }
            current = current.next;
        }
    }

    //    R􀂧mov􀂧 Dups! Write code to remove duplicates from an unsorted linked list.
    //    FOLLOW UP
    //    How would you solve this problem if a temporary buffer is not allowed?
    public void removeDuplicates() {
        HashSet<T> set = new HashSet<T>();
        var current = head;
        SinglyNode<T> prev = null;
        while (current != null) {
            if (set.contains(current.data)) {
                prev.next = current.next;
            } else {
                set.add(current.data);
                prev = current;
            }
            current = current.next;
        }
    }

    // Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.
    public T getKthLast(int k) {
        var first = head;
        var second = head;
        for (int i = 0; i < k; i++) {
            if (first == null) return null;
            first = first.next;
        }
        while (first != null) {
            first = first.next;
            second = second.next;
        }
        assert second != null;
        return second.data;
    }


    // Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but
    // the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
    // that node.
    public void deleteMiddle() {
        var fast = head;
        var slow = head;
        SinglyNode<T> prev = null;
        while (fast != null && fast.next != null) {
            fast = fast.next.next;
            prev = slow;
            slow = slow.next;
        }
        prev.next = slow.next;
    }


    // Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
    // before all nodes greater than or equal to x. If x is contained within the list, the values of x only need
    // to be after the elements less than x (see below). The partition element x can appear anywhere in the
    // "right partition"; it does not need to appear between the left and right partitions.
    public void partition(T value) {
        SinglyNode<T> beforeStart = null;
        SinglyNode<T> afterStart = null;
        SinglyNode<T> beforeEnd = null;
        SinglyNode<T> afterEnd = null;
        SinglyNode<T> current = head;
        while (current != null) {
            SinglyNode<T> next = current.next;
            current.next = null;
            if (current.data.compareTo(value) < 0) {
                if (beforeStart == null) {
                    beforeStart = current;
                    beforeEnd = beforeStart;
                } else {
                    beforeEnd.next = current;
                    beforeEnd = current;
                }
            } else {
                if (afterStart == null) {
                    afterStart = current;
                    afterEnd = afterStart;
                } else {
                    afterEnd.next = current;
                    afterEnd = current;
                }
            }
            current = next;
        }
        if (beforeStart == null) {
            head = afterStart;
        } else {
            beforeEnd.next = afterStart;
            head = beforeStart;
        }
    }


    // Sum Lists: You have two numbers represented by a linked list, where each node contains a single
    // digit. The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
    // function that adds the two numbers and returns the sum as a linked list.
    public static SinglyNode<Integer> getSum(SinglyNode<Integer> n1, SinglyNode<Integer> n2) {
        SinglyNode<Integer> dummy = new SinglyNode<>(0);
        SinglyNode<Integer> current = dummy;
        int carry = 0;
        while (n1 != null || n2 != null || carry != 0) {
            int sum = carry;
            if (n1 != null) {
                sum += n1.data;
                n1 = n1.next;
            }
            if (n2 != null) {
                sum += n2.data;
                n2 = n2.next;
            }
            carry = sum / 10;
            current.next = new SinglyNode<>(sum % 10);
            current = current.next;
        }
        return dummy.next;
    }

    //Suppose the digits are stored in forward order. Repeat the above problem.
    public static SinglyNode<Integer> getForwordSum(SinglyNode<Integer> n1, SinglyNode<Integer> n2) {
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        SinglyNode<Integer> dummy = new SinglyNode<>(0);
        SinglyNode<Integer> current = dummy;
        while (n1 != null || n2 != null) {
            if (n1 != null) {
                sb1.append(n1.data);
                n1 = n1.next;
            }
            if (n2 != null) {
                sb2.append(n2.data);
                n2 = n2.next;
            }
        }
        int sum = Integer.parseInt(sb1.toString()) + Integer.parseInt(sb2.toString());
        List<Integer> result = new ArrayList<>();
        while (sum > 0) {
            result.add(sum % 10);
            sum /= 10;
        }
        result = result.reversed();
        for(int i : result) {
            current.next = new SinglyNode<>(i);
            current = current.next;
        }
        return dummy.next;
    }

    public static <T> void printFromHead(SinglyNode<T> head) {
        while (head != null) {
            if (head.next != null) {
                System.out.print(head.data + "->");
            } else {
                System.out.println(head.data);
            }
            head = head.next;
        }
    }

}
