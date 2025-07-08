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
            Scene.currentPlayer.UpdateEquippedItems();
            Console.WriteLine("던전 입구로 오자 주변의 공기가 싸늘해진것이 느껴졌다\n어느 던전으로 들어가겠는가?");
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
        static void LoadEasy()
        {
            if (Scene.currentPlayer.Defence + Scene.currentPlayer.EquipArmor.Defence >= 5)
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
                    Scene.currentPlayer.Health = Convert.ToInt32(Math.Ceiling(Scene.currentPlayer.Health * 0.5));
                }
            }
        }
        static void EasyDungeon()
        {
            //일단 20~35 랜덤값에 내 방어력-권장방어력만큼 범위조절
            //일단 그럼 내 방어력-권장방어력 구해야지
            int defenceFinal = Scene.currentPlayer.Defence - 5;
            Random rand = new Random();
            int healthLostFinal=rand.Next(20-defenceFinal, 35-defenceFinal);
            int attackFinal= Scene.currentPlayer.Attack+Scene.currentPlayer.EquipWeapon.Attack;
            int GoldEarnFinal = 1000 + Convert.ToInt32(Math.Ceiling(1000*0.01*(rand.Next(attackFinal, attackFinal * 2))));

            Console.WriteLine("던전 클리어\r\n축하합니다!!\r\n쉬운 던전을 클리어 하였습니다.\r\n");
            if (Scene.currentPlayer.Health <= healthLostFinal)
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Scene.currentPlayer.Health} -> {0}");
            }
            else
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Scene.currentPlayer.Health} -> {Scene.currentPlayer.Health - healthLostFinal}");
            }
            Console.WriteLine($"Gold {Scene.currentPlayer.Gold} G-> {Scene.currentPlayer.Gold+GoldEarnFinal} G ");
            Console.WriteLine("\r\n\r\n0.나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n >>");

            Scene.currentPlayer.Gold += GoldEarnFinal;
            Scene.currentPlayer.Health -= healthLostFinal;
            Console.ReadKey ();
            LoadDungeon();


        }

        static void LoadNormal()
        {
            if (Scene.currentPlayer.Defence + Scene.currentPlayer.EquipArmor.Defence >= 11)
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
                    Scene.currentPlayer.Health = Convert.ToInt32(Math.Ceiling(Scene.currentPlayer.Health * 0.5));
                }
            }

        }
        static void NormalDungeon()
        {
            int defenceFinal = Scene.currentPlayer.Defence - 11;
            Random rand = new Random();
            int healthLostFinal = rand.Next(20 - defenceFinal, 35 - defenceFinal);
            int attackFinal = Scene.currentPlayer.Attack + Scene.currentPlayer.EquipWeapon.Attack;
            int GoldEarnFinal = 1700 + Convert.ToInt32(Math.Ceiling(2000 * 0.01 * (rand.Next(attackFinal, attackFinal * 2))));

            Console.WriteLine("던전 클리어\r\n축하합니다!!\r\n노말 던전을 클리어 하였습니다.\r\n");
            if (Scene.currentPlayer.Health <= healthLostFinal)
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Scene.currentPlayer.Health} -> {0}");
            }
            else
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Scene.currentPlayer.Health} -> {Scene.currentPlayer.Health - healthLostFinal}");
            }
            Console.WriteLine($"Gold {Scene.currentPlayer.Gold} G-> {Scene.currentPlayer.Gold + GoldEarnFinal} G ");
            Console.WriteLine("\r\n\r\n0.나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n >>");

            Scene.currentPlayer.Gold += GoldEarnFinal;
            Scene.currentPlayer.Health -= healthLostFinal;
            Console.ReadKey();
            LoadDungeon();


        }
        public static void LoadHard()
        {
            if (Scene.currentPlayer.Defence + Scene.currentPlayer.EquipArmor.Defence >= 17)
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
                    Scene.currentPlayer.Health = Convert.ToInt32(Math.Ceiling(Scene.currentPlayer.Health * 0.5));
                }
            }
        }
        static void HardDungeon()
        {
            int defenceFinal = Scene.currentPlayer.Defence - 17;
            Random rand = new Random();
            int healthLostFinal = rand.Next(20 - defenceFinal, 35 - defenceFinal);
            int attackFinal = Scene.currentPlayer.Attack + Scene.currentPlayer.EquipWeapon.Attack;
            int GoldEarnFinal = 2500 + Convert.ToInt32(Math.Ceiling(3000 * 0.01 * (rand.Next(attackFinal, attackFinal * 2))));

            Console.WriteLine("던전 클리어\r\n축하합니다!!\r\n하드 던전을 클리어 하였습니다.\r\n");
            if (Scene.currentPlayer.Health <= healthLostFinal)
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Scene.currentPlayer.Health} -> {0}");
            }
            else
            {
                Console.WriteLine($"[탐험 결과]\r\n체력{Scene.currentPlayer.Health} -> {Scene.currentPlayer.Health - healthLostFinal}");
            }
            Console.WriteLine($"Gold {Scene.currentPlayer.Gold} G-> {Scene.currentPlayer.Gold + GoldEarnFinal} G ");
            Console.WriteLine("\r\n\r\n0.나가기\r\n\r\n원하시는 행동을 입력해주세요.\r\n >>");

            Scene.currentPlayer.Gold += GoldEarnFinal;
            Scene.currentPlayer.Health -= healthLostFinal;
            Console.ReadKey();
            LoadDungeon();
        }
        




       

    }
}
