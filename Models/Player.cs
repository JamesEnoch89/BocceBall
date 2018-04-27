using BocceBall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BocceBall
{
    class Players
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public int Number { get; set; }
        public string ThrowingArm { get; set; }

        public int? TeamID { get; set; }
        public Team Team { get; set; }
    }
}
