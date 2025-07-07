using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Player

    {
        public static Player Instance { get; } = new Player();
        public string Name { get; set; }
        public string Job { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }


        private Player()
        {
            Name = "김나경";
            Level = 1; 
            Attack = 10;
            Defence = 5;
            Health = 100;
            Gold = 1500;

        }


            

            




    }
}
