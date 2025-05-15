//
// Created by User on 5/14/2025.
//

#ifndef SINGLYNODE_H
#define SINGLYNODE_H

namespace LinkList {
    template<typename T>
    class SinglyNode {
    public:
        T data;
        SinglyNode<T> *next;

         explicit SinglyNode(const T &value): data(value), next(nullptr) {
        }
    };
} // LinkList

#endif //SINGLYNODE_H
