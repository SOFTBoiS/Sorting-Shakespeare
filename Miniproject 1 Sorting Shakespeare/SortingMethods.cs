﻿using System;

namespace Miniproject_1_Sorting_Shakespeare
{
    public class SortingMethods
    {
        // This is for MergeSort
        
        
        // This index is used for triesort. This is used to remembering the idx value of where to insert sorted word into the array
        private int trieSortIdx;


        public string[] SelectionSort(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                var min = i;

                for (int j = i + 1; j < text.Length; j++)
                {
                    var res = String.Compare(text[min], text[j]);
                    if (res == 1)
                    {
                        min = j;
                    }
                }

                Swap(text, i, min);
            }

            return text;
        }

        private static void Swap(string[] text, int idxA, int idxB)
        {
            var temp = text[idxA];
            text[idxA] = text[idxB];
            text[idxB] = temp;
        }

        public string[] InsertionSort(string[] text)
        {
            for (int i = 1; i < text.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    var compareRes = String.Compare(text[j], text[j + 1]);
                    if (compareRes == 1)
                    {
                        Swap(text, j + 1, j);
                    }
                }
            }

            return text;
        }


        public String[] BUMergeSort(string[] text)
        {
            int n = text.Length;
            var aux = new String[n];
            for (int sz = 1; sz < n; sz = sz + sz)
            for (int lo = 0; lo < n - sz; lo += sz + sz)
                Merge(text, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, n - 1), aux);
            return text;
        }

        private void Merge(string[] text, int lo, int mid, int hi, string[] aux)
        {
            int i = lo, j = mid + 1;
            for (var k = lo; k <= hi; k++)
                aux[k] = text[k];

            for (var k = lo; k <= hi; k++)
            {
                if (i > mid) text[k] = aux[j++];
                else if (j > hi) text[k] = aux[i++];
                else if (String.Compare(aux[i], aux[j]) == 1) text[k] = aux[j++];
                else text[k] = aux[i++];
            }
        }

        public string[] HeapSort(string[] text)
        {
            //Make arr heap
            for (var i = text.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(text, i, text.Length);
            }

            for (var i = text.Length - 1; i >= 0; i--)
            {
                Swap(text, 0, i);
                Heapify(text, 0, i);
            }


            return text;
        }

        private void Heapify(string[] text, int i, int length)
        {
            var largest = i;
            var left = i * 2 + 1;
            var right = i * 2 + 2;

            //Check if left is out of bounds and what is largest
            if (left < length && string.Compare(text[left], text[largest]) == 1)
            {
                largest = left;
            }

            //Check if right is out of bounds and what is largest
            if (right < length && string.Compare(text[right], text[largest]) == 1)
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(text, i, largest);
                Heapify(text, largest, length);
            }
        }

        public string[] Trie(string[] text)
        {
            Node root = new Node(' ');
            foreach (var word in text)
            {
                Node node = root;
                foreach (var letter in word)
                {
                    var val = CharToIndex(letter);
                    if (node.Children[val] == null)
                    {
                        Node newNode = new Node(letter);
                        node.Children[val] = newNode;
                        node = newNode;
                    }
                    else
                    {
                        node = node.Children[val];
                    }
                }

                node.count++;
            }

            SortTrie(text, root);
            return text;
        }

        private void SortTrie(string[] text, Node node, string word = "")
        {
            if (node.value != ' ') word += node.value;
            
            while (node.count > 0)
            {
                text[trieSortIdx] = word;
                trieSortIdx++;
                node.count--;
            }


            foreach (var child in node.Children)
            {
                if (child != null) SortTrie(text, child, word);
            }
        }


        private static int CharToIndex(char letter)
        {
            switch (letter)
            {
                case '\'':
                    return 0;

                case '-':
                    return 1;

                default:
                    var letterIndex = letter - 'a' + 2; // +2 is to not make space for ' and \
                    return letterIndex;
            }
        }
    }
}