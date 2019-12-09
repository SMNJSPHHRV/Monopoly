using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // This is the class where the game works.
    class Program
    {
        // This function helps us to answer to a question. It takes 2 arguments, word1 and word2 which are the possible response.
        // The user choses one of the two, and it's return.
        static string Input(string word1, string word2)
        {
            bool cond = false;
            int loop = 0;
            string answer;
            while (cond == false)
            {
                if (loop > 0)
                    Console.WriteLine("Please enter {0} or {1} !",word1,word2);
                answer = Console.ReadLine();
                if (answer == word1 || answer == word2)
                {
                    cond = true;
                    return answer;
                }
                loop++;       
            }
            return null;
        }

        static int InputInt(int min, int max)
        {           
            int input = 0;
            int cond = 1;
            while(cond > 0)
            {
                Console.WriteLine("Input your choice");
                input = int.Parse(Console.ReadLine());
                if (input >= min)
                {
                    if (input <= max)
                    {
                        cond = 0;
                    }
                }
                   
            }
            return input;
            
        }
        
        // The role of this function is make loop on the board. Each time a player makes a loop , he gains 200.
        static int LoopBoard(Player player, int sum)
        {
            int result = player.position.position;           
            result += sum;            
            if (result > 39)
            {
                player.Gain();
                return result - 40;
            }
                
            else
                return result;
        }

        // The role of this function is to get the winner, who is the last player who has bankruptcy egal to false.
        static Player Winner(List<Player> list)
        {
          
            foreach(Player player in list)
            {
                if(player.bankruptcy == false)
                {
                    return player;
                }
            }

            return null;
        }

       // This function return a player of the list by his name.
        static Player GetPlayer(List<Player> list,string name)
        {
            foreach(Player player in list)
            {
                if (player.name == name)
                    return player;
                
                    
            }
            return null;
        }

        // This function represents the turn of a player.
        static void Turn(Player player, GameBoard gameBoard, List<Player> list)
        {
            if(player.bankruptcy == false)
            {
                Console.WriteLine("Turn of {0}!\n", player.name);
                PlayerMove(player, gameBoard);
                CaseEffect(player, gameBoard, list);
                int cond = 1;
                while(cond > 0)
                {
                    Console.WriteLine("What do you want to do {0}:\n", player.name);
                    Console.WriteLine("1 - Sell \n2 - Show your status \n3 - Show your properties \n4 - Show the board\n5 - End turn\n6 - Abandon the game\n");
                    int input = InputInt(1, 6);
                    switch(input)
                    {
                        case 1:
                            player.Sell();
                            break;
                        case 2:
                            player.Show();
                            break;
                        case 3:
                            player.ShowProperties();
                            break;
                        case 4:
                            gameBoard.ShowBoard();
                            break;
                        case 5:
                            cond = 0;
                            break;
                        case 6:
                            cond = 0;
                            player.Abandon();
                            break;
                    }           
                }
                Console.WriteLine("End of turn of {0}\n\n\n", player.name);
            }

        }

        // This function represents the stages for moving of a player.
        static void PlayerMove(Player player, GameBoard gameBoard)
        {
            if (player.jail == false)
            {
                int rolls = 0;
                int sum = 0;
                int cond = 1;
                int[] dices;
                while (cond > 0)
                {
                    dices = player.RollDices();
                    if (dices[0] != dices[1])
                    {
                        sum += dices[0] + dices[1];
                        cond = 0;
                    }
                    else
                    {
                        rolls++;
                        sum += dices[0] + dices[1];
                    }

                    if (rolls == 3)
                    {
                        cond = 0;
                        player.GoToJail(gameBoard);

                    }
                }
                int move = LoopBoard(player, sum);
                if (rolls == 3)
                {
                    player.Move(move, gameBoard);
                }
                else
                {
                    player.Move(move, gameBoard);
                }
            }
            else
                Console.WriteLine("{0} cannot move because he is in jail!\n", player.name);
        }

        // The goal of this function, is to allow to a player the right to try to go out of jail by rolling the dices.
        static void RollForFree(Player player)
        {
            int[] results = player.RollDices();
            player.time++;
            if(results[0] == results[1])
            {
                player.GoOutJail();
            }
            else
            {
                Console.WriteLine("{0} doesn't have a double\n",player.name);
            }
        }

        // Each time a player is on a new case, he is affected by the effect of the cases thanks to this function.
        static void CaseEffect(Player player, GameBoard gameBoard, List<Player> list)
        {
            if( player.position.type == "Field")
            {
                if((player.position as Field).owner == "Bank")
                {
                    Console.WriteLine("{0} do you want to buy {1} ? (yes/no)\n", player.name, player.position.name);
                    string answer = Input("yes", "no");
                    if(answer == "yes")
                    {
                        Console.WriteLine();
                        player.Purchase();
                    }
                    else
                    {
                        Console.WriteLine("{0} doesn't buy {1}\n", player.name, player.position.name);
                    }
                }
                else
                {
                    if ((player.position as Field).owner != player.name)
                    {
                        player.Pay(GetPlayer(list, (player.position as Field).owner));
                    }
                }

            }
            else if (player.position.type == "Railroad")
            {
                if ((player.position as SpecialField).owner == "Bank")
                {
                    Console.WriteLine("{0} do you want to buy {1} ? (yes/no)\n", player.name, player.position.name);
                    string answer = Input("yes", "no");
                    if (answer == "yes")
                    {
                        Console.WriteLine();
                        player.Purchase();
                    }
                    else
                    {
                        Console.WriteLine("{0} doesn't buy {1}\n", player.name, player.position.name);
                    }
                }
                else
                {
                    if ((player.position as SpecialField).owner != player.name)
                    {
                        player.PayRailroad(GetPlayer(list, (player.position as SpecialField).owner));
                    }
                }
            }
            else if (player.position.type == "Company")
            {
                if ((player.position as SpecialField).owner == "Bank")
                {
                    Console.WriteLine("{0} do you want to buy {1} ? (yes/no)\n", player.name, player.position.name);
                    string answer = Input("yes", "no");
                    if (answer == "yes")
                    {
                        Console.WriteLine();
                        player.Purchase();
                    }
                    else
                    {
                        Console.WriteLine("{0} doesn't buy {1}\n", player.name, player.position.name);
                    }
                }
                else
                {
                    if((player.position as SpecialField).owner != player.name)
                    {
                        player.PayCompany(GetPlayer(list, (player.position as SpecialField).owner));
                    }
                }
            }
            else if (player.position.name == "Income Tax Case")
            {
                player.PayIncomeTax();
            }
            else if (player.position.name == "Luxury Tax Case")
            {
                player.PayLuxuryTax();
            }
            else if (player.position.name == "Nothing Case")
            {
                player.BeOnNothingCase();
            }
            else if (player.position.name == "Go To Jail Case")
            {
                player.GoToJail(gameBoard);
            }
            else if (player.position.name == "Jail Case")
            {
                if (player.time > 2)
                {
                    player.GoOutJail();
                    PlayerMove(player, gameBoard);
                    CaseEffect(player, gameBoard, list);
                }
                if(player.jail == true)
                {
                    Console.WriteLine("{0} do you want to pay (one) or to roll the dices (two)? \n", player.name);
                    string answer = Input("one", "two");
                    if (answer == "one")
                    {
                        player.PayForGoOut();
                    }
                    else
                    {
                        RollForFree(player);
                    }

                    if(player.jail == false)
                    {
                        PlayerMove(player, gameBoard);
                        CaseEffect(player, gameBoard, list);
                    }
                }
            }         
        }

        // The role of this function is to determine if there at least two players who can play.
        static int EndGame(List<Player> list)
        {
            int result = 0;
            int count = 0;
            foreach(Player player in list)
            {
                if(player.bankruptcy == false)
                {
                    count++;
                }
            }
            if (count >= 2)
                result = 1;
            return result;
        }

        // This function represents the stage of a game, it uses a singleton for the game board.
        // There is only 2 or 3 players in a game.
        static void Game()
        {
            Console.WriteLine("Start a game!\n");

            // Begin singleton.
            GameBoard gameBoard = GameBoard.GetInstance();
            GameBoard gameBoard2 = GameBoard.GetInstance();

            if (gameBoard == gameBoard2)
                Console.WriteLine("Same instance\n");
            // End singleton.
            
            Console.WriteLine("Creation of the board\n");
            gameBoard.CreateGameBoard();

            var observer = new ConcreteObserver();
            List<Player> list = new List<Player>();
            Console.WriteLine("Input the number of players two or three.\n");
            string nbPlayer = Input("two", "three");
            if(nbPlayer == "two")
            {
                Console.WriteLine("Input name of the first player.\n");
                string name1 = Console.ReadLine();
                Player player1 = new Player(name1, gameBoard.GetCase(0));
                player1.Register(observer);
                Console.WriteLine("Input name of the second player.\n");
                string name2 = Console.ReadLine();
                Player player2 = new Player(name2, gameBoard.GetCase(0));
                player2.Register(observer);
                list.Add(player1);
                list.Add(player2);
            }
            else if (nbPlayer == "three")
            {
                Console.WriteLine("Input name of the first player.\n");
                string name1 = Console.ReadLine();
                Player player1 = new Player(name1, gameBoard.GetCase(0));
                player1.Register(observer);
                Console.WriteLine("Input name of the second player.\n");
                string name2 = Console.ReadLine();
                Player player2 = new Player(name2, gameBoard.GetCase(0));
                player2.Register(observer);
                Console.WriteLine("Input name of the third player.\n");
                string name3 = Console.ReadLine();
                Player player3 = new Player(name3, gameBoard.GetCase(0));
                player3.Register(observer);
                list.Add(player1);
                list.Add(player2);
                list.Add(player3);
            }
            int cond = 1;
            while(cond > 0)
            {
                foreach(Player player in list)
                {
                    Turn(player, gameBoard, list);
                }
                cond = EndGame(list);
                
            }
            Player winner = Winner(list);
            Console.WriteLine("{0} is the winner, Congratulation !!\n", winner.name);
            Console.WriteLine("End of the game!\n");
        }
        

        static void Main(string[] args)
        {
            // Launch of the game.
            Game(); 
            // Wait.
            Console.ReadKey();

        }
    }
}
