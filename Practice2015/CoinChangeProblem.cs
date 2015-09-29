using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2015
{
    public class ChangeTester
    {
        public void Test()
        {
            ChangeMaker changeMaker = new ChangeMaker();
            List<int> coinSet = new List<int>() { 2, 5, 3, 6 };
            int ways = changeMaker.WaysToMakeChange(coinSet, 10);
            if (ways != 5)
            {
                throw new Exception("Ways to make change should be 5 for given set. Was not") ;
            }
        }
    }

    public class ChangeMaker
    {
        public int WaysToMakeChange(List<int> coinSet, int amount)
        {
            if (coinSet == null) { return 0; }
            List<int> sortedCoins = new List<int>(coinSet); //Ascending (lowest element first)
            return _WaysToMakeChange(sortedCoins, amount);
        }

        private int _WaysToMakeChange(List<int> coinSet, int amount)
        {
            if (coinSet == null || coinSet.Count() == 0)
            {
                return 0;
            }
            if (amount == 0) { return 1; }
            if (amount < 0) { return 0; }
            int numSolutions = 0;
            //for(int i=coinSet.Count()-1;i>=0;i--){
            List<int> solutionSet = new List<int>();
            int lastCoin = coinSet.Last();
            if (lastCoin <= amount)
            {
                solutionSet.Add(lastCoin);
                numSolutions += _WaysToMakeChange(coinSet, amount - lastCoin);
            }
            List<int> editedCoinSet = new List<int>(coinSet);
            editedCoinSet.RemoveAt(coinSet.Count() - 1);
            return numSolutions + _WaysToMakeChange(editedCoinSet, amount);
            //}
        }
    }
}
