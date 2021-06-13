using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluate
{
    class Stack<T>
    {
        private int Top;
        private int S_Length;
        private T[] arr;

        public Stack(int capacity)
        {
            Top = 0;
            S_Length = capacity;
            arr = new T[S_Length];
        }
        public void push(T Value)
        {
            if (Top > S_Length - 1)
            {
                Console.WriteLine("Stack is OverFlow!");
            }
            else
            {
                arr[Top++] = Value;
            }
        }
        public T pop()
        {
            if (Top <= 0)
            {
                return (T)(object)"Stack is underflow!";
            }
            else
            {
                return arr[--Top];
            }
            
        }
        public T peek()
        {
            if (Top <= 0)
            {
                return (T)(object)"Stack is underflow!";
            }
            else
            {
                return (arr[Top - 1]);
            }
        }
        public bool isempty()
        {
            if(Top > 0)
            {
                return false;
            }
            return true;
        }
        public void clone()
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        public bool contain(T value)
        {
            for (int i = 0; i < Top; i++)
            {
                if (EqualityComparer<T>.Default.Equals(arr[i], value))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
