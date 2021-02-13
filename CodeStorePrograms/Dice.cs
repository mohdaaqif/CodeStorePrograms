using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            int rollDice1 = await Task.Run(() => { return this.Roll(1); });
            int rollDice2 = await Task.Run(() => { return this.Roll(2); });
            int rollDice3 = await Task.Run(() => { return this.Roll(3); });
            int rollDice4 = await Task.Run(() => { return this.Roll(4); });
            int rollDice5 = await Task.Run(() => { return this.Roll(5); });
            return rollDice1 + rollDice2 + rollDice3 + rollDice4 + rollDice5;
        }
    }
}
