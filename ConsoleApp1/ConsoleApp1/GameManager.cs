
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
            Console.WriteLine("구매하실 아이템 번호를 정확히 입력해주세요 ");
            bool isNum = int.TryParse(Console.ReadLine(), out int num);

            if (isNum && num >= 1 && num <= ItemManager.Instance.itemList.Count)
            {
                
                Item foundBuyItem = ItemManager.Instance.itemList[num - 1];
                if (foundBuyItem.IsPurchased == false)
                {
                    bool canBuy = Player.Instance.Gold >= foundBuyItem.Price;
                    if (canBuy)
                    {
                        Inventory.Instance.AddItem(foundBuyItem);
                        foundBuyItem.IsPurchased = true;
                        Console.WriteLine($"골드가 {foundBuyItem.Price} 만큼 차감되었습니다.");
                        Player.Instance.Gold -= foundBuyItem.Price;
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
                    Console.WriteLine("이미 구매한 아이템입니다");
                    Console.WriteLine("상점으로 돌아갑니다");
                    Console.ReadKey();
                    Scene.LoadShop();
                }

            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.상점창으로 돌아갑니다");
                Console.ReadKey();
                Scene.LoadShop();
            }

        }

        public static void SellItem()
        {
            Console.Clear();
            Console.WriteLine($"[보유 골드]\n{Player.Instance.Gold} G\r\n\n[아이템 목록]");
            for(int i = 0;i<Inventory.Instance.inventoryList.Count;i++) 
            {
                Item c=Inventory.Instance.inventoryList[i];
                Console.Write($"{- i}");
                if (c.Type == 0)
                {
                    Console.WriteLine($"  {c.Name} | {c.Description}");
                }
                else if (c.Type == 1)
                {
                    Console.WriteLine($"  {c.Name} | 방어력 +{c.Defence} | {c.Description}");
                }
                else if(c.Type==2)
                {
                    Console.WriteLine($"  {c.Name} | 공격력 +{c.Attack} | {c.Description}");
                }
                
            }
            Console.WriteLine("판매하실 아이템의 번호를 정확히 입력해주세요");
            bool isNum=int.TryParse( Console.ReadLine(),out int num);
            
            if(isNum&&num>=1&&num<=Inventory.Instance.inventoryList.Count)
            {
                Item foundInventory= Inventory.Instance.inventoryList[num-1];
                int SoldPrice=Convert.ToInt32(Math.Ceiling(foundInventory.Price * 0.85));
                Player.Instance.Gold += SoldPrice;
                Console.WriteLine($"아이템: {foundInventory.Name}을/를 판매하였습니다");
                Console.WriteLine($"판매 금액: {SoldPrice} G를 획득하였습니다");
                Console.WriteLine($"현재 보유중인 금액은 {Player.Instance.Gold} G 입니다");
                if (foundInventory.Equip == 1)
                {
                    foundInventory.Equip = 0;
                    Console.ReadKey();
                    Scene.LoadShop();
                }
                else
                {
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
        }
        public static void EquipItem()
        {
            Console.WriteLine("장착하고 싶은 아이템의 번호를 정확히 입력해주세요");
            bool isNum = int.TryParse(Console.ReadLine(), out int num);

            if (isNum && num >= 1 && num <= Inventory.Instance.inventoryList.Count)
            {
                Item foundEquipItem = Inventory.Instance.inventoryList[num - 1];
                Console.WriteLine($"선택한 아이템: {foundEquipItem.Name}");
                if (Player.Instance.EquipAccessories != null && foundEquipItem.Type == 0)
                {
                    Player.Instance.EquipAccessories.Equip = 0;
                    foundEquipItem.Equip = 1;
                    Console.WriteLine($"아이템: {foundEquipItem.Name} 을 장착하였습니다");
                    Console.ReadKey(true);
                    Scene.LoadInventory();
                }
                else if (Player.Instance.EquipArmor.Defence >= 1 && foundEquipItem.Type == 1)
                {
                    Player.Instance.EquipArmor.Equip = 0;
                    foundEquipItem.Equip = 1;
                    Console.WriteLine($"아이템: {foundEquipItem.Name} 을 장착하였습니다");
                    Console.ReadKey(true);
                    Scene.LoadInventory();
                }
                else if (Player.Instance.EquipWeapon.Attack >= 1 && foundEquipItem.Type == 2)
                {
                    Player.Instance.EquipWeapon.Equip = 0;
                    foundEquipItem.Equip = 1;
                    Console.WriteLine($"아이템: {foundEquipItem.Name} 을 장착하였습니다");
                    Console.ReadKey(true);
                    Scene.LoadInventory();
                }
                else if (foundEquipItem.Equip == 0)
                {
                    foundEquipItem.Equip = 1;
                    Console.WriteLine($"아이템: {foundEquipItem.Name} 을 장착하였습니다");
                    Console.ReadKey(true);
                    Scene.LoadInventory();
                }
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
            Console.WriteLine("장착 해제하고 싶은 아이템의 번호를 정확히 입력해주세요");
            bool isNum = int.TryParse(Console.ReadLine(), out int num);
            if(isNum&&num>=1&&num<=Inventory.Instance.inventoryList.Count)
            {
                Item foundUnEquipItem = Inventory.Instance.inventoryList[num - 1];
                foundUnEquipItem.Equip = 0;
                Console.WriteLine($"아이템: {foundUnEquipItem.Name} 을 장착 해지하였습니다");
                Console.ReadKey(true);
                Scene.LoadInventory();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다\n인벤토리 화면으로 돌아갑니다");
                Console.ReadKey(true);
                Scene.LoadInventory();
            }

        }
        

    }



} 
