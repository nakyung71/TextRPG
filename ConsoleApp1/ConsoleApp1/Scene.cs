using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace RtanRPG
{
 
    class Scene
    {
        //스티팅 씬과 인벤토리는 후에 다른 클래스에서도 여러 방면으로 호출되어서 public으로 하였고,
        //스태틱으로 대부분 메서드들을 구현한 이유는, 첫번쨰로 메인 메서드가 스태틱이고, 씬에 있는 메서드들은 Main과 밀접한 연관이 있는 메서드들이기 때문이다.
     
        static void Main(string[] args)
        {
            WriteYourName();
        }

        public static void WriteYourName()
        {
            Console.WriteLine("이릅을 입력해주세요");
            while (true)
            {
                string input = Console.ReadLine();
                Player.Instance.Name = input;
                if(input!=null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다");
                }
            }
            Console.WriteLine($"{Player.Instance.Name} 님, 스파르타 던전에 오신 것을 환영합니다.");
            Console.ReadKey();
            LoadStartingScene() ;
        }

            



        public static void LoadStartingScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.\r\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\r\n");
            Console.WriteLine("1.상태 보기\r\n2.인벤토리\r\n3.상점\r\n4.던전 입장\r\n5.휴식하기\n원하시는 행동을 입력해주세요.\r\n >> ");
            
            //키를 잘못 입력했을 경우 다시 입력을 받기 위하여 while문으로 반복을 하였고,
            //사실 여기에서는 선택지에 0이 없기 때문에 굳이 isnumber을 확인하는  과정이 필요 없는 것 같다
            //왜냐하면 문자를 입력해도 0이 나올것이니 무조건 숫자만 나온다
            //그러나 나중에 선택지에 0이 나오기도 하고 복사 붙여넣기가 편해서 이렇게 하였다. 
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
            //플레이어 클래스를 싱글톤화 해서 이를 호출하여 상태창에 플레이어 정보를 기록하였다.
            //플레이어 클래스를 싱글톤으로 설정한 이유는 이 게임은 플레이어가 여러명이 아니기 떄문이다.
            //만약 내가 플레리어 클래스를 싱글톤화 하지 않고 실수로 Player의 인스턴스를 더 만들 경우 정보 관리가 제대로 안될 수 있다고 생각했다.
            Console.Clear();
            Player.Instance.UpdateEquippedItems();
            Console.WriteLine("상태 보기\r\n캐릭터의 정보가 표시됩니다.\r\n\r\n");
            Console.WriteLine($"Lv. {Player.Instance.Level}\r\n이름: {Player.Instance.Name} ({Player.Instance.Job})  ");
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
                else if (isNumber)
                {
                    if (num == 0)
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
        public static void LoadInventory()
        {
            Console.Clear();
            Player.Instance.UpdateEquippedItems();
            Console.WriteLine("인벤토리\r\n보유 중인 아이템을 관리할 수 있습니다.\r\n\r\n[아이템 목록]\r\n");

            //원래 foreach를 통한 방법도 생각했지만, 결국 구현해야하는건 '아이템의 번호'를 통한 구매이기 때문에,
            ////foreach보다는 for문을 사용해서 인덱스로 관리하는것이 적합하다고 생각했다


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
            //장착된 아이템 부분이 제일 구현하기 힘들었다. 왜냐하면 캐릭터가 시작할때 아이템을 장착하지 않았기 때문이다. 
            //그래서 착용 아이템에 계속 null값이 나왔다.처음에는 단순히 null병합 연산자(??)를 사용하고자 하였으나, 생각보다 다른 구간에서도 이 null값때문에 문제가 많이 일어났다.
            //이를 해결한 방법은 캐릭터의 아이템의 set 값의 조정을 통하여 캐릭터의 아이템이 null이면 그냥 디폴트 new 아이템을 return하게 설정하였다.
            //default 아이템은 이름이 공백 문자열로 되어있어 보이지 않는다. (자세한건 아이템 클래스에 있다)
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

            //장착 관리 화면이고, 예시에서는 방어력이 0인 아이템들은 방어력을 표시 안하는 방식으로 구현이 되어있어서, if문을 통하여 이를 구련하였다
            //그리고 착용여부를 판단하는 Item의 속성 IsEquipped를 통하여 [E]를 넣는 아이템들을 필터링하였다. 

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
                Console.Write($"- {i + 1}");
                Console.Write($"  {a.Name}  |");
                if (a.Defence != 0)
                {
                    Console.Write($"  방어력 +{a.Defence}  |");
                }
                if (a.Attack != 0)
                {
                    Console.Write($"  공격력 +{a.Attack}  |");
                }
                Console.Write($"  {a.Description}  |");
                if(a.IsPurchased==true) //이 또한 아이템의 속성에 넣어서 해당되면 판매완료로 바꿀 수 있게 했다
                Console.Write($" [판매완료]\n");
                if(a.IsPurchased==false)
                Console.Write($"  {a.Price} G\n");
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
                        //단순히 hp를 설정하는 것만 담당하면 Func를 사용할 필요 없지만, 후에 던전에서 다른 공식으로 Hp를 조정해야하는 경우가 있어서 같이 쓰려고 이렇게 설정하였다. 
                        Player.Instance.ChangeGold(-500);
                        Console.WriteLine($"내 체력이 회복되었다. 현재 체력은 {Player.Instance.Health}, 보유 금액은{Player.Instance.Gold} G 이다");
                        Console.WriteLine("여관으로 돌아갑니다");
                        Console.ReadKey();
                        LoadInn();
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Gold 가 부족합니다. 현재 보유중인 돈은 {Player.Instance.Gold} G 입니다");
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
