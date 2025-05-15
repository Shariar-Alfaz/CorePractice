using System.Text;

namespace ArrayAndString
{
    public class ArrayAndStringSol
    {
        #region tools
        public void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion
        // Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
        // cannot use additional data structures?
        public bool IsUniqueString(string str)
        {
            if (str.Length > 128) return false;
            var isUnique = new bool[128];
            for (int i = 0; i < str.Length; i++)
            {
                int val = str[i];
                if (isUnique[val]) return false;
                isUnique[val] = true;
            }
            return true;
        }

        //Check Permutation: Given two strings, write a method to decide if one is a permutation of the
        //other.
        public bool IsPermutation(string a, string b)
        {
            if (a.Length != b.Length) return false;
            Dictionary<char, int> permutation = new();
            foreach (char item in a)
            {
                if (permutation.ContainsKey(item))
                    permutation[item]++;
                else
                    permutation.Add(item, 1);
            }

            foreach (char item in b)
            {
                if (permutation.TryGetValue(item, out int val) || val == 0) return false;
                permutation[item]--;
            }
            return true;
        }

        // URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
        // has sufficient space at the end to hold the additional characters, and that you are given the "true"
        // length of the string. (Note: If implementing in Java, please use a character array so that you can
        // perform this operation in place.)
        public void URLify(char[] str, int trueLength)
        {
            int spaceCount = 0;
            for (int i = 0; i < trueLength; i++)
                if (str[i] == ' ') spaceCount++;

            int newLength = trueLength + spaceCount * 2;
            for (int i = trueLength - 1, j = newLength - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    str[j--] = '0';
                    str[j--] = '2';
                    str[j--] = '%';
                }
                else
                    str[j--] = str[i];
            }
        }

        //Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
        //A palindrome is a word or phrase that is the same forwards and backwards.A permutation
        //is a rearrangement of letters.The palindrome does not need to be limited to just dictionary words.
        public bool IsPalindromePermutation(string str)
        {
            Dictionary<char, int> charCount = new();
            foreach (char c in str)
            {
                if (c != ' ')
                {
                    var n = char.ToLower(c);
                    if (charCount.ContainsKey(n))
                        charCount[n]++;
                    else
                        charCount.Add(n, 1);
                }
            }
            int oddCount = 0;
            foreach (var count in charCount.Values)
            {
                if (count % 2 != 0)
                    oddCount++;
                if (oddCount > 1) return false;
            }
            return true;
        }

        // One Away: There are three types of edits that can be performed on strings: insert a character,
        // remove a character, or replace a character. Given two strings, write a function to check if they are
        // one edit (or zero edits) away.
        public bool OneWay(string str1, string str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;

            if (Math.Abs(len1 - len2) > 1) return false;

            string shorter = len1 < len2 ? str1 : str2;
            string longer = len1 < len2 ? str2 : str1;

            int index1 = 0, index2 = 0;

            bool foundDifference = false;

            while (index1 < shorter.Length && index2 < longer.Length)
            {
                if (shorter[index1] != longer[index2])
                {
                    if (foundDifference) return false;
                    foundDifference = true;
                    if (len1 == len2) index1++; // If lengths are the same, move shorter pointer
                }
                else
                {
                    index1++; // If matching, move shorter pointer
                }
                index2++; // Always move pointer for longer string
            }
            return true;
        }


        // String Compression: Implement a method to perform basic string compression using the counts
        // of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
        // "compressed" string would not become smaller than the original string, your method should return
        // the original string. You can assume the string has only uppercase and lowercase letters (a - z).
        public string StringCompression(string str)
        {
            StringBuilder compressed = new();
            int countConsecutive = 0;
            for (int i = 0; i < str.Length; i++)
            {
                countConsecutive++;
                if (i + 1 >= str.Length || str[i] != str[i + 1])
                {
                    compressed.Append(str[i]);
                    compressed.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }
            return compressed.Length <= str.Length ? compressed.ToString() : str;
        }

        // Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
        // bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
        public void RotateMatrix(int[,] matrix)
        {
            int length = matrix.GetLength(0);
            // Transpose the matrix
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = temp;
                }
            }

            // Reverse each row
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length / 2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, length - 1 - j];
                    matrix[i, length - 1 - j] = temp;
                }
            }
        }


        // Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
        // column are set to 0.
        public void ZeroMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            bool firstRowZero = false;
            bool firstColZero = false;

            // Check if first row has any zeros
            for (int i = 0; i < cols; i++)
            {
                if (matrix[0, i] == 0)
                {
                    firstRowZero = true;
                    break;
                }
            }

            // Check if first column has any zeros
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, 0] == 0)
                {
                    firstColZero = true;
                    break;
                }
            }

            // Use first row and column to mark zeros
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }

            // Set marked rows and columns to zero
            for (int i = 1; i < rows; i++)
            {
                for (int j = 1; j < cols; j++)
                {
                    if (matrix[i, 0] == 0 || matrix[0, j] == 0)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            if (firstRowZero)
            {
                for (int i = 0; i < cols; i++)
                {
                    matrix[0, i] = 0;
                }
            }

            if (firstColZero)
            {
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, 0] = 0;
                }
            }
        }


        // String Rotation:Assumeyou have a method isSubstringwhich checks if one word is a substring
        // of another. Given two strings, sl and s2, write code to check if s2 is a rotation of sl using only one
        // call to isSubstring (e.g., "waterbottle" is a rotation of"erbottlewat").
        public bool IsSubString(string str1, string str2)
        {
            return str1.Contains(str2);
        }

        public bool IsRotation(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;
            string concatenated = str1 + str1;
            return IsSubString(concatenated, str2);
        }
    }
}
