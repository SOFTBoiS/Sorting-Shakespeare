﻿using System;
using System.Diagnostics;
using System.Security.AccessControl;

namespace Miniproject_1_Sorting_Shakespeare
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TextProcessor tp = new TextProcessor();
            
            // string file_path = @"C:\Users\emilv\Google Drive\Softwareudvikling\1. Semester\Algoritmer og datastrukturer\RiderProjects\Algoritmer og Datastrukturer\Miniproject 1 Sorting Shakespeare\shakespeare-complete-works.txt";
            string file_path =
                @"C:\Users\emilv\Google Drive\Softwareudvikling\1. Semester\Algoritmer og datastrukturer\RiderProjects\Algoritmer og Datastrukturer\Miniproject 1 Sorting Shakespeare\shakespeare-complete-works.txt";

            string text = tp.ReadText(file_path);
            string[] sanitizedText = tp.Sanitize(text);

            
            
            // //Sorts text by selection sort
            // Console.WriteLine("Selectionsort words per millisecond: " + WordsPerMillisecond("Selection", sanitizedText));
            //
            // //Sorts text by insertion sort
            // Console.WriteLine("Insertionsort words per millisecond: " + WordsPerMillisecond("Insertion", sanitizedText));

            //Sorts text by merge sort
            Console.WriteLine("Mergesort words per millisecond: " + WordsPerMillisecond("Merge", sanitizedText));

            //Sorts text by heapsort
            Console.WriteLine("Heapsort words per millisecond: " + WordsPerMillisecond("Heap", sanitizedText));

            //Sorts text with trie
            Console.WriteLine("Triesort words per millisecond: " + WordsPerMillisecond("Trie", sanitizedText));
        }


        static int WordsPerMillisecond(String algName, string[] text)
        {
            var watch = Stopwatch.StartNew();
            SortingMethods sm = new SortingMethods();
            
            switch (algName)
            {
                case "Selection":
                    sm.SelectionSort(text);
                    break;
                
                case "Insertion":
                    sm.InsertionSort(text);
                    break;
                
                case "Merge":
                    sm.BUMergeSort(text);
                    break;
                
                case "Heap":
                    sm.HeapSort(text);
                    break;
                
                case "Trie":
                    sm.Trie(text);
                    break;
            }
            watch.Stop();
            
            return (int) (text.Length / watch.ElapsedMilliseconds);
        }
    }
}