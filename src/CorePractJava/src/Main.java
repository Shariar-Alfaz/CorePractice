import ArrayAndString.ArrayAndStringSol;
import LinkedList.SinglyLinkedList;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        //TIP Press <shortcut actionId="ShowIntentionActions"/> with your caret at the highlighted text
        // to see how IntelliJ IDEA suggests fixing it.

        // array and string
        var arrayAndString = new ArrayAndStringSol();
        System.out.println(arrayAndString.isUniqueString("asdasadsfa"));


        System.out.println(arrayAndString.isPermutation("asdasadsfa", "dsasaadsaf"));


        char[] sample = "My name is Alen Shopon        ".toCharArray();
        arrayAndString.URLify(sample, sample.length - 8);
        System.out.println(sample);

        String ppTest = "dac dac";
        if (arrayAndString.palindromePermutation(ppTest))
            System.out.println("Palindrome Permutation: True");
        else
            System.out.println("Palindrome Permutation: False");

        if (arrayAndString.oneWay("pale", "ple"))
            System.out.println("One Away: True");
        else
            System.out.println("One Away: False");

        ppTest = "aaacccBBBaaisaaaay";
        System.out.println(arrayAndString.compressString(ppTest));

        int[][] matrix = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
        System.out.println("Matrix: " + Arrays.deepToString(matrix));
        arrayAndString.printMatrix(matrix);
        arrayAndString.rotateMatrix(matrix);
        System.out.println("Matrix: " + Arrays.deepToString(matrix));
        arrayAndString.printMatrix(matrix);

        matrix = new int[][]{{1, 2, 3}, {4, 5, 6}, {7, 0, 9}};
        System.out.println("Matrix: " + Arrays.deepToString(matrix));
        arrayAndString.printMatrix(matrix);
        arrayAndString.zeroMatrix(matrix);
        System.out.println("Matrix: " + Arrays.deepToString(matrix));
        arrayAndString.printMatrix(matrix);

        String t1 = "hello";
        String t2 = "llohe";
        System.out.println("Rotation: " + arrayAndString.isRotation(t1, t2));

        System.out.println("Linked List_________________________");
        SinglyLinkedList<Integer> singlyLinkedList = new SinglyLinkedList<Integer>();
        singlyLinkedList.add(1);
        singlyLinkedList.add(2);
        singlyLinkedList.add(3);
        singlyLinkedList.add(4);
        singlyLinkedList.add(5);
        singlyLinkedList.add(6);
        singlyLinkedList.add(7);
        singlyLinkedList.add(7);
        singlyLinkedList.add(7);
        singlyLinkedList.add(7);
        singlyLinkedList.add(8);
        singlyLinkedList.add(8);
        singlyLinkedList.add(9);
        singlyLinkedList.add(1);
        singlyLinkedList.display();
        singlyLinkedList.removeDuplicates();
        singlyLinkedList.display();

        singlyLinkedList = new SinglyLinkedList<>();
        singlyLinkedList.add(1);
        singlyLinkedList.add(2);
        singlyLinkedList.add(3);
        singlyLinkedList.add(4);
        singlyLinkedList.add(5);
        singlyLinkedList.display();
        var kth = singlyLinkedList.getKthLast(5);
        System.out.println("kth: " + kth);
        singlyLinkedList.deleteMiddle();
        System.out.println("middle deleted");
        singlyLinkedList.display();

        singlyLinkedList = new SinglyLinkedList<>();
        List<Integer> list = new ArrayList<>();
        list = Arrays.asList(1, 2, 3, 5, 1, 2, 3, 6, 8, 2);
        singlyLinkedList.add(list);
        singlyLinkedList.display();
        System.out.println("Partition");
        singlyLinkedList.partition(5);
        singlyLinkedList.display();

        var s1 = new SinglyLinkedList<Integer>();
        s1.add(Arrays.asList(4, 6, 2, 4, 8, 1, 3, 0, 9));
        s1.display();
        var s2 = new SinglyLinkedList<Integer>();
        s2.add(Arrays.asList(4, 6, 2, 4, 8, 1, 3, 0, 9));
        s2.display();
        System.out.println("Sum");
        SinglyLinkedList.printFromHead(SinglyLinkedList.getSum(s1.getHead(), s2.getHead()));

    }
}