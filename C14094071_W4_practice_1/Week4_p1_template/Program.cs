using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_p1_template
{
    class Program
    {
        static int player1_money=0;
        static int player2_money=0;

        static Random rnd = new Random();
        static int target = 0;
        static int[] cards = new int[53];
        static String player1_money_str;
        static String player1_bet_str;
        
        static int player1_bet;
        static String player2_money_str;
        static String player2_bet_str;
        
        static int player2_bet;
        static int card_num = 0;
        static int card_points_1=0;
        static int player1_points=0;
        static int player2_points=0;
        static String[] player1_cards = new string[2];
        static String[] player2_cards = new string[2];
        static int player_card = 0;
        static String player_card_str = "";
        static int k1=2,k2=2,stage=1;
        static String press_str;
      
        static void Main(string[] args)
        {
            
            
            try
            {
                // 程式流程
                // 1. 輸入玩家1、玩家2初始金錢(需要格式檢查)
                //
                Console.Write("玩家1初始金錢: ");
                player1_money_str = Console.ReadLine();
                
                try
                {
                    player1_money = int.Parse(player1_money_str);
                }catch
                {
                    Console.WriteLine("請輸入正確格式");
                    Console.ReadKey();
                    return;
                }
                
                
                Console.Write("玩家2初始金錢: ");
                player2_money_str = Console.ReadLine();
               
                try
                {
                    player2_money = int.Parse(player2_money_str);
                }catch
                {
                    Console.WriteLine("請輸入正確格式");
                    Console.ReadKey();
                    return;
                }
                
           
                while(player1_money>0 && player2_money >0){
                    Game();
                    
                    if(stage==3){
                        
                        break;

                    }
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    if(player1_money<0 || player2_money <0){
                        Console.ReadKey();
                        break;
                    }
                    Reset();
                }
                


                









                
            }
            catch (FormatException)
            {

            }
            Console.ReadKey();
        }
        static void Reset(){
            target = 0;
            cards = new int[53];
            player1_money_str="";
            player1_bet_str="";
        
            player1_bet=0;
            player2_money_str="";
            player2_bet_str="";
        
            player2_bet=0;
            card_num = 0;
            card_points_1=0;
            player1_points=0;
            player2_points=0;
            player1_cards = new string[2];
            player2_cards = new string[2];
            player_card = 0;
            player_card_str = "";
            k1=2;
            k2=2;
            stage=1;
            press_str="";
        }
        static void Game(){
            ////////洗牌///////////
                for(int i=0; i <= 52; i++)
                {
                    cards[i] = i;
                }

                ////////玩家1手牌/////////
                Console.WriteLine("玩家手牌1：");
                
                for (int i=0;i<2;i++){
                    Start_Draw2(ref player1_points,ref player1_cards,i);
                }
                
                
                Console.WriteLine("{0} {1}",player1_cards[0],player1_cards[1]);
                Console.WriteLine("玩家1目前點數:{0}",player1_points);
                Console.WriteLine("玩家1目前金錢:{0}",player1_money);
                ////玩家1下注金額/////
                Console.Write("請輸入下注金額：");
                player1_bet_str = Console.ReadLine();
                
                try
                {
                    player1_bet = int.Parse(player1_bet_str);
                }catch
                {
                    stage = 3;
                    Console.WriteLine("請輸入正確格式");
                    Console.ReadKey();
           
                        
                    return;
                }
                while((player1_bet==0)||(player1_bet>player1_money)){

                    if(player1_bet==0){
                        Console.WriteLine("金錢不能為零，請重新輸入!");
                    }else if(player1_bet>player1_money){
                        Console.WriteLine("金錢不足，請重新輸入!");
                    }
                    
                    Console.Write("請輸入下注金額：");
                    player1_bet_str = Console.ReadLine();
                    try
                    {
                        player1_bet = int.Parse(player1_bet_str);
                    }catch
                    {
                        stage = 3;
                        Console.WriteLine("請輸入正確格式");
                        Console.ReadKey();
           
                        
                        return;
                
                    }
                }
                Console.WriteLine();
                //////////////////





                
                

                ////////玩家2手牌/////////
                Console.WriteLine("玩家手牌2：");
                for (int i=0;i<2;i++){
                    Start_Draw2(ref player2_points,ref player2_cards,i);
                }
                
                
                Console.WriteLine("{0} {1}",player2_cards[0],player2_cards[1]);
                Console.WriteLine("玩家2目前點數:{0}",player2_points);
                Console.WriteLine("玩家2目前金錢:{0}",player2_money);
                //////////////
                
                ////玩家2下注金額/////
                Console.Write("請輸入下注金額：");
                player2_bet_str = Console.ReadLine();
                
                try
                {
                    player2_bet = int.Parse(player2_bet_str);
                }catch
                {
                    stage =3;
                    Console.WriteLine("請輸入正確格式");
                    Console.ReadKey();
                    
                    
                    return;
                }
                while((player2_bet==0)||(player2_bet>player2_money)){

                    if(player2_bet==0){
                        Console.WriteLine("金錢不能為零，請重新輸入!");
                    }else if(player2_bet>player2_money){
                        Console.WriteLine("金錢不足，請重新輸入!");
                    }
                    
                    Console.Write("請輸入下注金額：");
                    player2_bet_str = Console.ReadLine();
                    try
                    {
                        player2_bet = int.Parse(player2_bet_str);
                    }catch
                    {
                        stage = 3;
                        Console.WriteLine("請輸入正確格式");
                        Console.ReadKey();
           
                        
                        return;
                    }
                }
                Console.WriteLine();
                //////////////////
                
                while(player1_points<=21 && player2_points<=21){
                    
                    Console.WriteLine("玩家1行動(輸入1抽1張排、輸入P停止抽牌):");
                    
                    
                    
                    
                    press_str = Console.ReadLine();
                    
                    if(press_str == "1" && stage==1){
                        Console.WriteLine("玩家手牌1：");
                
                        Array.Resize(ref player1_cards,player1_cards.Length+1);
                        Start_Draw2(ref player1_points,ref player1_cards,k1);
                        
                
                        for(int h=0;h<player1_cards.Length;h++){
                            Console.Write("{0},",player1_cards[h]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("玩家1目前的點數:{0}",player1_points);
                        k1++;
                        if(player1_points>21){
                            Console.WriteLine("玩家1爆了，玩家2獲勝！");
                            player1_money = player1_money-player1_bet;
                            player2_money = player2_money+player1_bet;
                            Console.WriteLine("玩家2獲勝，獲得{0}金錢",player1_bet);
                            
                            return;
                        }
                    }else if(press_str == "P" && stage ==1){
                        Console.WriteLine("玩家1跳過，目前點數:{0}",player1_points);
                        stage = 2;
                        break;
                    }

                    
                
                }
                while(player2_points<=21 && stage==2){
                    Console.WriteLine("玩家2行動(輸入1抽1張排、輸入P停止抽牌):");
                    press_str = Console.ReadLine();
                    if(press_str == "1" && stage==2){
                        
                        Console.WriteLine("玩家手牌2：");
                
                        Array.Resize(ref player2_cards,player2_cards.Length+1);
                        Start_Draw2(ref player2_points,ref player2_cards,k2);
                        
                
                        for(int h=0;h<player2_cards.Length;h++){
                            Console.Write("{0},",player2_cards[h]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("玩家2目前的點數:{0}",player2_points);
                        k2++;
                        if(player2_points>21){
                            Console.WriteLine("玩家2爆了，玩家1獲勝！");
                            player2_money = player2_money-player2_bet;
                            player1_money = player1_money+player2_bet;
                            Console.WriteLine("玩家1獲勝，獲得{0}金錢",player2_bet);
                            
                            return;
                        }
                    }else if(press_str == "P" && stage ==2){
                        Console.WriteLine("玩家2跳過，目前點數:{0}",player2_points);
                        break;
                    }
                }
                if(player1_points<player2_points){
                    player1_money = player1_money-player1_bet;
                    player2_money = player2_money+player1_bet;
                    Console.WriteLine("玩家2獲勝，獲得{0}金錢",player1_bet);
                }
                else if(player1_points>player2_points){
                    player2_money = player2_money-player2_bet;
                    player1_money = player1_money+player2_bet;
                    Console.WriteLine("玩家1獲勝，獲得{0}金錢",player2_bet);
                }else{
                    Console.WriteLine("平手！拿回各自的錢");
                    
                }
                
                return;

        }
        static void Start_Draw2(ref int player_points,ref String[] player_cards,int i){
            target = 0;
                
            while(cards[target] == 0)
            {
                target = rnd.Next(1, 52);
                player_card = cards[target];
                    
            }
                
            card_num = Tell_Card(player_card, ref player_card_str);

            player_cards[i] = player_card_str;

            card_points_1 = Count_points(card_num,player_points);

            player_points = player_points + card_points_1;

            
            cards[target]=0;

        }
        static int Tell_Card(int x,ref String card_name)
        {
            
            if(x >=1 && x <= 13)
            {
                x = x % 13;
                if (x == 0)
                {
                    x = 13;
                }
                card_name = "Spades"+" "+ x.ToString();
            }
            else if(x >= 14 && x <= 26)
            {
                x = x % 13;
                if (x == 0)
                {
                    x = 13;
                }
                card_name = "Heart" + " " + x.ToString();
            }
            else if (x >= 27 && x <= 39)
            {
                x = x % 13;
                if (x == 0)
                {
                    x = 13;
                }
                card_name = "Diamond" + " " + x.ToString();
            }
            else if (x >= 40 && x <= 52)
            {
                x = x % 13;
                if (x == 0)
                {
                    x = 13;
                }
                card_name = "Club" + " " + x.ToString();
            }

            return x;
        }
        static int Count_points(int x,int player_points){
            int card_points=0;
            if(x==1){
                if(player_points>=11){
                    card_points=1;
                }
                else if(player_points<=10){
                    card_points =11;
                }
                
            }
            else if(x==2){
                card_points=2;
            }
            else if(x==3){
                card_points=3;
            }
            else if(x==4){
                card_points=4;
            }
            else if(x==5){
                card_points=5;
            }
            else if(x==6){
                card_points=6;
            }
            else if(x==7){
                card_points=7;
            }
            else if(x==8){
                card_points=8;
            }
            else if(x==9){
                card_points=9;
            }
            else if(x==10){
                card_points=10;
            }
            else if(x==11){
                card_points=10;
            }
            else if(x==12){
                card_points=10;
            }
            else if(x==13){
                card_points=10;
            }
            return card_points;

        }
                                        
    }
}
// 2. 顯示玩家1初始手牌、點數、金錢並下注，需檢查下注金額不能為0、金錢不足與格式檢查
                //    手牌花色：Spade, Heart, Diamond, Club
                //    手牌點數：1~13
                //    手牌顯示格式: "花色 點數"
                //
                //    Console.WriteLine("玩家1手牌: " + [手牌1] + ", " + [手牌2]);
                //    Console.WriteLine("玩家1目前點數: " + [玩家1總點數]);
                //    Console.WriteLine("玩家1目前金錢: " + [玩家1金錢]);
                //    Console.Write("請輸入下注金額: ");
                //    金錢不足：Console.WriteLine("金錢不足，請重新輸入!");、並重新輸入
                //    下注金額0：Console.WriteLine("金錢不能為零，請重新輸入!");、並重新輸入
                //
                // 3. 顯示玩家2初始手牌、點數、金錢並下注，需檢查下注金額不能為0、金錢不足與格式檢查
                //
                //    Console.WriteLine("玩家2手牌: " + [手牌1] + ", " + [手牌2]);
                //    Console.WriteLine("玩家2目前點數: " + [玩家2總點數]);
                //    Console.WriteLine("玩家2目前金錢: " + [玩家2金錢]);
                //
                // 4. 兩位玩家依序行動(不斷抽牌或停止抽牌)
                //    注意1：抽牌完要顯示玩家手牌與點數
                //    注意2：選擇停止抽牌，需印出當前點數
                //
                //    while (true) 
                //        Console.WriteLine("玩家1/2行動(輸入1抽1張排、輸入P停止抽牌):");
                //        if 輸入 1:
                //            Console.WriteLine("玩家1/2手牌: " + [手牌1] + ", " + [手牌2] + ", " + ....);
                //            Console.WriteLine("玩家1/2目前點數: " + [玩家1/2總點數]);
                //            if 超過21點:
                //                break
                //            else
                //                continue
                //        else if 輸入 P:
                //            停止抽牌：Console.WriteLine("玩家1/2跳過，目前點數: " + [玩家總點數]);
                //            break
                //
                // 5. 結果判定
                //    case1 : 玩家1在抽牌時超過21點，直接判定玩家2獲勝(跳過玩家2行動)
                //            Console.WriteLine("玩家1爆了，玩家2獲勝!");
                //    case2 : 玩家2在抽牌時超過21點，直接判定玩家1獲勝
                //            Console.WriteLine("玩家2爆了，玩家1獲勝!");
                //    case3 : 若雙方都沒超過21點，比較點數大小並判斷勝敗平手
                //
                //    玩家1/2獲勝：Console.WriteLine("玩家1/2獲勝，獲得" + [玩家2/1下注金錢] + "金錢");
                //    平手：Console.WriteLine("平手!拿回各自的錢");
                //
                // 6. 如果雙方都還有錢就回到步驟2，否則結束程式
                //
                // 格式檢查錯誤：Console.WriteLine("請輸入正確格式");、並直接結束程式