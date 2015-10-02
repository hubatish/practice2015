using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2015
{
    public class LinkedListProblems
    {
        public void Test()
        {
            LinkedList<int> startL = new LinkedList<int>();
            List<int> inits = new List<int>(){ 3, 5, 8, 5, 10, 2, 1 };
            foreach(int i in inits)
            {
                startL.AddLast(i);
            }
            int pNum = 5;
            PartitionList(startL, pNum);
            int sE = 0;
            for (var curE=startL.First; curE!=null; curE=curE.Next)
            {
                if (curE.Value < pNum)
                {
                    sE += 1;
                }
            }
            if (sE != 3)
            {
                throw new Exception("wrong number of elements less than pNum");
            }
            int gE = 0;
            for (var curE = startL.First; curE != null; curE = curE.Next)
            {
                if (curE.Value >= pNum)
                {
                    gE += 1;
                }
            }
            if (gE != 4)
            {
                throw new Exception("wrong number of elements >= pNum");
            }
        }

        public void PartitionList(LinkedList<int> l, int partitionNum)
        {
            if (l == null)
            {
                return;
            }
            LinkedList<int> lessThan = new LinkedList<int>();
            LinkedList<int> greaterThan = new LinkedList<int>();
            for (LinkedListNode<int> curE = l.First; curE != null; curE = curE.Next)
            {
                if (curE.Value < partitionNum)
                {
                    lessThan.AddLast(curE.Value);
                }
                else
                {
                    greaterThan.AddLast(curE.Value);
                }
            }
            //Actually copy the values back into the linkedlist
            LinkedListNode<int> mainE = l.First;
            for (var lessE = lessThan.First; lessE != null; lessE = lessE.Next)
            {
                mainE.Value = lessE.Value;
                mainE = mainE.Next;
            }
            for (var greE = greaterThan.First; greE != null; greE = greE.Next)
            {
                mainE.Value = greE.Value;
                mainE = mainE.Next;
            }
            //done!
            /*for(int i=0;i<l.Count();i++){

                if(i<lessThan.Count()){
                    l[i] = lessThan[i];
                }
                else{
                    l[i] = greaterThan[i-lessThan.Count()];	
                }
            }*/
        }

        /// <summary>
        /// Warning!!!!
        /// Below code doesn't work, nor make any sense in the context of a C# linkedlist, as I cannot concat two linked lists by reference
        /// </summary>
        public void TestIntersection()
        {
            //annoying to test
            LinkedList<int> endOfList = new LinkedList<int>(new List<int>() { 1, 2, 3 });
            LinkedList<int> list1 = new LinkedList<int>(new List<int>() { 6 });
            LinkedList<int> list2 = new LinkedList<int>(new List<int>() { 7, 0 });
            //list1.Last.Next = endOfList.First;
            //list2.Last.Next = endOfList.First;
            LinkedListNode<int> node = FindIntersectionNode<int>(list1, list2);
            if (node.Value != 1)
            {
                throw new Exception("1 was not the value of instersecting node");
            }
        }

        public LinkedListNode<T> FindIntersectionNode<T>(LinkedList<T> l1, LinkedList<T> l2)
        {
            if (l1 == null || l2 == null)
            {
                return null;
            }
            if (!l1.Last().Equals(l2.Last())){
                return null;
            }
            LinkedList<T> backwards1 = new LinkedList<T>();
            LinkedList<T> backwards2 = new LinkedList<T>();

            for (LinkedListNode<T> n = l1.First; n != null; n = n.Next)
            {
                backwards1.AddLast(n);
            }
            for (LinkedListNode<T> n = l2.First; n != null; n = n.Next)
            {
                backwards2.AddLast(n);
            }
            var n1 = backwards1.First;
            var n2 = backwards2.First;
            var prevNode = n1;
            while (n1 != null && n1.Equals(n2))
            {
                n1 = n1.Next;
                n2 = n2.Next;
                prevNode = n1;
            }
            return prevNode;
        }

    }
}
