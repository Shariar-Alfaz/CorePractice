//
// Created by User on 5/11/2025.
//

#include "ArrayAndString.h"
#include <algorithm>
#include <iostream>
#include <map>
#include <ranges>
#include <vector>

using namespace std;

//helper____________________
bool ArrayAndString::isSameString(const string &str_1, const string &str_2) {
    return str_1.compare(str_2) == 0;
}

int ArrayAndString::unMatchCount(const string &str_1, const string &str_2) {
    int count = 0;
    for (int i = 1; i < str_1.size(); i++) {
        if (str_1.at(i) != str_2.at(i)) count++;
    }
    return count;
}

void ArrayAndString::printMatrix(const vector<vector<int> > &matrix) {
    for (int i = 0; i < matrix.size(); i++) {
        for (int j = 0; j < matrix[i].size(); j++) {
            cout << matrix[i][j] << " ";
        }
        cout << endl;
    }
}

//helper_end____________

// Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
// cannot use additional data structures?// Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
// cannot use additional data structures?
bool ArrayAndString::isStringUnique(const string &str) {
    if (str.length() > 128) return false;
    bool isUnique[128] = {false};
    for (int i = 0; i < str.length(); i++) {
        int c = str[i];
        if (isUnique[c]) return false;
        isUnique[c] = true;
    }
    return true;
}


// Check Permutation: Given two strings, write a method to decide if one is a permutation of the
// other.
bool ArrayAndString::isPermutation(const string &str_1, const string &str_2) {
    if (str_1.length() != str_2.length()) return false;
    map<char, int> permutation;
    for (int i = 0; i < str_1.length(); i++) {
        permutation[str_1[i]]++;
    }
    for (int i = 0; i < str_2.length(); i++) {
        if (permutation[str_2[i]] == 0) return false;
        permutation[str_2[i]]--;
    }
    return true;
}


// URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
// has sufficient space at the end to hold the additional characters, and that you are given the "true"
// length of the string. (Note: If implementing in Java, please use a character array so that you can
// perform this operation in place.)
void ArrayAndString::URLify(char str[], const int &total_index) {
    int spaceCount = 0;
    for (int i = 0; i < total_index; i++) {
        if (str[i] == ' ') spaceCount++;
    }
    const int newLength = total_index + spaceCount * 2;
    str[newLength] = '\0';
    for (int i = total_index - 1, j = newLength - 1; i >= 0; i--) {
        if (str[i] == ' ') {
            str[j--] = '0';
            str[j--] = '2';
            str[j--] = '%';
        } else {
            str[j--] = str[i];
        }
    }
}


// Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
// A palindrome is a word or phrase that is the same forwards and backwards. A permutation
// is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
bool ArrayAndString::palindromePermutaion(const string &str) {
    // palindrome can be formed if all the char have even count or only one char have odd count
    vector<int> freq(26, 0);
    //calculate frequency of the string
    for (int i = 0; i < str.length(); i++) {
        freq[str[i] - 'a']++;
    }

    //now count odd chars
    int odd = 0;
    for (const auto i: freq) {
        if (i % 2 != 0) {
            odd++;
        }
    }
    if (odd > 1) return false;
    return true;
}


// One Away: There are three types of edits that can be performed on strings: insert a character,
// remove a character, or replace a character. Given two strings, write a function to check if they are
// one edit (or zero edits) away.
bool ArrayAndString::oneWay(const string &str_1, const string &str_2) {
    int str_1_length = str_1.length();
    int str_2_length = str_2.length();
    if (abs(str_1_length - str_2_length) > 1) return false;
    string sort_string = str_1_length < str_2_length ? str_1 : str_2;
    string long_string = str_1_length < str_2_length ? str_2 : str_1;
    int index_1 = 0, index_2 = 0;
    bool foundDiff = false;
    while (index_1 < sort_string.length() && index_2 < long_string.length()) {
        if (sort_string.at(index_1) != long_string.at(index_2)) {
            if (foundDiff) return false;
            foundDiff = true;
            if (str_1_length == str_2_length)
                index_1++;
        } else {
            index_1++;
        }
        index_2++;
    }
    return true;
}


// String Compression: Implement a method to perform basic string compression using the counts
// of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
// "compressed" string would not become smaller than the original string, your method should return
// the original string. You can assume the string has only uppercase and lowercase letters (a - z).
string ArrayAndString::stringCompression(const string &str) {
    string result;
    int counter = 0;
    for (int i = 0; i < str.length(); i++) {
        counter++;
        if (i + 1 >= str.length() || str[i] != str[i + 1]) {
            result += str[i] + to_string(counter);
            counter = 0;
        }
    }
    if (result.length() <= str.length()) return result;
    return str;
}


// Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
// bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
void ArrayAndString::rotateMatrix(vector<vector<int> > &matrix) {
    int matrixSize = matrix.size();
    //transpose
    for (int i = 0; i < matrixSize - 1; i++) {
        for (int j = i + 1; j < matrixSize; j++) {
            swap(matrix[i][j], matrix[j][i]);
        }
    }
    //reverse
    for (int i = 0; i < matrixSize; i++) {
        reverse(matrix[i].begin(), matrix[i].end());
    }
}

// Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
// column are set to 0.
void ArrayAndString::zeroMatrix(vector<vector<int> > &matrix) {
    int rows = matrix.size();
    int cols = matrix[0].size();

    bool firstRowHasZero = false;
    bool firstColHasZero = false;
    //check if the first row has zero
    for (int i = 0; i < cols; i++) {
        if (matrix[0][i] == 0) {
            firstRowHasZero = true;
            break;
        }
    }

    //check if the first column has zero
    for (int i = 0; i < rows; i++) {
        if (matrix[i][0] == 0) {
            firstColHasZero = true;
            break;
        }
    }

    //user first row and column as marker
    for (int i = 1; i < rows; i++) {
        for (int j = 1; j < cols; j++) {
            if (matrix[i][j] == 0) {
                matrix[i][0] = 0;
                matrix[0][j] = 0;
            }
        }
    }

    // now set the matrix cell to 0 based on the first row and column
    for (int i = 1; i < rows; i++) {
        for (int j = 1; j < cols; j++) {
            if (matrix[i][0] == 0 || matrix[0][j] == 0) {
                matrix[i][j] = 0;
            }
        }
    }

    if (firstRowHasZero) {
        for (int i = 0; i < cols; i++) {
            matrix[0][i] = 0;
        }
    }

    if (firstColHasZero) {
        for (int i = 0; i < rows; i++) {
            matrix[i][0] = 0;
        }
    }
}

// String Rotation:Assumeyou have a method isSubstringwhich checks if one word is a substring
// of another. Given two strings, sl and s2, write code to check if s2 is a rotation of sl using only one
// call to isSubstring (e.g., "waterbottle" is a rotation of"erbottlewat").
bool ArrayAndString::isSubstring(const string &str_1, const string &str_2) {
    return str_1.find(str_2) != string::npos;
}

bool ArrayAndString::isRotation(const string &str_1, const string &rotated) {
    if (str_1.length() != rotated.length() || str_1.empty()) return false;
    string combined = str_1 + str_1;
    return isSubstring(combined, rotated);
}
