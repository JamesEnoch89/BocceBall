using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BocceBall.Data;
using BocceBall.Models;

namespace BocceBall
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new BocceContext();
            Console.WriteLine("Bocce Ball!");
            //display teams and players
            var teamPlayers = db.Player.Include(i => i.Team);
            foreach (var teamPlayer in teamPlayers)
            {
                Console.WriteLine($"{teamPlayer.FullName} is on {teamPlayer.Team.Mascot}, color: {teamPlayer.Team.Color}");
            }
            //display records
            Console.WriteLine("Team Records:");

            var teamRecords = db.Team;
            foreach (var teamRecord in teamRecords)
            {
                Console.WriteLine($"{teamRecord.Mascot} have won {teamRecord.Wins} games and lost {teamRecord.Losses} games.");
            }
            // if played display date played, if not played, show schedule date
            Console.WriteLine("Schedule:");
            var gameHistory = db.Game;
            foreach (var game in gameHistory)
            {
                if (game.DateHappened <= DateTime.Now)
                {
                    Console.WriteLine($"{game.HomeTeam.Mascot} played {game.AwayTeam.Mascot} on {game.DateHappened}");
                }

                if (game.DateHappened > DateTime.Now)
                {
                    Console.WriteLine($"{game.HomeTeam.Mascot} will play {game.AwayTeam.Mascot} on {game.DateHappened}");
                }
            }
            Console.ReadLine();
        }
    }
}

