using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBall.Models
{
    class Team
    {
        public int ID { get; set; }
        public string Mascot { get; set; }
        public string Color { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
