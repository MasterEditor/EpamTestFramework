using FrameworkCore.Models;
using FrameworkCore.Shared;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Services
{
    public static class BetCreator
    {
        private static IConfigurationSection _betsConfigSection = Configuration.Instance.Root.GetSection("Bets");

        public static Bet CreateCorrectBet()
        {
            var value = int.Parse(_betsConfigSection["Correct"]);
            return new Bet(value);
        }

        public static Bet CreateIncorrectBet()
        {
            var value = int.Parse(_betsConfigSection["Incorrect"]);
            return new Bet(value);
        }
    }
}
