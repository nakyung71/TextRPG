using ConsoleApp1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class GameManager
    {
        public static GameManager Instance

        List<Item> itemLIst = new List<Item>();
        itemLIst.Add(new Item
            {Name = "수련자 갑옷",
            Attack = 0,
            Defence = 5,
            Description = "수련에 도움을 주는 갑옷입니다",
            Price = 1000});

            itemLIst.Add(new Item
            {
                Name = "무쇠갑옷",
                Attack = 0,
                Defence = 9,
                Description = "무쇠로 만들어져 튼튼한 갑옷입니다. ",
                Price = 1200
            });

itemLIst.Add(new Item
{
    Name = "스파르타의 갑옷",
    Attack = 0,
    Defence = 15,
    Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
    Price = 3500
});

itemLIst.Add(new Item
{
    Name = "낡은 검",
    Attack = 2,
    Defence = 0,
    Description = "쉽게 볼 수 있는 낡은 검 입니다.",
    Price = 600
});
itemLIst.Add(new Item
{
    Name = "청동 도끼",
    Attack = 5,
    Defence = 0,
    Description = " 어디선가 사용됐던거 같은 도끼입니다.",
    Price = 1500
});
itemLIst.Add(new Item
{
    Name = "스파르타의 창",
    Attack = 7,
    Defence = 0,
    Description = "스파르타의 전사들이 사용했다는 전설의 창입니다",
    Price = 3500
});
itemLIst.Add(new Item
{
    Name = "귀여운 토끼주먹",
    Attack = 20,
    Defence = 0,
    Description = "귀여운 토끼의 주먹입니다",
    Price = 10000
});
itemLIst.Add(new Item
{
    Name = "토끼 인형탈",
    Attack = 0,
    Defence = 20,
    Description = "귀여운 토끼의 옷입니다",
    Price = 10000
});
foreach (Item item in itemLIst)
{
    Console.WriteLine($"이름: {item.Name}");
    Console.WriteLine($"공격력: {item.Attack}");
    Console.WriteLine($"방어력: {item.Defence}");
    Console.WriteLine($"설명: {item.Description}");
    Console.WriteLine($"가격: {item.Price}");

}
}
//여기는 뭐 변동값들이나 정보같은거?
class ItemLookUP
        {}
            
