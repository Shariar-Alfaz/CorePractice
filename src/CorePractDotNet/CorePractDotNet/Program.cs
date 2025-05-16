// See https://aka.ms/new-console-template for more information
using ArrayAndString;
using LinkedList;

#region ArrayAndString

Console.WriteLine("Hello, World!");
ArrayAndStringSol arrayAndString = new();
//Array and string
// 1. Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
// cannot use additional data structures?

Console.WriteLine(arrayAndString.IsUniqueString("abcdefg"));

//Check Permutation: Given two strings, write a method to decide if one is a permutation of the
//other.
Console.WriteLine(arrayAndString.IsPermutation("abcde", "edcba"));

// URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
// has sufficient space at the end to hold the additional characters, and that you are given the "true"
// length of the string. (Note: If implementing in Java, please use a character array so that you can
// perform this operation in place.)
char[] str = "Mr John Smith    ".ToCharArray();
int trueLength = 13;
arrayAndString.URLify(str, trueLength);
Console.WriteLine(str);

// Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
// A palindrome is a word or phrase that is the same forwards and backwards. A permutation is a rearrangement
// of the letters. The palindrome does not need to be limited to just dictionary words.
Console.WriteLine(arrayAndString.IsPalindromePermutation("Tact Coa"));
// Expected output: true (permutations: "taco cat", "atco eta", etc.)

// One Away: There are three types of edits that can be performed on strings: insert a character, remove a
// character, or replace a character. Given two strings, write a function to check if they are one edit (or
// zero edits) away.
Console.WriteLine("OneWay");
Console.WriteLine(arrayAndString.OneWay("pale", "ple")); // true
Console.WriteLine(arrayAndString.OneWay("pales", "pale")); // true
Console.WriteLine(arrayAndString.OneWay("pale", "bale")); // true
Console.WriteLine(arrayAndString.OneWay("pale", "bake")); // false

// String Compression: Implement a method to perform basic string compression using the counts
// of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
// "compressed" string would not become smaller than the original string, your method should return
// the original string. You can assume the string has only uppercase and lowercase letters (a - z).
Console.WriteLine(arrayAndString.StringCompression("aabcccccaaa")); // a2b1c5a3

// Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
// bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
int[,] matrix = new int[,]
{
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};
arrayAndString.PrintMatrix(matrix);
Console.WriteLine("Rotated Matrix:");
arrayAndString.RotateMatrix(matrix);
arrayAndString.PrintMatrix(matrix);

//Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
//column are set to 0. Do it in place.
int[,] zeroMatrix = new int[,]
{
    { 1, 2, 3, 0 },
    { 4, 5, 6, 7 },
    { 8, 9, 10, 11 }
};
Console.WriteLine("Original Matrix:");
arrayAndString.PrintMatrix(zeroMatrix);
arrayAndString.ZeroMatrix(zeroMatrix);
Console.WriteLine("Zero Matrix:");
arrayAndString.PrintMatrix(zeroMatrix);

// String Rotation: Assume you have a method isSubstring which checks if one word is a substring of another.
// Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one call to
// isSubstring (i.e., "waterbottle" is a rotation of "erbottlewat").
string s1 = "waterbottle";
string s2 = "erbottlewat";
Console.WriteLine(arrayAndString.IsRotation(s1, s2)); // true
s1 = "hello";
s2 = "world";
Console.WriteLine(arrayAndString.IsRotation(s1, s2)); // false

#endregion

#region LinkedList

Console.WriteLine("LinkedList");
SinglyLinkedList<int> list = new();
list.Add(1, 2, 3, 4, 5, 2, 1, 3, 4, 6, 8, 1, 8, 3, 5, 6);
list.Print();
list.RemoveDuplicates();
Console.WriteLine("After removing duplicates:");
list.Print();
Console.WriteLine("Kth to last element:" + list.GetKthLast(2));

list.DeleteMiddle();
Console.WriteLine("After deleting middle node:");
list.Print();

// Partition: Write code to partition a linked list around a value x, such that all nodes less than x
// come before all nodes greater than or equal to x. If x is contained within the list, the values of x
// only need to be after the elements less than x (see below). The partition element x can appear anywhere
// in the "right partition"; it does not need to appear between the left and right partitions.
int partitionValue = 5;
SinglyLinkedList<int> partitionedList = new();
partitionedList.Add(3, 2, 6, 1, 8, 5, 4, 7);
Console.WriteLine("Original List:");
partitionedList.Print();
partitionedList.Partition(partitionValue);
Console.WriteLine($"List after partitioning around {partitionValue}:");
partitionedList.Print();

// Sum Lists: You have two numbers represented by a linked list, where each node contains a single digit.
// The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
// function that adds the two numbers and returns the sum as a linked list.
SinglyLinkedList<int> list1 = new();
list1.Add(7, 1, 5, 6, 1, 8, 9);
list1.Print();
SinglyLinkedList<int> list2 = new();
list2.Add(5, 9, 2);
list2.Print();
Console.WriteLine("Sum of two lists:");
SinglyLinkedList<int>.PrintFromHead(SinglyLinkedList<int>.SumList(list1.GetHead(), list2.GetHead()));

//forward

SinglyLinkedList<int> f1 = new();
f1.Add(7, 1, 5, 6, 1, 8, 9);
f1.Print();
SinglyLinkedList<int> f2 = new();
f2.Add(5, 9, 2);
f2.Print();
Console.WriteLine("Sum of two lists:");
SinglyLinkedList<int>.PrintFromHead(SinglyLinkedList<int>.SumListForward(f1.GetHead(), f2.GetHead()));
#endregion