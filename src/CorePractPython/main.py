from ArrayAndString.arrayAndStringSol import ArrayAndString as a_s


array_and_string = a_s()
# Test is_unique
print(array_and_string.is_unique("abcdefg"))  # True

#Test check_permutation
print(array_and_string.check_permutation("abc", "cba"))  # True


str = list("Mr John Smith    ")
true_length = 13
array_and_string.urlify(str, true_length)
print("".join(str))  # "Mr%20John%20Smith"


# Test palindrome_permutation
print(array_and_string.palindrome_permutation("Tact Coa"))  # True
print(array_and_string.palindrome_permutation("abc"))  # False 
print(array_and_string.palindrome_permutation("aabbcc"))  # True


# Test one_away
print("one_away")
print(array_and_string.one_away("pale", "ple"))  # True
print(array_and_string.one_away("pales", "pale"))  # True
print(array_and_string.one_away("pale", "bale"))  # True
print(array_and_string.one_away("pale", "bake"))  # False
print(array_and_string.one_away("pale", "pales"))  # False


# Test string_compression
print("string_compression")
print(array_and_string.string_compression("aabcccccaaa"))  # a2b1c5a3
print(array_and_string.string_compression("abc"))  # abc
print(array_and_string.string_compression("aabbcc"))  # a2b2c2
print(array_and_string.string_compression("a"))  # a
print(array_and_string.string_compression("aabbccddeee"))  # a2b2c2d2e3

# Test rotate_matrix
print("rotate_matrix")
matrix = [
    [1, 2, 3],
    [4, 5, 6],  
    [7, 8, 9]
]
print("Original matrix:")
array_and_string.print_matrix(matrix)
array_and_string.rotate_matrix(matrix)
print("Rotated matrix:")
array_and_string.print_matrix(matrix)

# Test zero_matrix
print("zero_matrix")
matrix = [
    [1, 2, 3],
    [4, 0, 6],
    [7, 8, 9]
]
print("Original matrix:")
array_and_string.print_matrix(matrix)
array_and_string.zero_matrix(matrix)
print("Zeroed matrix:")
array_and_string.print_matrix(matrix)

# Test string_rotation
print("string_rotation")
print(array_and_string.string_rotation("waterbottle", "erbottlewat"))  # True
print(array_and_string.string_rotation("waterbottle", "bottlewater"))  # TRUE
print(array_and_string.string_rotation("abc", "cba"))  # TRUE
print(array_and_string.string_rotation("abc", "ab"))  # False
print(array_and_string.string_rotation("abc", "abc"))  # True
print(array_and_string.string_rotation("abc", "a"))  # False
print(array_and_string.string_rotation("abc", "acb"))  # False

print("LinkedList")
# Test SinglyLinkedList
from LinkedList.linkedListSol import SinglyLinkedList

linked_list = SinglyLinkedList()
linked_list.append(1)
linked_list.append(2)
linked_list.append(3)
linked_list.append(2)
linked_list.append(4)
linked_list.append(3)
linked_list.append(5)
print("Original linked list:")
linked_list.print_list()
linked_list.delete_duplicates()
print("\nLinked list after removing duplicates:")
linked_list.print_list()

# Test kth_to_last
print("\nkth_to_last")
k = 2
result = linked_list.kth_to_last(k)
print(f"The {k}th to last element is: {result}")  # 4
k = 1
result = linked_list.kth_to_last(k)
print(f"The {k}th to last element is: {result}")  # 5
k = 3
result = linked_list.kth_to_last(k)
print(f"The {k}th to last element is: {result}")  # 3

# Test delete_middle_node
print("\ndelete_middle_node")
linked_list.delete_middle_node()
linked_list.print_list()  # 1 -> 2 -> 4 -> 5

# Test partition
print("\npartition")
linked_list = SinglyLinkedList()
linked_list.append_list([3,2,4,5,6,2,1,8,9])
linked_list.print_list()
x = 5
linked_list.partition(x)
print(f"\nLinked list after partitioning around {x}:")
linked_list.print_list()  # 3 -> 2 -> 4 -> 2 -> 1 -> 5 -> 6 -> 8 -> 9

# Test sum_lists
print("\nsum_lists")
l1 = SinglyLinkedList()
l2 = SinglyLinkedList()
l1.append_list([7, 1, 6])  # Represents the number 617
l2.append_list([5, 9, 2])  # Represents the number 295
print("List 1:")
l1.print_list()  # 7 -> 1 -> 6
print("\nList 2:")
l2.print_list()  # 5 -> 9 -> 2
result = SinglyLinkedList.sum_lists(l1.get_head(), l2.get_head())
print("\nSum of the two lists:")
SinglyLinkedList.print_from_node(result)  # 2 -> 1 -> 9 -> 1 (represents the number 912)
