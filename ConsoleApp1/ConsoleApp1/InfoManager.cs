
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
        //플레이어는 싱글톤으로 설정하였고, 특정 값들은 get set을 통하여 따로 조건을 설정하였다. 
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
        public float Attack = 10;
        public int Defence = 5;
        private int _health = 100;
        public int Health //체력의 경우에는 최대 체력(100)이상 되지 않게 하기 위해 이렇게 하였다. 그리고 체력이 음수가 되지 않게 하였다. 
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


        private int ExpNeeded() //예시에 1렙은 1번돌면 레벨업, 2레벨은 2번 돌면 레벨업 하라고 설정되어있어서 간단하게 이렇게 표현해봤다. 렙업을 할수록 경험치통이 늘어난다.
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
                Attack += 0.5f;
                Defence += 1;
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
        }//여기는 Func를 사용하여 보다 복잡한 체력관련 매커니즘을 처리하였다. int를 넣고 int를 반환하는 함수를 매개변수로 하는데, 이는 나중에 람다식으로 표현해서 넣어주었다.

        public void RandomJob()
        {
            string[] jobs = { "전사", "마법사", "도적", "해적", "궁수" };
            Random random = new Random();
            int index=random.Next(0,jobs.Length);
            Player.instance.Job=jobs[index];
            
        }

        private Item _equipAccessories= ItemManager.Instance.itemList.Find(i => i.IsEquipped==true && i.Type == 0);
        //이 부분은 지금 착용하고 있는 장비를 나타낸다. 착용여부, 그리고 부위가 맞아야 한다는 조건을 만족하는 아이템을 Find로 찾았다. 
        //아래 ??는 왼쪽이 null이면 오른쪽을 사용하고, null이 아니면 왼쪽을 그대로 사용하는 null변합연산자 이다. 즉, 만약 장착 아이템이 null이면 그냥 기본옵션의 아이템을 return해준다
        //그리고 만약 장착 아이템이 null이 아니면 그냥 장착아이템을 보여준다. 이렇게 한 이유는 장착을 안했을때 수많은 부분에서 null관련 오류를 일으켰기 때문이다. 
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

        //참조값은 자기혼자 업데이트 되지
        public void UpdateEquippedItems()
        {
            EquipAccessories = ItemManager.Instance.itemList.Find(i => i.IsEquipped==true && i.Type == 0);
            EquipArmor = ItemManager.Instance.itemList.Find(i => i.IsEquipped==true && i.Type == 1);
            EquipWeapon = ItemManager.Instance.itemList.Find(i => i.IsEquipped==true && i.Type == 2);
        }
        //내가 아이템 리스트의 정보를 바꿔도 그 바꾼 정보가 자기 혼자 업데이트 되지는 않아서 필요한 씬마다 업데이트를 붙여서 정보를 업데이트 해주었다.
        

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
        public ItemManager()  //리스트로 아이템을 관리하여 나중에 아이템을 더하고 빼더라도 편하게 할 수 있게 하였다.  type은 장비의 종류로, 같은 종류는 1개만 낄수 있게끔 구현하였다.
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
                Price = 500,
                Type = 0
            });
            itemList.Add(new Item
            {
                Number = 10,
                Name = "고양이 냥발",
                Attack = 0,
                Defence = 0,
                Description = "너무 깜찍한 고양이 악세서리입니다",
                Price = 500,
                Type = 0
            });

        }
    }
}







