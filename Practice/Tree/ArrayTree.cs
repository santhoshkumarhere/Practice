using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Practice.Tree
{
    class ArrayTree
    {
        private int[] arrayTree = new int[10]; 

        public void Add(int a)
        {
            if (this.arrayTree.Length == 0)
            {
                this.arrayTree[0] = a;
            }
        }

        public void AddLeft(int data, int rootIndex)
        {
            var leftIndex = 2 * rootIndex + 1;
            if (leftIndex < arrayTree.Length)
            {
                this.arrayTree[leftIndex] = data;
            }
        }

        public void AddRight(int data, int rootIndex)
        {
            var rightIndex = 2 * rootIndex + 1;
            if (rightIndex < arrayTree.Length)
            {
                this.arrayTree[rightIndex] = data;
            }
        }

        public void Print()
        {
            for(int i = 0; i < arrayTree.Length; i++)
            {
                Console.Write(arrayTree[i] + " ");
            }
        }
    }
}
