#include <iostream>

#include "ArrayAndString/ArrayAndString.h"
#include "LinkedList/SinglyLinkedList.h"
using namespace std;
using namespace LinkList;
// TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
int main() {
    // TIP Press <shortcut actionId="RenameElement"/> when your caret is at the <b>lang</b> variable name to see how CLion can help you rename it.
    ArrayAndString arrayAndString;
    string str = "Hello World!";
    bool is_string_unique = arrayAndString.isStringUnique(str);
    cout << "is_string_unique: " << is_string_unique << endl;


    string permutation_test1 = "AABC", permutation_test2 = "AAAB";
    bool is_permutate = arrayAndString.isPermutation(permutation_test1, permutation_test2);
    cout << "is_permutate: " << is_permutate << endl;


    char str_1[100] = "Mr John Smith    "; // 4 extra spaces to accommodate "%20"
    int trueLength = 13;
    arrayAndString.URLify(str_1, trueLength);
    cout << str_1 << endl;

    string pal = "tact coa";
    if (arrayAndString.palindromePermutaion(pal))
        cout << "palindromePermutaion: True" << endl;
    else
        cout << "palindromePermutaion: False" << endl;

    string t1 = "abcd";
    string t2 = "abdcd";
    if (arrayAndString.oneWay(t1, t2))
        cout << "oneWay: True" << endl;
    else
        cout << "oneWay: False" << endl;

    t1 = "aaabbccciiiit";
    cout << "Compressed string: " << arrayAndString.stringCompression(t1) << endl;

    vector<vector<int> > matrix = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
    cout << "Input Matrix size: " << matrix.size() << endl;
    arrayAndString.printMatrix(matrix);
    arrayAndString.rotateMatrix(matrix);
    cout << "Rotated Matrix size: " << matrix.size() << endl;
    arrayAndString.printMatrix(matrix);


    matrix = {{1, 2, 3, 2}, {4, 1, 6, 0}, {7, 8, 3, 1}};
    cout << "Input Matrix size: " << matrix.size() << endl;
    arrayAndString.printMatrix(matrix);
    arrayAndString.zeroMatrix(matrix);
    cout << "Zero Matrix size: " << matrix.size() << endl;
    arrayAndString.printMatrix(matrix);

    t1 = "waterbottle";
    t2 = "erbottlewat";
    if (arrayAndString.isRotation(t1, t2))
        cout << "Rotation: True" << endl;
    else
        cout << "Rotation: False" << endl;

    cout << "Linked list ________________________________________________________________________" << endl;

    SinglyLinkedList<int> s_l_list;
    s_l_list.insert(4);
    s_l_list.insert(5);
    s_l_list.insert(6);
    s_l_list.insert(7);
    s_l_list.insert(4);
    s_l_list.insert(5);
    s_l_list.insert(9);
    s_l_list.insert(10);
    cout << "Linked list: ";
    s_l_list.display();
    s_l_list.delete_duplicates();
    s_l_list.display();

    SinglyLinkedList<int> s;
    s.insert(4);
    s.insert(5);
    s.insert(6);
    s.insert(7);
    s.insert(4);
    s.display();
    int kth = s.get_kth_lastElement(2);
    cout << "kth: " << kth << endl;
    s.delete_middle();
    cout << "middle deleted: ";
    s.display();

    SinglyLinkedList<int> s2;
    s2.insert({2, 3, 5, 2, 1, 8, 9, 1});
    s2.display();
    s2.partition(5);
    cout << "partitioned: ";
    s2.display();

    SinglyLinkedList<int> f1;
    f1.insert({2, 3, 5, 2, 1, 8, 9, 1});
    f1.display();
    SinglyLinkedList<int> f2;
    f2.insert({2, 3, 5, 2, 1, 8, 9});
    f2.display();
    cout <<"Sum:" << endl;
    f1.printFromHead(SinglyLinkedList<int>::sum_list(f1.getHead(),f2.getHead()));


    SinglyLinkedList<int> f3;
    f3.insert({2, 3, 5, 2, 1, 8, 9, 1});
    f3.display();
    SinglyLinkedList<int> f4;
    f4.insert({2, 3, 5, 2, 1, 8, 9, 1});
    f4.display();
    cout<<"forword sum"<<endl;
    f1.printFromHead(SinglyLinkedList<int>::sum_list_forward(f3.getHead(),f4.getHead()));
    return 0;
}
