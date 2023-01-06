using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    public class MyMathImplementation
    {

        public static int Add (int a, int b)
        {
            return a + b;
        }

        public static bool IsMajeur(int age)
        {
            
            if (age < 0 || age >= 150)
            {
                throw new ArgumentException();
            }

            if (age >= 18)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public static bool IsEven(int a)
        {
            if (a == 0)
            {
                return true;
            }

            else if (a % 2 == 0)
            {
                return true;
            }
            else { return false; }
        }

        public static bool IsDivisible(int a, int b)
        {
            if (a <= 0)
            {
                return false;
            }

            if (a % b == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsPrimary(int a)
        {
            int numberOfDiviser = 0;

            for (int i = 1; i <= a; i++)
            {
                if (a % i == 0)
                {
                    numberOfDiviser++;
                }
            }

            if (numberOfDiviser == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<int> GetAllPrimary(int a)
        {
            List<int> allPrimary = new List<int>();

            for (int i = 0; i <= a; i++)
            {
                if (IsPrimary(i))
                {
                    allPrimary.Add(i);
                }
            }

            return allPrimary;
        }

        public static int Power2(int a)
        {
            return a * a;
        }

        public static int Power(int a, int b)
        {
            int apow = a;

            for (int i = 0; i < b - 1; i++)
            {
                a = a * apow;
            }
            return a;
        }

        public static int IsInOrder(int a, int b)
        {
            return a < b ? 1 : a > b ? -1 : 0;
        }

        public static bool IsListInOrder(List<int> list)
        {

            bool isSorted = true;
            int listCount = list.Count;

            for (int i = 0; i < listCount - 1; i++)
            {
                if (list[i] > list[i + 1])
                {
                    isSorted = false;
                }
            }

            return isSorted;
        }

        public static bool IsListInOrder(List<int> list,Func<int, int, int> isInOrder)
        {
            
            bool isSorted = true;
            int listCount = list.Count;

            for (int i = 0; i < listCount - 1; i++)
            {
                if (isInOrder(list[i], list[i + 1]) == -1)
                {
                    isSorted = false;
                }
            }
          

            return isSorted;
        }


        public static List<int> Sort(List<int> toSort)
        {
            while (!IsListInOrder(toSort))
            {
                for (int i = 0; i < toSort.Count - 1; i++)
                {
                    if (toSort[i] > toSort[i + 1])
                    {
                        int c = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = c;
                    }
                }
            }
            return toSort;
        }

        public static List<int> GenericSort(List<int> toSort, Func<int, int, int> isInOrder)
        {
            while (!IsListInOrder(toSort , isInOrder))
            {
                for (int i = 0; i < toSort.Count - 1; i++)
                {
                    if (isInOrder(toSort[i], toSort[i + 1]) == -1)
                    {
                        int c = toSort[i];
                        toSort[i] = toSort[i + 1];
                        toSort[i + 1] = c;
                    }
                }
            }
            return toSort;
        }

        public static int IsInOrderDesc(int a, int b)
        {
            return a > b ? 1 : a < b ? -1 : 0;
        }
    }
}
