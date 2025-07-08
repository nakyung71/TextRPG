
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RtanRPG
{
    public class Player
       
    {
        
        public string Name = "김나경";
        public string Job = "전사";
        public int Level = 1;
        public int Attack = 10;
        public int Defence = 5;
        private int health = 100;
        public int Health 
        {
            get
            {
                return health;
            }
            set
            {
                if (value > 100)
                {
                    health = 100;
                }
                else if (value<=0)
                {
                    health = 0;
                }

                else health = value;
            }
        }
        public int Gold = 1500;
        public Item EquipAccessories= Scene.items .itemList.Find(i => i.Equip == 1 && i.Type == 0);
        private Item _equipArmor = Scene.items.itemList.Find(j => j.Equip == 1 && j.Type == 1);
        public Item EquipArmor
        {
            get
            {
                return _equipArmor ?? new Item { Defence = 0 };
            }
            set
            {
                _equipArmor = value;
            }
        }
        private Item _equipWeapon=Scene.items.itemList.Find(h => h.Equip == 1 && h.Type == 2);
        public Item EquipWeapon
        {
            get
            {
                return _equipWeapon ?? new Item { Attack = 0 };
            }
            set
            {
                _equipWeapon = value;
            }
        }


        public void UpdateEquippedItems()
        {
            EquipAccessories = Scene.items.itemList.Find(i => i.Equip == 1 && i.Type == 0);
            EquipArmor = Scene.items.itemList.Find(i => i.Equip == 1 && i.Type == 1);
            EquipWeapon = Scene.items.itemList.Find(i => i.Equip == 1 && i.Type == 2);
        }


    }

    public class Inventory
    {
        public List<Item> inventoryList= new List<Item>();
        public void AddItem(Item item)
        {
            inventoryList.Add(item);
            Console.WriteLine($"아이템: {item.Name} 이(가) 인벤토리에 추가되었습니다.");
            Console.ReadKey();

        }
        //여기에도 리스트 만들어서 구매하면 여기에 add하면 되겠네
    }

    public class Item
    {

        public string Name = "";
        public int Attack = 0;
        public int Defence = 0;
        public string Description = "";
        public int Price = 0;
        public int Equip = 0;
        public int Type = 0;


    }
    public class ItemManager
    {

        public List<Item> itemList = new List<Item>();
        public ItemManager()
        {

            itemList.Add(new Item
            {
                Name = "수련자 갑옷",
                Attack = 0,
                Defence = 5,
                Description = "수련에 도움을 주는 갑옷입니다",
                Price = 1000,
                Type = 1
            });

            itemList.Add(new Item
            {
                Name = "무쇠갑옷",
                Attack = 0,
                Defence = 9,
                Description = "무쇠로 만들어져 튼튼한 갑옷입니다. ",
                Price = 1200,
                Type = 1
            });
            itemList.Add(new Item
            {
                Name = "스파르타의 갑옷",
                Attack = 0,
                Defence = 15,
                Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                Price = 3500,
                Type = 1
            });

            itemList.Add(new Item
            {
                Name = "낡은 검",
                Attack = 2,
                Defence = 0,
                Description = "쉽게 볼 수 있는 낡은 검 입니다.",
                Price = 600,
                Type = 1
            });
            itemList.Add(new Item
            {
                Name = "청동 도끼",
                Attack = 5,
                Defence = 0,
                Description = " 어디선가 사용됐던거 같은 도끼입니다.",
                Price = 1500,
                Type = 2
            });
            itemList.Add(new Item
            {
                Name = "스파르타의 창",
                Attack = 7,
                Defence = 0,
                Description = "스파르타의 전사들이 사용했다는 전설의 창입니다",
                Price = 3500,
                Type = 2
            });
            itemList.Add(new Item
            {
                Name = "귀여운 토끼주먹",
                Attack = 20,
                Defence = 0,
                Description = "귀여운 토끼의 주먹입니다",
                Price = 10000,
                Type = 2
            });
            itemList.Add(new Item
            {
                Name = "토끼 인형탈",
                Attack = 0,
                Defence = 20,
                Description = "귀여운 토끼의 옷입니다",
                Price = 10000,
                Type = 1
            });
            itemList.Add(new Item
            {
                Name = "핑",
                Attack = 0,
                Defence = 0,
                Description = "너무 깜찍한 토끼 악세서리",
                Price = 50,
                Type = 0
            });
            itemList.Add(new Item
            {
                Name = "파",
                Attack = 0,
                Defence = 0,
                Description = "너무 깜찍한 토끼 악세서리",
                Price = 50,
                Type = 0
            });

        }
    }
}







