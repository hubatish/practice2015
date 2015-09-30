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
    }
}
