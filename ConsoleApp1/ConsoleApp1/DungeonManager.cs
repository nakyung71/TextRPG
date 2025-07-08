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

        }
        static void LoadEasy()
        {
            if (Scene.currentPlayer.Defence + Scene.currentPlayer.EquipArmor.Defence >= 5)
            {

            }
            else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 11);
                if (randomNumber <= 6)
                {

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

        }

        static void LoadNormal()
        {
            if (Scene.currentPlayer.Defence + Scene.currentPlayer.EquipArmor.Defence >= 11)
            {

            }
            else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 11);
                if (randomNumber <= 6)
                {

                }
                else
                {
                    Console.WriteLine("던전 탐험에 실패하였습니다\nHP가 절반으로 감소합니다");
                    Scene.currentPlayer.Health = Convert.ToInt32(Math.Ceiling(Scene.currentPlayer.Health * 0.5));
                }
            }

        }
        public static void LoadHard()
        {
            if (Scene.currentPlayer.Defence + Scene.currentPlayer.EquipArmor.Defence >= 17)
            {

            }
            else
            {
                Random rand = new Random();
                int randomNumber = rand.Next(1, 11);
                if (randomNumber <= 6)
                {

                }
                else
                {
                    Console.WriteLine("던전 탐험에 실패하였습니다\nHP가 절반으로 감소합니다");
                    Scene.currentPlayer.Health = Convert.ToInt32(Math.Ceiling(Scene.currentPlayer.Health * 0.5));
                }
            }
        }
        




       

    }
}
