using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2015
{
    public class ArrayRotation
    {
        //Rotates array to the right by n steps
        public void RotateArray<T>(List<T> arr, int steps)
        {
            if (arr == null || arr.Count()==0)
            {
                return;
            }
            for(int j = 0; j < steps; j++)
            {
                T prevElement = arr[arr.Count() - 1];
                for (int i = 0; i < arr.Count(); i++)
                {
                    T temp = arr[i];
                    arr[i] = prevElement;
                    prevElement = temp;
                }
            }
        }
    }

    public class Tester
    {
        public bool CompareArrays<T>(List<T> arr1, List<T> arr2)
        {
            if(arr1==null && arr2 == null)
            {
                return true;
            }
            else if(arr1 == null || arr2 == null)
            {
                return false;
            }
            if (arr1.Count() != arr2.Count())
            {
                return false;
            }
            for(int i=0; i < arr1.Count(); i++)
            {
                if(!Equals(arr1[i],arr2[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public void RotateArrayTest()
        {
            ArrayRotation rotater = new ArrayRotation();
            List<int> startArr = new List<int>() { 1, 2, 3 };
            List<int> endArr = new List<int>() { 3, 1, 2 };
            rotater.RotateArray<int>(startArr, 1);
            if (!CompareArrays<int>(startArr, endArr))
            {
                throw new Exception("[1,2,3] did not transform to [3,1,2]");
            }
            List<int> startArr5 = new List<int>()
            {
                1,2,3,4,5
            };
            List<int> endArr5 = new List<int> { 3, 4, 5, 1, 2 };
            rotater.RotateArray<int>(startArr5, 3);
            if (!CompareArrays<int>(startArr5, endArr5))
            {
                throw new Exception("Rotated list lenght 5 3 times, unexpected result");
            }
        }
    }
}
