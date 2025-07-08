
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RtanRPG
{
    class GameManager
    {
        public static void BuyItem()
        {
            //일단 아이템을 골라야겠지
            Console.WriteLine("구매하실 아이템 이름을 정확히 입력해주세요(공백 포함)");
            string input=Console.ReadLine();
            Item foundItem= Scene.items.itemList.Find(i=>i.Name==input);
            if (foundItem != null )
            {
                Console.WriteLine($"{foundItem.Name} 을 정말 구매하시겠습니까?");
                Console.WriteLine("1. 예 \r\n2. 아니요");

                Console.WriteLine("");
                bool canBuy = Scene.currentPlayer.Gold >= foundItem.Price;
                if( canBuy )
                {
                    Scene.inventory.AddItem(foundItem);
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다");
                }


            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Console.WriteLine("");
                    
            }

            //만약 플레이어가 입력한 아이템 이름이 아이템 상점에 있는 아이템 이름 중 하나랑 같다면
            //그 아이템을 호출한다
            //살수 있는지 테스트를 해본다
            //플레이어가 가진 골드보다 물건이 비싸면 못삼
            //
            //그 다음 산 물건을 리스트에 넣어준다
            //if (Scene.currentPlayer.Gold < Scene.) ;

        }
        void SellItem()
        {

        }

        


    }



} 
