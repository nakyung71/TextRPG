using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace RtanRPG
{
 
    class Scene
    {
        static void Main(string[] args)
        {
            LoadStartingScene();
        }


        public static void LoadStartingScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n");
            Console.WriteLine("1.상태 보기\r\n2.인벤토리\r\n3.상점\r\n4.던전 입장\r\n5.휴식하기\n원하시는 행동을 입력해주세요.\r\n >> ");
            
            while (true)
            {
                string inputKey = Console.ReadLine();
                bool isNumber = int.TryParse(inputKey, out int num);
                if (!isNumber)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                if (isNumber)
                {
                    if (num == 1)
                    {
                        LoadStatus();
                        break;
                    }
                    else if (num == 2)
                    {
                        LoadInventory();
                        break;
                    }
                    else if (num == 3)
                    {
                        LoadShop();
                        break;
                    }
                    else if(num==4)
                    {
                        Dungeon.LoadDungeon();
                        break;
                    }
                    else if (num == 5)
                    {
                        LoadInn();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }


                }
            }
        }
        static void LoadStatus()
        {
            Console.Clear();
            Player.Instance.UpdateEquippedItems();
            Console.WriteLine("상태 보기\r\n캐릭터의 정보가 표시됩니다.\r\n\r\n");
            Console.WriteLine($"Lv. {Player.Instance.Level}\r\n{Player.Instance.Job}  {Player.Instance.Job}");
            Console.WriteLine($"공격력 : {Player.Instance.Attack}+({Player.Instance.EquipWeapon.Attack })");
            Console.WriteLine($"방어력 : {Player.Instance.Defence}+({Player.Instance.EquipArmor.Defence})");
            Console.WriteLine($"체 력 : {Player.Instance.Health}\r\nGold : {Player.Instance.Gold} G");
            Console.WriteLine("\r\n\r\n0. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
            while (true)
            {
                string inputKey = Console.ReadLine();
                bool isNumber = int.TryParse(inputKey, out int num);
                if (!isNumber)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                if (isNumber)
                {
                    if (num == 1)
                    {
                        GameManager.EquipItem();
                        LoadInventory();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }


                }
            }
        }
        public static void LoadInventory()
        {
            Console.Clear();
            Player.Instance.UpdateEquippedItems();
            Console.WriteLine("인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\r\n[아이템 목록]\r\n");

            for (int i = 0; i < Inventory.Instance.inventoryList.Count; i++)
            {
                Item b =  Inventory.Instance.inventoryList[i];


                Console.Write($"- {i + 1}");
                if (b.IsEquipped)
                {
                    Console.Write("[E]");
                }
                Console.Write($"  {b.Name}  |");
                if (b.Defence!=0)
                {
                    Console.Write($"  방어력 +{b.Defence}  |");
                }
                if(b.Attack!=0)
                {
                    Console.Write($"  공격력 +{ b.Attack}  |");
                }
                Console.Write($"  {b.Description}\n");

            }

            Console.WriteLine("\n============================================================");
            Console.WriteLine($"장착된 악세서리: {Player.Instance.EquipAccessories.Name }");
            Console.WriteLine($"장착된 방어구: {Player.Instance.EquipArmor.Name}");
            Console.WriteLine($"장착된 무기: {Player.Instance.EquipWeapon.Name}");
            Console.WriteLine("\r\n\r\n1. 장착 관리 \r\n\r\n0. 나가기\r\n원하시는 행동을 입력해주세요.\r\n>>");

            while (true)
            {
                string inputKey = Console.ReadLine();
                bool isNumber = int.TryParse(inputKey, out int num);
                if (!isNumber)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                if (isNumber)
                {
                    if (num == 1)
                    {
                        LoadEquip();
                        break;
                    }
                    else if (num == 0)
                    {
                        LoadStartingScene();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }


                }
            }

        }
        static void  LoadEquip()
        {
            Console.Clear();
            Console.WriteLine($"인벤토리 - 장착 관리\r\n보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]");

            for (int i = 0; i < Inventory.Instance.inventoryList.Count; i++)
            {
                Item b = Inventory.Instance.inventoryList[i];


                Console.Write($"- {i + 1}");
                if (b.IsEquipped)
                {
                    Console.Write("[E]");
                }
                Console.Write($"  {b.Name}  |");
                if (b.Defence != 0)
                {
                    Console.Write($"  방어력 +{b.Defence}  |");
                }
                if (b.Attack != 0)
                {
                    Console.Write($"  공격력 +{b.Attack}  |");
                }
                Console.Write($"  {b.Description}\n");
            }



            Console.WriteLine($"\n1. 아이템 장착 2. 아이템 해지 0. 나가기");
            while (true)
            {
                string inputKey = Console.ReadLine();
                bool isNumber = int.TryParse(inputKey, out int num);
                if (!isNumber)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                if (isNumber)
                {
                    if (num == 1)
                    {
                        GameManager.EquipItem();          
                        break;
                    }
                    else if (num == 2)
                    {
                        GameManager.UnEquipItem();  
                        break;
                    }
                    else if (num == 0)
                    {
                        LoadInventory();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }


                }
            }



        }

        public static void LoadShop()
        {
            Console.Clear();
            Console.WriteLine($"상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.\r\n\r\n[보유 골드]\n{Player.Instance.Gold} G\r\n\r\n[아이템 목록]\r\n");

            for(int i = 0; i<ItemManager.Instance.itemList.Count; i++) 
            {
                Item a = ItemManager.Instance.itemList[i];
                Console.Write($"- {i+1}  ");
                if (a.Type == 0)
                {
                    Console.WriteLine($"{a.Name}  | {a.Description} | {a.Price} G ");
                }
                if (a.Type == 1)
                {
                    Console.WriteLine($"{a.Name}  | 방어력 +{a.Defence} |  {a.Description} | {a.Price} G ");
                }
                else if (a.Type==2)
                {
                    Console.WriteLine($"{a.Name}  | 공격력 +{a.Attack} |  {a.Description} | {a.Price} G");
                }


            }
            Console.WriteLine("\r\n1. 아이템 구매\r\n2. 아이템 판매\r\n3. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
            while (true)
            {
                string inputKey = Console.ReadLine();
                bool isNumber = int.TryParse(inputKey, out int num);
                if (!isNumber)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                if (isNumber)
                {
                    if (num == 1)
                    {
                        GameManager.BuyItem();
                        break;
                    }
                    else if (num == 2)
                    {
                        GameManager.SellItem();
                        break;
                    }
                    else if (num == 3)
                    {
                        LoadStartingScene();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }


                }
            }
            

        }
        static void LoadInn()
        {
            Console.Clear ();
            Console.WriteLine($"휴식하기\r\n500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {Player.Instance.Gold} G)");
            Console.WriteLine("\r\n1. 휴식하기 (500 G 소모)\r\n2. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
            while (true)
            {
                string inputKey = Console.ReadLine();
                bool isNumber = int.TryParse(inputKey, out int num);
                if (isNumber && num == 1)
                {
                    bool isPay = Player.Instance.Gold >= 500;
                    if (isPay)
                    {
                        Console.WriteLine("여관 침대에서 잠을 청하였다");
                        Player.Instance.ScaleHealth((int hp) => 100);
                        Player.Instance.ChangeGold(500);
                        Console.WriteLine($"내 체력이 회복되었다. 현재 체력은 {Player.Instance.Health}, 보유 금액은{Player.Instance.Gold}이다");
                        Console.WriteLine("여관으로 돌아갑니다");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Gold 가 부족합니다. 현재 보유중인 돈은 {Player.Instance.Gold}");
                        Console.WriteLine("여관으로 돌아갑니다");
                        Console.ReadKey();
                        LoadInn();
                        break;
                    }
                }
                else if (isNumber&&num == 2)
                {
                    LoadStartingScene();
                }

                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }


      





    }
}
