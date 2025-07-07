using ConsoleApp1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
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
            Job = "전사";
            Level = 1;
            Attack = 10;
            Defence = 5;
            Health = 100;
            Gold = 1500;

        }
    }
    public class Item
    {
        public static Item Instance { get; } = new Item();
        public string Name = 
        public int Attack 
        public int Defence 
        public string Description 
        public int Price 


    }
    public class ItemManager
    {
        public static ItemManager Instance { get; } = new ItemManager();

        public List<Item> itemList { get; private set; }
        public ItemManager()
        {


            itemList = new List<Item>();
            itemList.Add(new Item
            {
                Name = "수련자 갑옷",
                Attack = 0,
                Defence = 5,
                Description = "수련에 도움을 주는 갑옷입니다",
                Price = 1000
            });

            itemList.Add(new Item
            {
                Name = "무쇠갑옷",
                Attack = 0,
                Defence = 9,
                Description = "무쇠로 만들어져 튼튼한 갑옷입니다. ",
                Price = 1200
            });
            itemList.Add(new Item
            {
                Name = "스파르타의 갑옷",
                Attack = 0,
                Defence = 15,
                Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                Price = 3500
            });

            itemList.Add(new Item
            {
                Name = "낡은 검",
                Attack = 2,
                Defence = 0,
                Description = "쉽게 볼 수 있는 낡은 검 입니다.",
                Price = 600
            });
            itemList.Add(new Item
            {
                Name = "청동 도끼",
                Attack = 5,
                Defence = 0,
                Description = " 어디선가 사용됐던거 같은 도끼입니다.",
                Price = 1500
            });
            itemList.Add(new Item
            {
                Name = "스파르타의 창",
                Attack = 7,
                Defence = 0,
                Description = "스파르타의 전사들이 사용했다는 전설의 창입니다",
                Price = 3500
            });
            itemList.Add(new Item
            {
                Name = "귀여운 토끼주먹",
                Attack = 20,
                Defence = 0,
                Description = "귀여운 토끼의 주먹입니다",
                Price = 10000
            });
            itemList.Add(new Item
            {
                Name = "토끼 인형탈",
                Attack = 0,
                Defence = 20,
                Description = "귀여운 토끼의 옷입니다",
                Price = 10000
            });

        }
    }
}







