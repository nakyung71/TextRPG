using System.ComponentModel.Design;

namespace ConsoleApp1
{

    class Scene
    {

        public string Name = "김나경";
        public int Gold = 1000;



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
                    else if (num==3)
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
            static void LoadStatus()
            {
                Console.Clear();
                Console.WriteLine("상태 보기\r\n캐릭터의 정보가 표시됩니다.\r\n\r\n");
                Console.WriteLine("Lv. 01      \r\nChad ( 전사 )\r\n공격력 : 10\r\n방어력 : 5\r\n체 력 : 100\r\nGold : 1500 G");
                Console.WriteLine("\r\n\r\n0. 나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n>>");

            }
            static void LoadInventory()
            {

            }
            static void LoadShop()
            {

            }


        }
    }
}
