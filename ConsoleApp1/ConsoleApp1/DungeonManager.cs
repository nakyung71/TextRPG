using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanRPG
{
    internal class Dungeon
    {
        //던전을 다 각각 구성하기보다는 권장 방어력, 기본 지급 골드, 추가지급 골드, 그리고 던전 난이도 빼고는 다 동일한 요소를 가지고 있었기에
        //던전 인스턴스를 3개 만들어 EnterDungeon()을 통해 각 인스턴스들을 관리했다. 후에 던전을 더 추가할 경우 편하게 하기 위함이다.  
        public int SuggestedDefence
            { get; set; }
        public int DefaultGold
            { get; set; }
        public int AdditionalGold
            { get; set; }
        public string DungeonLevel
            { get; set; }

        static Dungeon dungeon1 = new Dungeon
        {
            SuggestedDefence = 5,
            DefaultGold = 1000,
            AdditionalGold = 1000,
            DungeonLevel="쉬움"
        };
        static Dungeon dungeon2 = new Dungeon
        {
            SuggestedDefence = 11,
            DefaultGold = 1700,
            AdditionalGold = 2000,
            DungeonLevel="보통"
            
        };
        static Dungeon dungeon3 = new Dungeon
        {
            SuggestedDefence = 5,
            DefaultGold = 2500,
            AdditionalGold = 3000,
            DungeonLevel = "어려움"
        };


        public static void LoadDungeon()
        {
            Console.Clear();
            Player.Instance.UpdateEquippedItems();
            Console.WriteLine("던전 입구로 오자 주변의 공기가 싸늘해진것이 느껴진다");
            if (Player.Instance.Health > 0)
            {
                Console.WriteLine("어느 던전으로 들어가겠는가?");
                Console.WriteLine("1. 쉬운 던전\t| 방어력 5 이상 권장");
                Console.WriteLine("2. 일반 던전\t| 방어력 11 이상 권장");
                Console.WriteLine("3. 어려운 던전\t| 방어력 17 이상 권장");
                Console.WriteLine("4. 빛나는 거울 (직업 변경)");
                Console.WriteLine("5. 나가기");
                Console.WriteLine(">>>");
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
                            LoadEasy();
                            break;
                        }
                        else if (num == 2)
                        {
                            LoadNormal();
                        }
                        else if (num == 3)
                        {
                            LoadHard();
                            break;
                        }
                        else if (num == 4)
                        {
                            LoadMirrorRoom();
                            break;
                        }
                        else if (num == 5)
                        {
                            Scene.LoadStartingScene();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }


                    }
                }
            }
            else 
            {

                Console.WriteLine("HP가 0이기 때문에 던전에 들어갈 수 없습니다.");
                Console.ReadKey();
                Scene.LoadStartingScene();
            }

        }


        public void EnterDungeon()
        {
            Console.Clear();
            int defenceFinal = Player.Instance.Defence - SuggestedDefence;
            Random rand = new Random();
            int healthLostFinal = rand.Next(20 - defenceFinal, 35 - defenceFinal);
            int attackFinal = Player.Instance.Attack + Player.Instance.EquipWeapon.Attack;
            int GoldEarnFinal = DefaultGold + Convert.ToInt32(Math.Ceiling(AdditionalGold * 0.01 * (rand.Next(attackFinal, attackFinal * 2))));
            Console.WriteLine($"던전 클리어\r\n축하합니다!!\r\n{DungeonLevel} 난이도 던전을 클리어 하였습니다.\r\n");
            int beforeGold = Player.Instance.Gold;
            int beforeHealth = Player.Instance.Health;
            Player.Instance.ChangeGold(GoldEarnFinal);
            Player.Instance.ChangeHealth(-healthLostFinal);
            Player.Instance.ChangeExp(100);
            Console.WriteLine($"[탐험 결과]\r\n체력{beforeHealth} -> {Player.Instance.Health}");
            Console.WriteLine($"Gold {beforeGold} G-> {Player.Instance.Gold} G ");
            Console.WriteLine("\r\n\r\n0.나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n >>");
            Console.ReadKey();
            LoadDungeon();
        }
        static void LoadEasy()
        {
            if (Player.Instance.Defence + Player.Instance.EquipArmor.Defence >= 5)
            {
                dungeon1.EnterDungeon();
            }
            else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 11);
                if (randomNumber <= 6)
                {
                    dungeon1.EnterDungeon();
                }
                else
                {
                    Console.WriteLine("던전 탐험에 실패하였습니다\nHP가 절반으로 감소합니다");
                    Player.Instance.ScaleHealth(hp => Convert.ToInt32(Math.Ceiling(hp * 0.5)));//람다식을 통하여 int를 넣으면 int를 반환하는 메서드를 만들어 매개변수 func에 전달했다.
                    Console.ReadKey(true);
                    LoadDungeon();
                }
            }
        }


        static void LoadNormal()
        {
            if (Player.Instance.Defence + Player.Instance.EquipArmor.Defence >= 11)
            {
                dungeon2.EnterDungeon();
            }
            else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 11);
                if (randomNumber <= 6)
                {
                    dungeon2.EnterDungeon(); 
                }
                else
                {
                    Console.WriteLine("던전 탐험에 실패하였습니다\nHP가 절반으로 감소합니다");
                    Player.Instance.ScaleHealth(hp=>Convert.ToInt32(Math.Ceiling(hp * 0.5)));
                    Console.ReadKey(true);
                    LoadDungeon();
                }
            }

        }

        static void LoadHard()
        {
            if (Player.Instance.Defence + Player.Instance.EquipArmor.Defence >= 17)
            {
                dungeon3.EnterDungeon();
            }
            else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 11);
                if (randomNumber <= 6)
                {
                    dungeon3.EnterDungeon();
                }
                else
                {
                    Console.WriteLine("던전 탐험에 실패하였습니다\nHP가 절반으로 감소합니다");
                 
                    Player.Instance.ScaleHealth((int hp) => Convert.ToInt32(Math.Ceiling(hp * 0.5)));
                    Console.ReadKey(true);
                    LoadDungeon();
                }
            }
        }

        static void LoadMirrorRoom() //도전 과제에는 없었지만 매우 간단하게 직업을 배열로 만들고+ 랜덤으로 인덱스 번호 뽑아서 랜덤으로 직업을 지정해줬다. 
        {
            Console.Clear();
            Console.WriteLine("던전의 숨겨진 공간에 들어서자 수많은 거울이 당신을 비춘다.");
            Console.WriteLine("거울에 손을 대면 강력한 힘이 당신의 직업을 바꾸게 도움을 줄 것 같다\n\n\n\n\n");
            Console.WriteLine("직업을 바꾸시겠습니까?\n\n>>>");
            Console.WriteLine("1. 예 2. 아니요");
            while (true)
            {
                string inputKey = Console.ReadLine();
                bool input=int.TryParse(inputKey, out int num);
                if (num == 1)
                {
                    Player.Instance.RandomJob();
                    Console.WriteLine($"\n당신의 직업이 {Player.Instance.Job} 가 되었습니다");
                    Console.ReadKey();
                    LoadDungeon();
                    break;
                }
                else if (num == 2)
                {
                    LoadDungeon();
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
