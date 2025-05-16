//
// Created by User on 5/14/2025.
//

#ifndef SINGLYLINKEDLIST_H
#define SINGLYLINKEDLIST_H
#include <algorithm>

#include "SinglyNode.h"
#include <iostream>
#include <map>
#include <vector>
using namespace std;

namespace LinkList {
    template<typename T>
    class SinglyLinkedList {
    private:
        SinglyNode<T> *head;

    public:
        SinglyLinkedList(): head(nullptr) {
        }

        void printFromHead(SinglyNode<T> *node) {
            while (node) {
                if (node->next)
                    cout << node->data << " -> ";
                else
                    cout << node->data << endl;
                node = node->next;
            }
        }

        SinglyNode<T> *getHead() {
            return head;
        }

        void insert(const T &value) {
            auto *newNode = new SinglyNode<T>(value);
            if (!head) {
                head = newNode;
            } else {
                auto *temp = head;
                while (temp->next)
                    temp = temp->next;
                temp->next = newNode;
            }
        }

        void insert(const vector<T> &data) {
            for (const auto &value: data) {
                insert(value);
            }
        }

        void display() {
            SinglyNode<T> *temp = head;
            while (temp) {
                if (temp->next)
                    cout << temp->data << " -> ";
                else
                    cout << temp->data << endl;
                temp = temp->next;
            }
        }

        //R􀂧mov􀂧 Dups! Write code to remove duplicates from an unsorted linked list.
        // FOLLOW UP
        // How would you solve this problem if a temporary buffer is not allowed?
        void delete_duplicates() {
            map<int, int> checker;
            auto *temp = head;
            SinglyNode<T> *prev;
            while (temp) {
                if (checker.contains(temp->data)) {
                    prev->next = temp->next;
                } else {
                    checker.insert({temp->data, temp->data});
                    prev = temp;
                }
                temp = temp->next;
            }
        }

        // Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.
        T get_kth_lastElement(const int &k) {
            auto first = head;
            auto second = head;

            for (int i = 0; i < k; i++) {
                if (!first) return 0;
                first = first->next;
            }
            while (first) {
                first = first->next;
                second = second->next;
            }
            return second->data;
        }

        // Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but
        // the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
        // that node.
        void delete_middle() {
            auto p1 = head;
            auto p2 = head;
            SinglyNode<T> *prev = nullptr;
            while (p1 && p1->next != nullptr) {
                p1 = p1->next->next;
                prev = p2;
                p2 = p2->next;
            }
            prev->next = p2->next;
            delete p2;
        }


        // Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
        // before all nodes greater than or equal to x. If x is contained within the list, the values of x only need
        // to be after the elements less than x (see below). The partition element x can appear anywhere in the
        // "right partition"; it does not need to appear between the left and right partitions.
        void partition(T value) {
            SinglyNode<T> *beforeStart = nullptr;
            SinglyNode<T> *beforeEnd = nullptr;
            SinglyNode<T> *afterStart = nullptr;
            SinglyNode<T> *afterEnd = nullptr;

            SinglyNode<T> *current = head;

            while (current != nullptr) {
                SinglyNode<T> *next = current->next;
                current->next = nullptr;

                if (current->data<value) {
                    if (beforeStart == nullptr) {
                        beforeStart = current;
                        beforeEnd = beforeStart;
                    } else {
                        beforeEnd->next = current;
                        beforeEnd = current;
                    }
                } else {
                    if (afterStart == nullptr) {
                        afterStart = current;
                        afterEnd = afterStart;
                    } else {
                        afterEnd->next = current;
                        afterEnd = current;
                    }
                }

                current = next;
            }

            if (beforeStart == nullptr) {
                head = afterStart;
            } else {
                beforeEnd->next = afterStart;
                head = beforeStart;
            }
        }

        // Sum Lists: You have two numbers represented by a linked list, where each node contains a single
        // digit. The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a
        // function that adds the two numbers and returns the sum as a linked list.
        static SinglyNode<int> *sum_list(SinglyNode<int> *node_1, SinglyNode<int> *node_2) {
            SinglyNode<int> *dummyHead = new SinglyNode<int>(0);
            SinglyNode<int> *current = dummyHead;
            int carry = 0;
            while (node_1 || node_2 || carry != 0) {
                int sum = carry;
                if (node_1) {
                    sum += node_1->data;
                    node_1 = node_1->next;
                }
                if (node_2) {
                    sum += node_2->data;
                    node_2 = node_2->next;
                }
                carry = sum / 10;
                current->next = new SinglyNode<int>(sum % 10);
                current = current->next;
            }
            return dummyHead->next;
        }

        //Suppose the digits are stored in forward order. Repeat the above problem.
        static SinglyNode<int> *sum_list_forward(SinglyNode<int> *node_1, SinglyNode<int> *node_2) {
            string node_1_data;
            string node_2_data;
            SinglyNode<int> *dummyHead = new SinglyNode<int>(0);
            SinglyNode<int> *current = dummyHead;
            while (node_1 || node_2) {
                if (node_1) {
                    node_1_data += to_string(node_1->data);
                    node_1 = node_1->next;
                }
                if (node_2) {
                    node_2_data += to_string(node_2->data);
                    node_2 = node_2->next;
                }
            }
            int sum = stoi(node_1_data) + stoi(node_2_data);
            vector<int> result;
            while (sum > 0) {
                result.push_back(sum % 10);
                sum /= 10;
            }

           reverse(result.begin(), result.end());
            for (int i : result) {
                current->next = new SinglyNode<int>(i);
                current = current->next;
            }
            return dummyHead->next;
        }

        ~SinglyLinkedList() {
            while (head) {
                auto temp = head;
                head = head->next;
                delete temp;
            }
        }
    };
} // LinkList

#endif //SINGLYLINKEDLIST_H
