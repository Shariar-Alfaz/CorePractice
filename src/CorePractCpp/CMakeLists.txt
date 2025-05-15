cmake_minimum_required(VERSION 3.31)
project(CorePractCpp)

set(CMAKE_CXX_STANDARD 20)

add_executable(CorePractCpp main.cpp
        ArrayAndString/ArrayAndString.cpp
        ArrayAndString/ArrayAndString.h
        LinkedList/SinglyNode.cpp
        LinkedList/SinglyNode.h
        LinkedList/SinglyLinkedList.cpp
        LinkedList/SinglyLinkedList.h
)
