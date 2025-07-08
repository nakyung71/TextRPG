
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
            Console.WriteLine("구매하실 아이템 이름을 정확히 입력해주세요 (공백 포함)");
            string inputItemName=Console.ReadLine();
            Item foundItem= Scene.items.itemList.Find(i=>i.Name==inputItemName);
            if (foundItem != null )
            {
                bool canBuy = Scene.currentPlayer.Gold >= foundItem.Price;
                if (canBuy)
                {
                    Scene.inventory.AddItem(foundItem);
                    Console.WriteLine($"골드가 {foundItem.Price} 만큼 차감되었습니다.");
                    Scene.currentPlayer.Gold-=foundItem.Price;
                    Console.WriteLine("상점으로 돌아갑니다");
                    Console.ReadKey();
                    Scene.LoadShop();
                }
                else
                {
                    Console.WriteLine("골드가 부족합니다");
                    Console.WriteLine("상점으로 돌아갑니다");
                    Console.ReadKey();
                    Scene.LoadShop();
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Console.WriteLine("상점으로 돌아갑니다");
                Console.ReadKey();
                Scene.LoadShop();
            }

            //만약 플레이어가 입력한 아이템 이름이 아이템 상점에 있는 아이템 이름 중 하나랑 같다면
            //그 아이템을 호출한다
            //살수 있는지 테스트를 해본다
            //플레이어가 가진 골드보다 물건이 비싸면 못삼
            //
            //그 다음 산 물건을 리스트에 넣어준다
            //if (Scene.currentPlayer.Gold < Scene.) ;

        }
        public static void SellItem()
        {
            Console.Clear();
            Console.WriteLine($"[보유 골드]\n{Scene.currentPlayer.Gold} G\r\n\n[아이템 목록]");
            foreach (Item c in Scene.inventory.inventoryList)
            {
                if (c.Attack == 0)
                {
                    Console.WriteLine($"- {c.Name} | 방어력 +{c.Defence} | {c.Description}");
                }
                if (c.Defence == 0)
                {
                    Console.WriteLine($"- {c.Name} | 공격력 +{c.Attack} | {c.Description}");
                }
                
            }
            Console.WriteLine("판매하실 아이템의 정확한 명칭을 입력해주세요 (공백 포함)");
            string inputSellingItemName= Console.ReadLine();
            Item foundInventory = Scene.inventory.inventoryList.Find(j=>j.Name== inputSellingItemName);
            if(foundInventory != null)
            {
                int SoldPrice=Convert.ToInt32(Math.Floor(foundInventory.Price * 0.7));
                Scene.currentPlayer.Gold += SoldPrice;
                Console.WriteLine($"아이템: {inputSellingItemName}을/를 판매하였습니다");
                Console.WriteLine($"판매 금액: {SoldPrice} G를 획득하였습니다");
                Console.WriteLine($"현재 보유중인 금액은 {Scene.currentPlayer.Gold} G 입니다");
                if(foundInventory.Equip==1)
                {
                    foundInventory.Equip = 0;
                }
                else Console.ReadKey();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다");
                Console.WriteLine("상점으로 돌아갑니다");
                Console.ReadKey();
                Scene.LoadShop();
            }
        }
        public static void EquipItem()
        {
            Console.WriteLine("장착하고 싶은 아이템을 선택하세요");
            string inputEquipItemName=Console.ReadLine();
            Item foundEquipItem= Scene.inventory.inventoryList.Find(h=>h.Name== inputEquipItemName);
            if (foundEquipItem != null)
            {
                foundEquipItem.Equip = 1;
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다\n인벤토리 화면으로 돌아갑니다");
                Console.ReadKey(true);
                Scene.LoadInventory();
            }

        }
        public static void UnEquipItem()
        {
            console
        }

        


    }



} 
