class ArrayAndString:
    # Is Unique: Implement an algorithm to determine if a string has all unique characters. What if you
    # cannot use additional data structures?
    def is_unique(self, str: str) -> bool:
        if len(str) > 128:
            return False
        char_set = [False] * 128
        for char in str:
            val = ord(char)
            if char_set[val]:
                return False
            char_set[val] = True
        return True
    

    #Check Permutation: Given two strings, write a method to decide if one is a permutation of the
    #other.
    def check_permutation(self, str1: str, str2: str) -> bool:
        if len(str1)!=len(str2):
            return False
        permutation_dict = {}
        for char in str1:
            if char in permutation_dict:
                permutation_dict[char] += 1
            else:
                permutation_dict[char] = 1
        
        for char in str2:
            if char not in permutation_dict or permutation_dict[char] == 0:
                return False
            permutation_dict[char] -= 1
        return True


    # URLify: Write a method to replace all spaces in a string with '%20'. You may assume that the string
    # has sufficient space at the end to hold the additional characters, and that you are given the "true"
    # length of the string. (Note: If implementing in Java, please use a character array so that you can
    # perform this operation in place.)
    def urlify(self, str:list, true_length:int):
        space_count = 0

        for i in range(true_length):
            if str[i] == ' ':
                space_count += 1

        new_length = true_length + space_count * 2
        i = true_length - 1
        j = new_length - 1

        while i>0:
            if str[i] == ' ':
                str[j] = '0'
                str[j-1] = '2'
                str[j-2] = '%'
                j -= 3
            else:
                str[j] = str[i]
                j -= 1
            i -= 1


    # Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
    # A palindrome is a word or phrase that is the same forwards and backwards. A permutation
    # is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
    def palindrome_permutation(self, str: str) -> bool:
        char_count = {}
        for char in str:
            if char != ' ':
                char = char.lower()
                if char in char_count:
                    char_count[char] += 1
                else:
                    char_count[char] = 1
        
        odd_count = 0
        for count in char_count.values():
            if count % 2 != 0:
                odd_count += 1
        return odd_count <= 1
    

    # One Away: There are three types of edits that can be performed on strings: insert a character,
    # remove a character, or replace a character. Given two strings, write a function to check if they are
    # one edit (or zero edits) away.
    def one_away(self, str1:str, str2:str) -> bool:
        len1 = len(str1)
        len2 = len(str2)

        if abs(len1 - len2) > 1:
            return False
        
        short = str1 if len1 < len2 else str2
        long = str2 if len1 < len2 else str1

        index1 = 0
        index2 = 0
        found_difference = False

        while index1  < len(short) and index2 < len(long):
            if short[index1] != long[index2]:
                if found_difference:
                    return False
                found_difference = True
                if len(short) == len(long):
                    index1 += 1
            else:
                index1 += 1
            index2 += 1

        return True
    

    # String Compression: Implement a method to perform basic string compression using the counts
    # of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the
    # "compressed" string would not become smaller than the original string, your method should return
    # the original string. You can assume the string has only uppercase and lowercase letters (a - z).
    def string_compression(self, s: str) -> str:
        compressed_str = []
        count_consecutive = 0
        for i in range(len(s)):
            count_consecutive += 1
            if (i + 1 >= len(s)) or (s[i] != s[i + 1]):
                compressed_str.append(s[i])
                compressed_str.append(str(count_consecutive))
                count_consecutive = 0
        compressed_str = ''.join(compressed_str)
        return compressed_str if len(compressed_str) <= len(s) else s
    


    # Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4
    # bytes, write a method to rotate the image by 90 degrees. Can you do this in place?
    def rotate_matrix(self, matrix: list):
        n = len(matrix)
        #transpose the matrix
        for i in range(n-1):
            for j in range(i+1, n):
                matrix[i][j], matrix[j][i] = matrix[j][i], matrix[i][j]
        
        #reverse the rows
        for row in matrix:
            row.reverse()

    #print the matrix
    def print_matrix(self, matrix: list):
        for row in matrix:
            print(row)

    # Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
    # column are set to 0.
    def zero_matrix(self, matrix: list):
        rows = len(matrix)
        cols = len(matrix[0])

        first_row_zero = False
        first_col_zero = False

        for i in range(rows):
            if matrix[i][0] == 0:
                first_col_zero = True
                break

        for j in range(cols):
            if matrix[0][j] == 0:
                first_row_zero = True
                break

        for i in range(1, rows):
            for j in range(1, cols):
                if matrix[i][j] == 0:
                    matrix[i][0] = 0
                    matrix[0][j] = 0

        for i in range(1, rows):
            for j in range(1, cols):
                if matrix[i][0] == 0 or matrix[0][j] == 0:
                    matrix[i][j] = 0

        if first_col_zero:
            for i in range(rows):
                matrix[i][0] = 0
        
        if first_row_zero:
            for j in range(cols):
                matrix[0][j] = 0

    # String Rotation: Assume you have a method isSubstring which checks if one word is a substring of
    # another. Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one
    # call to isSubstring (i.e., "waterbottle" is a rotation of "erbottlewat").
    def is_substring(self, s1: str, s2: str) -> bool:
        return s2 in s1
    
    def string_rotation(self, s1: str, s2: str) -> bool:
        if len(s1) != len(s2) or len(s1) == 0:
            return False
        s1s1 = s1 + s1
        return self.is_substring(s1s1, s2)