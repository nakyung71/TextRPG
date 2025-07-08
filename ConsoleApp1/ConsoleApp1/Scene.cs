using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace RtanRPG
{

    class Scene
    {
        public static ItemManager items = new ItemManager();
        public static Player currentPlayer = new Player();
        public static Inventory inventory = new Inventory();

        
        
        //여기서 참조를 받고(시작할때는 참조값이 없으니까)
        //주의할 점은
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
            Scene.currentPlayer.UpdateEquippedItems();
            Console.WriteLine("상태 보기\r\n캐릭터의 정보가 표시됩니다.\r\n\r\n");
            Console.WriteLine($"Lv. {currentPlayer.Name}\r\n{currentPlayer.Job} ( 전사 )");
            Console.WriteLine($"공격력 : {currentPlayer.Attack}+({currentPlayer.EquipWeapon?.Attack?? 0 })");
            Console.WriteLine($"방어력 : {currentPlayer.Defence}+({currentPlayer.EquipArmor?.Defence ?? 0}");
            Console.WriteLine($"체 력 : {currentPlayer.Health}\r\nGold : {currentPlayer.Gold} G");
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
            Scene.currentPlayer.UpdateEquippedItems();
            Console.WriteLine("인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\r\n[아이템 목록]\r\n");
            foreach (Item b in inventory.inventoryList)
            {
                if(b.Equip==0)
                {
                    if (b.Type == 0)
                    {
                        Console.WriteLine($"- {b.Name} | {b.Description}");
                    }
                    else if (b.Type == 1)
                    {
                        Console.WriteLine($"- {b.Name} | 방어력 +{b.Defence} | {b.Description}");
                    }
                    else if (b.Type == 2)
                    {
                        Console.WriteLine($"- {b.Name} | 공격력 +{b.Attack} | {b.Description}");
                    }
                }
                else
                {
                    if (b.Type == 0)
                    {
                        Console.WriteLine($"- [E]{b.Name} | {b.Description}");
                    }
                    else if (b.Type == 1)
                    {
                        Console.WriteLine($"- [E]{b.Name} | 방어력 +{b.Defence} | {b.Description}");
                    }
                    else if (b.Type == 2)
                    {
                        Console.WriteLine($"- [E]{b.Name} | 공격력 +{b.Attack} | {b.Description}");
                    }
                }
                
            }
            Console.WriteLine("=============================================================");
            Console.WriteLine($"장착된 악세서리: {currentPlayer.EquipAccessories?.Name?? ""}");
            Console.WriteLine($"장착된 방어구: {currentPlayer.EquipArmor?.Name?? ""}");
            Console.WriteLine($"장착된 무기: {currentPlayer.EquipWeapon?.Name?? ""}");
            Console.WriteLine("\r\n\r\n1. 아이템 장착 \r\n2. 아이템 해제\r\n3. 나가기\r\n원하시는 행동을 입력해주세요.\r\n>>");
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
                    else if (num == 2)
                    {
                        GameManager.UnEquipItem();
                        LoadInventory();
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
        public static void LoadShop()
        {
            Console.Clear();
            Console.WriteLine($"상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.\r\n\r\n[보유 골드]\n{currentPlayer.Gold} G\r\n\r\n[아이템 목록]\r\n");

            foreach (Item a in items.itemList)
            {
                if (a.Type == 0)
                {
                    Console.WriteLine($"- {a.Name}  | {a.Description} | {a.Price} G ");
                }
                if (a.Type == 1)
                {
                    Console.WriteLine($"- {a.Name}  | 방어력 +{a.Defence} |  {a.Description} | {a.Price} G ");
                }
                else if (a.Type==2)
                {
                    Console.WriteLine($"- {a.Name}  | 공격력 +{a.Attack} |  {a.Description} | {a.Price} G");
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
            Console.WriteLine("휴식하기\r\n500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : 800 G)");
            Console.WriteLine("\r\n1. 휴식하기 (500 G 소모)\r\n2. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
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
                        bool isPay = currentPlayer.Gold >= 500;
                        if (isPay)
                        {
                            Console.WriteLine("여관 침대에서 잠을 청하였다");
                            currentPlayer.Health = 100;
                            currentPlayer.Gold -= 500;
                            Console.WriteLine($"내 체력이 회복되었다. 현재 체력은 {currentPlayer.Health}, 보유 금액은{currentPlayer.Gold}이다");
                            Console.WriteLine("여관으로 돌아갑니다");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Gold 가 부족합니다. 현재 보유중인 돈은 {currentPlayer.Gold}");
                            Console.WriteLine("여관으로 돌아갑니다");
                            Console.ReadKey();
                            LoadInn();
                            break;
                        }
                    }
                    else if (num == 2)
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
}
