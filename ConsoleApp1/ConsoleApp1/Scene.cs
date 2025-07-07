using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{

    class Scene
    {
        static void Main(string[] args)
        {

            LoadStartingScene();
        }

        static void LoadStartingScene()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n");
            Console.WriteLine("1.상태 보기\r\n2.인벤토리\r\n3.상점\r\n\r\n원하시는 행동을 입력해주세요.\r\n >> ");

            while (true)
            {
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out int num);
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
                Console.WriteLine($"Lv. {Player.Instance.Level}      \r\n{Player.Instance.Name} ( 전사 )\r\n공격력 : {Player.Instance.Attack}\r\n방어력 : {Player.Instance.Defence}\r\n체 력 : {Player.Instance.Health}\r\nGold : {Player.Instance.Gold} G");
                Console.WriteLine("\r\n\r\n0. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");


            }
            static void LoadInventory()
            {
                Console.Clear();
                Console.WriteLine("인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\r\n");
                Console.WriteLine("[아이템 목록]\r\n- [E]무쇠갑옷      | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.\r\n- [E]스파르타의 창  | 공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.\r\n- 낡은 검         | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.");
                Console.WriteLine("\r\n\r\n1. 장착 관리\r\n2. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
            }
            static void LoadShop()
            {
                Console.Clear();
                Console.WriteLine("상점\r\n필요한 아이템을 얻을 수 있는 상점입니다.\r\n\r\n[보유 골드]\r\n800 G\r\n");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("1. 아이템 구매\r\n0. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");
                ItemManager.Instance.itemList.
            
            }
           
        

        
    }
}
