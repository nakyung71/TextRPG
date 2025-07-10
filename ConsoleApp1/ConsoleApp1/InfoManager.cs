
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RtanRPG
{
    public class Player

    {
        private static Player instance;
        public static Player Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Player();

                }
                return instance;

            }

        }

        public string Name = "김나경";
        public string Job = "전사";
        private int _level = 1;
        public int Level
        {
            get 
            {
                return _level; 
            }
            private set
            {
                _level = value;
            }
            
        }
        public int Attack = 10;
        public int Defence = 5;
        private int _health = 100;
        public int Health
        {
            get
            {
                return _health;
            }
            private set
            {
                if (value > 100)
                {
                    _health = 100;
                }
                else if (value <= 0)
                {
                    _health = 0;
                }
                else _health = value;
            }
        }
        private int _gold = 1500;
        public int Gold
        {
            get
            {
                return _gold;
            }
            private set
            { 
            _gold = value;
            }
        }
        int Exp = 0;


        private int ExpNeeded()
        {
            return 100 * Level;
        }

        public void ChangeExp(int exp)
        {
            Exp += exp;
            if (Exp >= ExpNeeded())
            {
                Level += 1;
                Exp = 0;
                Console.WriteLine($"레벨업! 플레이어의 레벨이 Lv. {Level} 이/가 되었습니다");

            }
        }
        public void ChangeGold(int gold)
        {
            Gold += gold;
        }

        public void ChangeHealth(int health)
        {
            Health += health;
        }

        public void ScaleHealth(Func<int,int>func)
        {
            Health=func(Health);
        }


        private Item _equipAccessories= ItemManager.Instance.itemList.Find(i => i.IsEquipped==true && i.Type == 0);

        public Item EquipAccessories
        {
            get 
            {
                return _equipAccessories ?? new Item();
            }

            set 
            { 
                _equipAccessories = value;
            }

        }
        private Item _equipArmor = ItemManager.Instance.itemList.Find(j => j.IsEquipped==true && j.Type == 1);
        public Item EquipArmor
        {
            get
            {
                return _equipArmor ?? new Item();
            }
            set
            {
                _equipArmor = value;
            }
        }
        private Item _equipWeapon=ItemManager.Instance.itemList.Find(h => h.IsEquipped==true && h.Type == 2);
        public Item EquipWeapon
        {
            get
            {
                return _equipWeapon ?? new Item();
            }
            set
            {
                _equipWeapon = value;
            }
        }


        public void UpdateEquippedItems()
        {
            EquipAccessories = ItemManager.Instance.itemList.Find(i => i.IsEquipped==true && i.Type == 0);
            EquipArmor = ItemManager.Instance.itemList.Find(i => i.IsEquipped==true && i.Type == 1);
            EquipWeapon = ItemManager.Instance.itemList.Find(i => i.IsEquipped==true && i.Type == 2);
        }


    }

    public class Inventory
    {
        private static Inventory instance;
        public static Inventory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Inventory();
                }
                return instance;
            }

        }


        public List<Item> inventoryList= new List<Item>();
        public void AddItem(Item item)
        {
            inventoryList.Add(item);
            Console.WriteLine($"아이템: {item.Name} 이(가) 인벤토리에 추가되었습니다.");
            Console.ReadKey();

        }
       
    }

    public class Item
    {

        public string Name = "";
        public int Attack = 0;
        public int Defence = 0;
        public string Description = "";
        public int Price = 0;
        public int Type = 0;
        public int Number = 0;
        public bool IsEquipped = false;
        public bool IsPurchased=false;


    }
    public class ItemManager
    {
        private static ItemManager instance;
        public static ItemManager Instance
        {

            get
            {
                if (instance == null)
                {
                    instance = new ItemManager();
                }
                return instance; 


            }

        }

        public List<Item> itemList = new List<Item>();
        public ItemManager()
        {


            itemList.Add(new Item
            {
                Number = 1,
                Name = "수련자 갑옷",
                Attack = 0,
                Defence = 5,
                Description = "수련에 도움을 주는 갑옷입니다",
                Price = 1000,
                Type = 1
            });

            itemList.Add(new Item
            {
                Number = 2,
                Name = "무쇠갑옷",
                Attack = 0,
                Defence = 9,
                Description = "무쇠로 만들어져 튼튼한 갑옷입니다. ",
                Price = 1200,
                Type = 1
            });
            itemList.Add(new Item
            {
                Number = 3,
                Name = "스파르타의 갑옷",
                Attack = 0,
                Defence = 15,
                Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                Price = 3500,
                Type = 1
            });

            itemList.Add(new Item
            {
                Number = 4,
                Name = "낡은 검",
                Attack = 2,
                Defence = 0,
                Description = "쉽게 볼 수 있는 낡은 검 입니다.",
                Price = 600,
                Type = 1
            });
            itemList.Add(new Item
            {
                Number=5,
                Name = "청동 도끼",
                Attack = 5,
                Defence = 0,
                Description = " 어디선가 사용됐던거 같은 도끼입니다.",
                Price = 1500,
                Type = 2
            });
            itemList.Add(new Item
            {
                Number = 6,
                Name = "스파르타의 창",
                Attack = 7,
                Defence = 0,
                Description = "스파르타의 전사들이 사용했다는 전설의 창입니다",
                Price = 3500,
                Type = 2
            });
            itemList.Add(new Item
            {
                Number = 7,
                Name = "귀여운 토끼주먹",
                Attack = 20,
                Defence = 0,
                Description = "귀여운 토끼의 주먹입니다",
                Price = 10000,
                Type = 2
            });
            itemList.Add(new Item
            {
                Number = 8,
                Name = "토끼 인형탈",
                Attack = 0,
                Defence = 20,
                Description = "귀여운 토끼의 옷입니다",
                Price = 10000,
                Type = 1
            });
            itemList.Add(new Item
            {
                Number = 9,
                Name = "핑크 토끼 머리띠",
                Attack = 0,
                Defence = 0,
                Description = "너무 깜찍한 토끼 악세서리입니다",
                Price = 50,
                Type = 0
            });
            itemList.Add(new Item
            {
                Number = 10,
                Name = "고양이 냥발",
                Attack = 0,
                Defence = 0,
                Description = "너무 깜찍한 고양이 악세서리입니다",
                Price = 50,
                Type = 0
            });

        }
    }
}







