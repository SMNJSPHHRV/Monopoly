using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Monopoly
{
    // This class represents the game board with all the cases of the Monopoly.
    class GameBoard
    {
        private static GameBoard instance;
        private Creator[] gameBoard = new Creator[40];
        public static Case[] board { get; set; }
        private static object syncLock = new object(); 
        private GameBoard() { }
        private string[] CellName = { "Begin Case", "Mediterranean Avenue", "Nothing Case",
        "Baltic Avenue", "Income Tax Case", "Reading Railroad", "Oriental Avenue", "Nothing Case",
        "Vermont Avenue", "Connecticut Avenue", "Jail Case", "St. Charles Place", "Electric Company",
        "States Avenue", "Virginia Avenue", "Pennsylvania Railroad", "St. James Place", "Nothing Case",
        "Tennessee Avenue", "New York Avenue", "Nothing Case", "Kentucky Avenue","Nothing Case",
        "Indiana Avenue", "Illinois Avenue", "B & 0 Railroad", "Atlantic Avenue", "Ventnor Avenue",
        "Water Works", "Marvin Gardens", "Go To Jail Case", "Pacific Avenue", "North Carolina Avenue",
        "Nothing Case", "Pennsylvania Avenue", "Short Line", "Nothing Case", "Park Place",
        "Luxury Tax Case", "Boardwalk"};        
        
        // constructor
        public static GameBoard GetInstance()
        {
            if(instance == null)
            {
                lock(syncLock)
                {
                    if(instance == null)
                    {
                        instance = new GameBoard();
                    }
                }
            }
            return instance;
        }

        // This function which uses a factory pattern creates the game board
        public void CreateGameBoard()
        {
            int iterator = 0;
            board = new Case[40];
            #region Creation 
            gameBoard[0] = new Create_BeginCase();
            gameBoard[1] = new Create_PinkField();
            gameBoard[2] = new Create_NothingCase();
            gameBoard[3] = new Create_PinkField();
            gameBoard[4] = new Create_IncomeTaxCase();
            gameBoard[5] = new Create_Railroad();
            gameBoard[6] = new Create_BlueField();
            gameBoard[7] = new Create_NothingCase();
            gameBoard[8] = new Create_BlueField();
            gameBoard[9] = new Create_BlueFieldUp();
            gameBoard[10] = new Create_JailCase();
            gameBoard[11] = new Create_PurpleField();
            gameBoard[12] = new Create_Company();
            gameBoard[13] = new Create_PurpleField();
            gameBoard[14] = new Create_PurpleFieldUp();
            gameBoard[15] = new Create_Railroad();
            gameBoard[16] = new Create_OrangeField();
            gameBoard[17] = new Create_NothingCase();
            gameBoard[18] = new Create_OrangeField();
            gameBoard[19] = new Create_OrangeFieldUp();
            gameBoard[20] = new Create_NothingCase();
            gameBoard[21] = new Create_RedField();
            gameBoard[22] = new Create_NothingCase();
            gameBoard[23] = new Create_RedField();
            gameBoard[24] = new Create_RedFieldUp();
            gameBoard[25] = new Create_Railroad();
            gameBoard[26] = new Create_YellowField();
            gameBoard[27] = new Create_YellowField();
            gameBoard[28] = new Create_Company();
            gameBoard[29] = new Create_YellowFieldUp();
            gameBoard[30] = new Create_GoToJailCase();
            gameBoard[31] = new Create_GreenField();
            gameBoard[32] = new Create_GreenField();
            gameBoard[33] = new Create_NothingCase();
            gameBoard[34] = new Create_GreenFieldUp();
            gameBoard[35] = new Create_Railroad();
            gameBoard[36] = new Create_NothingCase();
            gameBoard[37] = new Create_BlackField();
            gameBoard[38] = new Create_LuxuryTaxCase();
            gameBoard[39] = new Create_BlackFieldUp();
            #endregion
            
            foreach(Creator creator in gameBoard)
            {
                Case boardcase = creator.FactoryMethod(CellName[iterator] , iterator);
                board[iterator] = boardcase;              
                iterator++;
            }

        }

        // This function allows a player to show the game board.
        public void ShowBoard()
        {
            foreach( Case cell in board)
            {
                cell.ShowCase();
                Console.WriteLine();
            }
        }

        // This function shows the Field, Company and Railroad case to a player thanks to his name. This function is called by the function
        // ShowProperties of the class Player.
        public static void ShowPlayerFields(string name)
        {          
            foreach(Case cell in board)
            {
                if(cell.type == "Field")
                {
                    if ((cell as Field).owner == name)
                    {
                        cell.ShowCase();
                        Console.WriteLine();
                    }
                }
                else if(cell.type == "Railroad")
                {
                    if ((cell as SpecialField).owner == name)
                    {
                        cell.ShowCase();
                        Console.WriteLine();
                    }
                }
                else if(cell.type == "Company")
                {
                    if ((cell as SpecialField).owner == name)
                    {
                        cell.ShowCase();
                        Console.WriteLine();
                    }
                }
                            
            }
        }

        // this function return a Case in function of the number of position.
        public Case GetCase(int position)
        {
            foreach( Case cell in board)
            {
                if (cell.position == position)
                    return cell;
                
            }
            return null;
        }
        

    }
}
