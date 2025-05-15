package ArrayAndString;

import java.util.Arrays;
import java.util.HashMap;

public class ArrayAndStringSol {

    //tools____________________
    public void printMatrix(int[][] matrix) {
        for (int[] row : matrix) {
            for (int val : row) {
                System.out.print(val + " ");
            }
            System.out.println();
        }
    }

    //end_TOOLS________________
    // Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
    // cannot use additional data structures?
    public boolean isUniqueString(String str) {
        if (str.length() > 128) return false;
        boolean[] isUnique = new boolean[128];
        for (int i = 0; i < str.length(); i++) {
            int var = str.charAt(i);
            if (isUnique[var]) return false;
            isUnique[var] = true;
        }
        return true;
    }

    //    Check Permutation: Given two strings, write a method to decide if one is a permutation of the
    //    other.
    public boolean isPermutation(String str1, String str2) {
        if (str1.length() != str2.length()) return false;
        HashMap<Character, Integer> permutation = new HashMap<>();
        for (char c : str1.toCharArray()) {
            permutation.put(c, permutation.getOrDefault(c, 0) + 1);
        }
        for (char c : str2.toCharArray()) {
            if (permutation.getOrDefault(c, 0) == 0) return false;
            permutation.put(c, permutation.get(c) - 1);
        }
        return true;
    }

    // URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
    // has sufficient space at the end to hold the additional characters, and that you are given the "true"
    // length of the string. (Note: If implementing in Java, please use a character array so that you can
    // perform this operation in place.)
    public void URLify(char[] str, int trueLen) {
        int totalSpace = 0;
        for (int i = 0; i < trueLen; i++) {
            if (str[i] == ' ') totalSpace++;
        }

        int finalLen = trueLen + totalSpace * 2;
        str[finalLen - 1] = '\0';
        for (int i = trueLen - 1, j = finalLen - 1; i >= 0; i--) {
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
    public boolean palindromePermutation(String str) {
        String lower = str.toLowerCase();
        int[] frequency = new int[128];
        for (char c : lower.toCharArray()) {
            if (c != ' ')
                frequency[c]++;
        }
        frequency = Arrays.stream(frequency).filter(x -> x != 0).toArray();
        int odd = 0;
        for (var x : frequency) {
            if (x % 2 != 0) odd++;
        }
        return odd <= 1;
    }


    // One Away: There are three types of edits that can be performed on strings: insert a character,
    // remove a character, or replace a character. Given two strings, write a function to check if they are
    // one edit (or zero edits) away.
    public boolean oneWay(String str1, String str2) {
        int len1 = str1.length();
        int len2 = str2.length();

        if (Math.abs(len1 - len2) > 1) return false;

        String shortString = len1 < len2 ? str1 : str2;
        String longString = len1 < len2 ? str2 : str1;

        int index1 = 0, index2 = 0;
        boolean foundDiff = false;
        while (index1 < shortString.length() && index2 < longString.length()) {
            if (shortString.charAt(index1) != longString.charAt(index2)) {
                if (foundDiff) return false;
                foundDiff = true;
                if (len1 == len2) index1++;
            } else {
                index1++;
            }
            index2++;
        }
        return true;
    }


    // String Compression: Implement a method to perform basic string compression using the counts
    // of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
    // "compressed" string would not become smaller than the original string, your method should return
    // the original string. You can assume the string has only uppercase and lowercase letters (a - z).
    public String compressString(String str) {
        StringBuilder result = new StringBuilder();
        int counter = 0;
        for (int i = 0; i < str.length(); i++) {
            counter++;
            if (i + 1 >= str.length() || str.charAt(i) != str.charAt(i + 1)) {
                result.append(str.charAt(i)).append(counter);
                counter = 0;
            }
        }
        return result.length() <= str.length() ? result.toString() : str;
    }

    // Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
    // bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
    public void rotateMatrix(int[][] matrix) {
        int width = matrix.length;
        //transpose
        for (int i = 0; i < width - 1; i++) {
            for (int j = i + 1; j < width; j++) {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }

        // reverse
        for (int[] ints : matrix) {
            reverseRow(ints);
        }
    }

    private void reverseRow(int[] row) {
        int left = 0, right = row.length - 1;
        while (left < right) {
            int temp = row[left];
            row[left] = row[right];
            row[right] = temp;
            left++;
            right--;
        }
    }


    // Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
    // column are set to 0.
    public void zeroMatrix(int[][] matrix) {
        int rows = matrix.length;
        int cols = matrix[0].length;

        boolean isFirstRowHasZero = false;
        boolean isFirstColHasZero = false;

        // check if the first row has zero
        for (int i = 0; i < cols; i++) {
            if (matrix[0][i] == 0) {
                isFirstRowHasZero = true;
                break;
            }
        }

        // check if the first col has zero
        for (int i = 0; i < rows; i++) {
            if (matrix[i][0] == 0) {
                isFirstColHasZero = true;
                break;
            }
        }

        //use first row and col as marker
        for (int i = 1; i < rows; i++) {
            for (int j = 1; j < cols; j++) {
                if (matrix[i][j] == 0) {
                    matrix[i][0] = 0;
                    matrix[0][j] = 0;
                }
            }
        }

        // now make zero if the first row or col is zero
        for (int i = 1; i < rows; i++) {
            for (int j = 1; j < cols; j++) {
                if (matrix[i][0] == 0 || matrix[0][j] == 0) {
                    matrix[i][j] = 0;
                }
            }
        }

        if (isFirstRowHasZero) {
            for (int i = 0; i < cols; i++) {
                matrix[0][i] = 0;
            }
        }

        if (isFirstColHasZero) {
            for (int i = 0; i < rows; i++) {
                matrix[i][0] = 0;
            }
        }
    }


    // String Rotation:Assumeyou have a method isSubstringwhich checks if one word is a substring
    // of another. Given two strings, sl and s2, write code to check if s2 is a rotation of sl using only one
    // call to isSubstring (e.g., "waterbottle" is a rotation of"erbottlewat").
    public boolean isSubstring(String str1, String str2) {
        return str1.contains(str2);
    }

    public boolean isRotation(String str1, String rotation) {
        if(str1.length() != rotation.length() || str1.isEmpty()) return false;
        String combine = str1 + str1;
        return isSubstring(combine, str1);
    }
}