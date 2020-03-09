﻿using System;
using System.Security.Cryptography.X509Certificates;

namespace Miniproject_1_Sorting_Shakespeare
{
    public class Node
    {
        public char value;
        public Node[] Children { get; }
        public int count { get; set; }

        public Node(char value)
        {
            this.value = value;
            count = 0;
            Children = new Node[28];
        }
    }
}