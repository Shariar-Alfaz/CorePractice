class SinglyNode:
    def __init__(self, data):
        self.data = data
        self.next = None

class SinglyLinkedList:
    def __init__(self):
        self.head = None

    def get_head(self)-> SinglyNode:
        return self.head
    
    def append(self, data):
        new_node = SinglyNode(data)
        if not self.head:
            self.head = new_node
            return
        last_node = self.head
        while last_node.next:
            last_node = last_node.next
        last_node.next = new_node
    
    def append_list(self, data:list):
        for i in data:
            self.append(i)

    def print_list(self):
        current_node = self.head
        while current_node:
            if current_node.next is None:
                print(current_node.data, end="")
            else:
                print(current_node.data, end=" -> ")
            current_node = current_node.next

    def delete_duplicates(self):
        current_node = self.head
        prev_node = None
        seen = set()
        while current_node:
            if current_node.data in seen:
                prev_node.next = current_node.next
            else:
                seen.add(current_node.data)
                prev_node = current_node
            current_node = current_node.next

    #Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.
    def kth_to_last(self, k):
        p1 = self.head
        p2 = self.head
        for i in range(k):
            if p1 is None:
                return None
            p1 = p1.next
        while p1:
            p1 = p1.next
            p2 = p2.next

        return p2.data if p2 else None
    
    # // Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but
    # // the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
    # // that node.
    def delete_middle_node(self):
        fast = self.head
        slow = self.head
        prev = None
        while fast and fast.next:
            fast = fast.next.next
            prev = slow
            slow = slow.next
        if prev:
            prev.next = slow.next


    # // Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
    # // before all nodes greater than or equal to x. If x is contained within the list, the values of x only need
    # // to be after the elements less than x (see below). The partition element x can appear anywhere in the
    # // "right partition"; it does not need to appear between the left and right partitions.
    def partition(self, x):
        before_head = None
        before_end = None
        after_head = None
        after_end = None
        current = self.head
        while current:
            next_node = current.next
            current.next = None
            if(current.data < x):
                if before_head is None:
                    before_head = current
                    before_end = before_head
                else:
                    before_end.next = current
                    before_end = current
            else:
                if after_head is None:
                    after_head = current
                    after_end = after_head
                else:
                    after_end.next = current
                    after_end = current
            current = next_node
        if before_head is None:
            self.head = after_head
        else:
            before_end.next = after_head
            self.head = before_head

    # // Sum Lists: You have two numbers represented by a linked list, where each node contains a single
    # // digit. The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
    # // function that adds the two numbers and returns the sum as a linked list.
    @staticmethod
    def sum_lists(l1:SinglyNode, l2:SinglyNode)-> SinglyNode:
        dummy_head = SinglyNode(0)
        current = dummy_head
        carry = 0
        while l1 or l2 or carry!=0:
            sum = carry
            if l1:
                sum += l1.data
                l1 = l1.next
            if l2:
                sum += l2.data
                l2 = l2.next
            carry = sum // 10
            current.next = SinglyNode(sum % 10)
            current = current.next
        return dummy_head.next
    
    @staticmethod
    def print_from_node(node:SinglyNode):
        current_node = node
        while current_node:
            if current_node.next is None:
                print(current_node.data, end="")
            else:
                print(current_node.data, end=" -> ")
            current_node = current_node.next

    #Suppose the digits are stored in forward order. Repeat the above problem.
    @staticmethod
    def sum_lists_forward(l1:SinglyNode, l2:SinglyNode)-> SinglyNode:
        num1:str = ""
        num2:str = ""
        while l1 or l2:
            if l1:
                num1 += str(l1.data)
                l1 = l1.next
            if l2:
                num2 += str(l2.data)
                l2 = l2.next
        sum = int(num1) + int(num2)
        dummy_head = SinglyNode(0)
        current = dummy_head
        result = list()
        while sum > 0:
            result.append(sum % 10)
            sum //= 10
        result.reverse()
        for i in result:
            current.next = SinglyNode(i)
            current = current.next
        return dummy_head.next
        