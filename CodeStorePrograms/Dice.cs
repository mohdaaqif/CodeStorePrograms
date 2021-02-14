using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodeStorePrograms
{
    class Dice : Random
    {
        public Dice() : base()
        {

        }

        internal int Roll(int diceNumber)
        {
            int diceValue = this.Next(1, 6);
            Console.WriteLine("Dice Number : " + diceNumber + ", Dice Value : " + diceValue);
            return diceValue;
        }

        internal async Task<int> RollAndSumFiveDive()
        {
            Task<int> rollDice1 = Task.Run(() => { return this.Roll(1); });
            Task<int> rollDice2 = Task.Run(() => { return this.Roll(2); });
            Task<int> rollDice3 = Task.Run(() => { return this.Roll(3); });
            Task<int> rollDice4 = Task.Run(() => { return this.Roll(4); });
            Task<int> rollDice5 = Task.Run(() => { return this.Roll(5); });
            await Task.WhenAll(rollDice1, rollDice2, rollDice3, rollDice4, rollDice5);
            int TotolSum = rollDice1.Result + rollDice2.Result + rollDice3.Result + rollDice4.Result + rollDice5.Result;
            return TotolSum;
        }
    }
}
