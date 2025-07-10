using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RtanRPG
{
    internal class Dungeon
    {
        public static void LoadDungeon()
        {
            Console.Clear();
            Player.Instance.UpdateEquippedItems();
            Console.WriteLine("던전 입구로 오자 주변의 공기가 싸늘해진것이 느껴졌다");
            if (Player.Instance.Health >= 0)
            {
                Console.WriteLine("어느 던전으로 들어가겠는가?");
                Console.WriteLine("1. 쉬운 던전\t| 방어력 5 이상 권장");
                Console.WriteLine("2. 일반 던전\t| 방어력 11 이상 권장");
                Console.WriteLine("3. 어려운 던전\t| 방어력 17 이상 권장");
                Console.WriteLine("4. 나가기");
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
                Scene.LoadStartingScene();
            }

        }


        static void LoadEasy()
        {
            if (Player.Instance.Defence + Player.Instance.EquipArmor.Defence >= 5)
            {
                EasyDungeon();
            }
            else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 11);
                if (randomNumber <= 6)
                {
                    EasyDungeon();
                }
                else
                {
                    Console.WriteLine("던전 탐험에 실패하였습니다\nHP가 절반으로 감소합니다");
                    Player.Instance.Health = Convert.ToInt32(Math.Ceiling(Player.Instance.Health * 0.5));
                    Console.ReadKey(true);
                    LoadDungeon();
                }
            }
        }


        static void EasyDungeon()
        {

            int defenceFinal = Player.Instance.Defence - 5;
            Random rand = new Random();
            int healthLostFinal=rand.Next(20-defenceFinal, 35-defenceFinal);
            int attackFinal= Player.Instance.Attack+Player.Instance.EquipWeapon.Attack;
            int GoldEarnFinal = 1000 + Convert.ToInt32(Math.Ceiling(1000*0.01*(rand.Next(attackFinal, attackFinal * 2))));

            Console.WriteLine("던전 클리어\r\n축하합니다!!\r\n쉬운 던전을 클리어 하였습니다.\r\n");
            if (Player.Instance.Health <= healthLostFinal)
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Player.Instance.Health} -> {0}");
            }
            else
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Player.Instance.Health} -> {Player.Instance.Health - healthLostFinal}");
            }
            Console.WriteLine($"Gold {Player.Instance.Gold} G-> {Player.Instance.Gold+GoldEarnFinal} G ");
            Console.WriteLine("\r\n\r\n0.나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n >>");

            Player.Instance.ChangeGold(GoldEarnFinal); 
            Player.Instance.ChangeHealth(- healthLostFinal);
            Player.Instance.ChangeExp(100);
            Console.ReadKey ();
            LoadDungeon();


        }


        static void LoadNormal()
        {
            if (Player.Instance.Defence + Player.Instance.EquipArmor.Defence >= 11)
            {
                NormalDungeon();
            }
            else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 11);
                if (randomNumber <= 6)
                {
                    NormalDungeon();   
                }
                else
                {
                    Console.WriteLine("던전 탐험에 실패하였습니다\nHP가 절반으로 감소합니다");
                    Player.Instance.Health = Convert.ToInt32(Math.Ceiling(Player.Instance.Health * 0.5));
                    Console.ReadKey(true);
                    LoadDungeon();
                }
            }

        }


        static void NormalDungeon()
        {
            int defenceFinal = Player.Instance.Defence - 11;
            Random rand = new Random();
            int healthLostFinal = rand.Next(20 - defenceFinal, 35 - defenceFinal);
            int attackFinal = Player.Instance.Attack + Player.Instance.EquipWeapon.Attack;
            int GoldEarnFinal = 1700 + Convert.ToInt32(Math.Ceiling(2000 * 0.01 * (rand.Next(attackFinal, attackFinal * 2))));

            Console.WriteLine("던전 클리어\r\n축하합니다!!\r\n노말 던전을 클리어 하였습니다.\r\n");
            if (Player.Instance.Health <= healthLostFinal)
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Player.Instance.Health} -> {0}");
            }
            else
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Player.Instance.Health} -> {Player.Instance.Health - healthLostFinal}");
            }
            Console.WriteLine($"Gold {Player.Instance.Gold} G-> {Player.Instance.Gold + GoldEarnFinal} G ");
            Console.WriteLine("\r\n\r\n0.나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n >>");

            Player.Instance.ChangeGold(GoldEarnFinal);
            Player.Instance.ChangeHealth(-healthLostFinal);
            Player.Instance.ChangeExp(100);
            Console.ReadKey();
            LoadDungeon();


        }
        public static void LoadHard()
        {
            if (Player.Instance.Defence + Player.Instance.EquipArmor.Defence >= 17)
            {
                HardDungeon();
            }
            else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 11);
                if (randomNumber <= 6)
                {
                    HardDungeon();
                }
                else
                {
                    Console.WriteLine("던전 탐험에 실패하였습니다\nHP가 절반으로 감소합니다");
                    Player.Instance.Health = Convert.ToInt32(Math.Ceiling(Player.Instance.Health * 0.5));
                    Console.ReadKey(true);
                    LoadDungeon();
                }
            }
        }
        static void HardDungeon()
        {
            int defenceFinal = Player.Instance.Defence - 17;
            Random rand = new Random();
            int healthLostFinal = rand.Next(20 - defenceFinal, 35 - defenceFinal);
            int attackFinal = Player.Instance.Attack + Player.Instance.EquipWeapon.Attack;
            int GoldEarnFinal = 2500 + Convert.ToInt32(Math.Ceiling(3000 * 0.01 * (rand.Next(attackFinal, attackFinal * 2))));

            Console.WriteLine("던전 클리어\r\n축하합니다!!\r\n하드 던전을 클리어 하였습니다.\r\n");
            if (Player.Instance.Health <= healthLostFinal)
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Player.Instance.Health} -> {0}");
            }
            else
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Player.Instance.Health} -> {Player.Instance.Health - healthLostFinal}");
            }
            Console.WriteLine($"Gold {Player.Instance.Gold} G-> {Player.Instance.Gold + GoldEarnFinal} G ");
            Console.WriteLine("\r\n\r\n0.나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n >>");

            Player.Instance.ChangeGold(GoldEarnFinal);
            Player.Instance.ChangeHealth(-healthLostFinal);
            Player.Instance.ChangeExp(100);
            Console.ReadKey();
            LoadDungeon();
        }
        




       

    }
}
