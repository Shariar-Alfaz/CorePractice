//
// Created by User on 5/11/2025.
//

#ifndef ARRAYANDSTRING_H
#define ARRAYANDSTRING_H
#include <string>
#include <vector>
using namespace std;

class ArrayAndString {
public:
    bool isStringUnique(const string &str);

    bool isPermutation(const string &str_1, const string &str_2);

    void URLify(char str[], const int &total_index);

    bool palindromePermutaion(const string &str);

    bool oneWay(const string &str_1, const string &str_2);

    string stringCompression(const string &str);

    void rotateMatrix(vector<vector<int> > &matrix);

    void printMatrix(const vector<vector<int> > &matrix);

    void zeroMatrix(vector<vector<int> > &matrix);

    bool isRotation(const string &str_1, const string &rotated);

    bool isSubstring(const string &str_1, const string &str_2);

private:
    bool isSameString(const string &str_1, const string &str_2);

    int unMatchCount(const string &str_1, const string &str_2);
};


#endif //ARRAYANDSTRING_H
