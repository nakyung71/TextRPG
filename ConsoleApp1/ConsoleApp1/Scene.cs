using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace RtanRPG
{

    class Scene
    {
        public static Player currentPlayer = new Player();
        public static ItemManager items = new ItemManager();
        public static Inventory inventory = new Inventory();
        
        
        //여기서 참조를 받고(시작할때는 참조값이 없으니까)
        //주의할 점은
        static void Main(string[] args)
        {

            LoadStartingScene();

        }

        static void LoadStartingScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n");
            Console.WriteLine("1.상태 보기\r\n2.인벤토리\r\n3.상점\r\n\r\n원하시는 행동을 입력해주세요.\r\n >> ");

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
            Console.WriteLine("상태 보기\r\n캐릭터의 정보가 표시됩니다.\r\n\r\n");
            Console.WriteLine($"Lv. {currentPlayer.Name}      \r\n{currentPlayer.Job} ( 전사 )\r\n공격력 : {currentPlayer.Attack}\r\n방어력 : {currentPlayer.Defence}\r\n체 력 : {currentPlayer.Health}\r\nGold : {currentPlayer.Gold} G");
            Console.WriteLine("\r\n\r\n0. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");


        }
        static void LoadInventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\r\n[아이템 목록]\r\n");
            foreach (Item b in inventory.inventoryList)
            {
                if (b.Attack == 0)
                {
                    Console.WriteLine($"- {b.Name} | 방어력 +{b.Defence} | {b.Description}");
                }
                if (b.Defence == 0)
                {
                    Console.WriteLine($"- {b.Name} | 공격력 +{b.Attack} | {b.Description}");
                }
            }
            Console.WriteLine("\r\n\r\n1. 장착 관리\r\n2. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
            
        }
        public static void LoadShop()
        {
            Console.Clear();
            Console.WriteLine($"상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.\r\n\r\n[보유 골드]\n{currentPlayer.Gold} G\r\n\r\n[아이템 목록]\r\n");

            foreach (Item a in items.itemList)
            {
                if (a.Attack == 0)
                {
                    Console.WriteLine($"- {a.Name}  | 방어력 +{a.Defence} |  {a.Description} | {a.Price} G ");
                }
                else if (a.Defence == 0)
                {
                    Console.WriteLine($"- {a.Name}  | 공격력 +{a.Attack} |  {a.Description} | {a.Price} G");
                }
            }

            Console.WriteLine("\r\n1. 아이템 구매\r\n2. 아이템 판매\r\n0. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");

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
    }
}
