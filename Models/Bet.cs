using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Models
{
    public class Bet
    {
        public int Value { get; set; }
        public string Time { get; set; }

        public Bet(int value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            var bet = obj as Bet;
            if (bet is null) return false;

            if (bet.Value == Value) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
