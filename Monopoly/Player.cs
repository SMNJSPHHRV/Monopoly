using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Observer
    public interface IObserver
    {
        void Update(IPlayer player,int value);
    }

    // Observer
    public interface IPlayer
    {
        void Register(IObserver observer);

        void Unregister(IObserver observer);

        void Notify(int value);
    }

   
    // This is the class Player which herits of the interface IPlayer for using the observer pattern.
    class Player : IPlayer
    {
        public string name { get; set; }
        public Case position { get; set; }
        public int capital { get; set; }
        public bool jail { get; set; }
        public bool bankruptcy { get; set; }
        public int state { get; set; }
        private List<IObserver> observers = new List<IObserver>();
        Random aleatoire = new Random();
        public int time { get; set; }
        public int nbRailroad { get; set; }
        public int nbCompany { get; set; }
        public int nbPinkField { get; set; }
        public int nbBlueField { get; set; }
        public int nbPurpleField { get; set; }
        public int nbOrangeField { get; set; }
        public int nbRedField { get; set; }
        public int nbYellowField { get; set; }
        public int nbGreenField { get; set; }
        public int nbBlackField { get; set; }

        // Constructor
        public Player( string name, Case position)
        {
            this.name = name;
            this.position = position;
            this.capital = 1500;
            this.jail = false;
            this.bankruptcy = false;
            this.time = 0;
            this.nbRailroad = 0;
            this.nbCompany = 0;
            this.nbPinkField = 0;
            this.nbBlueField = 0;
            this.nbPurpleField = 0;
            this.nbOrangeField = 0;
            this.nbRedField = 0;
            this.nbYellowField = 0;
            this.nbGreenField = 0;
            this.nbBlackField = 0;
        }

        // Observer
        public void Register(IObserver observer)
        {
            Console.WriteLine("{0}: add the observer Register\n",this.name);
            this.observers.Add(observer);
        }
        
        // Observer
        public void Unregister(IObserver observer)
        {
            Console.WriteLine("{0}: add the observer Unregister\n", this.name);
            this.observers.Remove(observer);
        }

        // Observer
        public void Notify( int value)
        {
            //Console.WriteLine("{0}: Notifying observers...");
            foreach(var observer in observers)
            {
                observer.Update(this,value);
            }
        }
      
        // This function allows the player to show his status.
        public void Show()
        {
            this.state = 1;
            this.Notify(0);
            Console.WriteLine("name: {0}, name of the position: {1}, position: {2}, capital: {3}, jail: {4}, bankruptcy: {5}, time: {6}, nbRailroad: {7}, nbCompany: {8}\n", this.name, this.position.name,this.position.position, this.capital, this.jail, this.bankruptcy, this.time,this.nbRailroad, this.nbCompany);   
        }

        // This function return a number in 1 and 6 which represents the possible values of a dice.
        public int ResultDice()
        {
            int dice = aleatoire.Next(1, 7);
            return dice;
        }

        // This function represents the roll of dices by a player. It uses the observer pattern.
        public int[] RollDices()
        {
            int[] result = new int[2];
            this.state = 2;
            this.Notify(0);
            result[0] = ResultDice();
            result[1] = ResultDice();
            Console.WriteLine("{0} gets {1} and {2}\n", this.name, result[0], result[1]);
            return result;
        }

        // This function represents the purchase of a purchased case by the player. It uses the observer pattern.
        public void Purchase()
        {
            if(this.position.type == "Field")
            {
                if ((this.position as Field).owner == "Bank")
                {
                    if (this.capital > (this.position as Field).price)
                    {
                        this.state = 3;
                        this.Notify(0);
                        this.capital -= (this.position as Field).price;
                        (this.position as Field).owner = this.name;
                        if((this.position as Field).color == "Pink")
                        {
                            this.nbPinkField++;
                        }
                        else if ((this.position as Field).color == "Blue")
                        {
                            this.nbBlueField++;
                        }
                        else if ((this.position as Field).color == "Purple")
                        {
                            this.nbPurpleField++;
                        }
                        else if ((this.position as Field).color == "Orange")
                        {
                            this.nbOrangeField++;
                        }
                        else if ((this.position as Field).color == "Red")
                        {
                            this.nbRedField++;
                        }
                        else if ((this.position as Field).color == "Yellow")
                        {
                            this.nbYellowField++;
                        }
                        else if ((this.position as Field).color == "Green")
                        {
                            this.nbGreenField++;
                        }
                        else if ((this.position as Field).color == "Black")
                        {
                            this.nbBlackField++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("{0} cannot purchase", this.name);
                    }
                }
            }

            else if (this.position.type == "Railroad")
            {
                if ((this.position as SpecialField).owner == "Bank")
                {
                    if (this.capital > (this.position as SpecialField).price)
                    {
                        this.state = 16;
                        this.Notify(0);
                        this.capital -= (this.position as SpecialField).price;
                        (this.position as SpecialField).owner = this.name;
                        this.nbRailroad++;
                    }
                    else
                    {
                        Console.WriteLine("{0} cannot purchase", this.name);
                    }
                }
            }
        
            else if (this.position.type == "Company")
            {
                if ((this.position as SpecialField).owner == "Bank")
                {
                    if (this.capital > (this.position as SpecialField).price)
                    {
                        this.state = 17;
                        this.Notify(0);
                        this.capital -= (this.position as SpecialField).price;
                        (this.position as SpecialField).owner = this.name;
                        this.nbCompany++;
                    }
                    else
                    {
                        Console.WriteLine("{0} cannot purchase", this.name);
                    }
                }
            }
            

        }

        // This function represents the sell of a purchased case to the Bank. It uses the observer pattern.
        public void Sell()
        {
            if((this.position).type == "Field")
            {
                if ((this.position as Field).owner == this.name)
                {
                    this.state = 4;
                    this.Notify(0);
                    this.capital += ((this.position as Field).price / 2);
                    (this.position as Field).owner = "Bank";
                }
                else
                {
                    Console.WriteLine("{0} it's not your property", this.name);
                }
            }
            else if ((this.position).type == "Railroad")
            {
                if ((this.position as Railroad).owner == this.name)
                {
                    this.state = 18;
                    this.Notify(0);
                    this.capital += ((this.position as Railroad).price / 2);
                    (this.position as Railroad).owner = "Bank";
                }
            }
            else if ((this.position).type == "Company")
            {
                if ((this.position as Company).owner == this.name)
                {
                    this.state = 19;
                    this.Notify(0);
                    this.capital += ((this.position as Company).price / 2);
                    (this.position as Company).owner = "Bank";
                }
            }

        }

        // This function show to the player his properties. It uses the observer pattern.
        public  void ShowProperties()
        {
            this.state = 5;
            this.Notify(0);
            Console.WriteLine("List of the properties of the player {0}:\n", this.name);
            GameBoard.ShowPlayerFields(this.name);
        }

        // This function represents the pay of the player to another player for the rent of a case. It uses the observer pattern.
        public void Pay(Player player)
        {
            if (this.position.type == "Field")
            {
                if (this.capital > (this.position as Field).rent)
                {
                    
                    int rent = 0;
                    if((this.position as Field).color == "Pink")                     
                    {
                        if(player.nbPinkField == 2)
                        {
                            rent = (this.position as Field).rent * 2;
                        }
                        else
                        {
                            rent = (this.position as Field).rent;
                        }
                        
                    }
                    else if ((this.position as Field).color == "Blue")
                    {
                        if (player.nbBlueField == 3)
                        {
                            rent = (this.position as Field).rent * 2;
                        }
                        else
                        {
                            rent = (this.position as Field).rent;
                        }
                    }
                    else if ((this.position as Field).color == "Purple")
                    {
                        if (player.nbPurpleField == 3)
                        {
                            rent = (this.position as Field).rent * 2;
                        }
                        else
                        {
                            rent = (this.position as Field).rent;
                        }
                    }
                    else if ((this.position as Field).color == "Orange")
                    {
                        if (player.nbOrangeField == 3)
                        {
                            rent = (this.position as Field).rent * 2;
                        }
                        else
                        {
                            rent = (this.position as Field).rent;
                        }
                    }
                    else if ((this.position as Field).color == "Red")
                    {
                        if (player.nbRedField == 3)
                        {
                            rent = (this.position as Field).rent * 2;
                        }
                        else
                        {
                            rent = (this.position as Field).rent;
                        }
                    }
                    else if ((this.position as Field).color == "Yellow")
                    {
                        if (player.nbYellowField == 3)
                        {
                            rent = (this.position as Field).rent * 2;
                        }
                        else
                        {
                            rent = (this.position as Field).rent;
                        }
                    }
                    else if ((this.position as Field).color == "Green")
                    {
                        if (player.nbGreenField == 3)
                        {
                            rent = (this.position as Field).rent * 2;
                        }
                        else
                        {
                            rent = (this.position as Field).rent;
                        }
                    }
                    else if ((this.position as Field).color == "Black")
                    {
                        if (player.nbBlackField == 3)
                        {
                            rent = (this.position as Field).rent * 2;
                        }
                        else
                        {
                            rent = (this.position as Field).rent;
                        }
                    }
                    this.capital -= rent;
                    player.capital += rent;
                    this.state = 6;
                    this.Notify(rent);
                }
                else
                    this.GoBankrupt();
            }
            else
                Console.WriteLine("Error: the position type is not a Field");
        }

        // Thanks to this function the player goes to jail and in his status jail goes to true. It uses the observer pattern.
        public void GoToJail(GameBoard gameBoard)
        {
            this.state = 7;
            this.Notify(0);
            this.jail = true;
            this.position = gameBoard.GetCase(10);
            this.time = 0;
        }

        // This function represents the move on the board. It uses the observer pattern.
        public void Move(int position, GameBoard gameBoard)
        {
            this.state = 8;           
            this.position = gameBoard.GetCase(position);
            this.Notify(0);
        }

        // This function increase the capital of the player for x reason. It uses the observer pattern.
        public void Gain()
        {
            this.state = 9;
            this.Notify(0);
            this.capital += 200;
        }

        // This function decrease the capital of the player of 200. This function is actived when the player is on the Income Tax Case.
        // It uses the observer pattern.
        public void PayIncomeTax( )
        {
            if (this.capital > 200)
            {
                this.state = 10;
                this.Notify(0);
                this.capital -= 200;
            }
            else
                this.GoBankrupt();
        }

        // This function decrease the capital of the player of 100. This function is actived when the player is on the Luxury Tax Case.
        // It uses the observer pattern.
        public void PayLuxuryTax()
        {
            if (this.capital > 100)
            {
                this.state = 11;
                this.Notify(0);
                this.capital -= 100;
            }
            else
                this.GoBankrupt();
        }

        // This function show to the players that the player is on a nothing case thanks to the observer pattern.
        public void BeOnNothingCase()
        {
            this.state = 12;
            this.Notify(0);
        }

        // This function changes the bankruptcy status of the player to true. When it's happen, thanks to the observer pattern, the player loses.
        public void GoBankrupt()
        {
            this.state = 13;
            this.Notify(0);
            this.bankruptcy = true;
        }

        // This function changes the jail status to false. It uses the observer pattern.
        public void GoOutJail()
        {
            this.state = 14;
            this.Notify(0);
            this.jail = false;
            this.time = 0;
            
        }

        // This function decrease the capital of the player and changes his jail status to false. It uses the observer pattern.
        public void PayForGoOut()
        {
            if(this.capital > 50)
            {
                this.state = 15;
                this.Notify(0);
                this.capital -= 50;
                this.GoOutJail();
            }
        }

        // This function decrease the capital of the player and increase the one of another. It uses the observer pattern
        public void PayRailroad(Player player)
        {
            int rent = 0;
            if (player.nbRailroad == 1)
                rent = 25;
            else if (player.nbRailroad == 2)
                rent = 50;
            else if (player.nbRailroad == 3)
                rent = 100;
            else if (player.nbRailroad == 4)
                rent = 200;
            if(this.capital > rent)
            {
                this.capital -= rent;
                player.capital += rent;
                if (rent == 25)
                    this.state = 20;
                else if (rent == 50)
                    this.state = 21;
                else if (rent == 100)
                    this.state = 22;
                else if (rent == 200)
                    this.state = 23;
                this.Notify(0);
            }
            else
            {
                this.GoBankrupt();
            }
        }

        // This function decrease the capital of the player and increase the one of another. It uses the observer pattern
        public void PayCompany(Player player)
        {
            int dice1 = ResultDice();
            int dice2 = ResultDice();

            int sum = dice1 + dice2;
            if(player.nbCompany == 1)
            {
                if( this.capital > 4 * sum)
                {
                    this.capital -= 4 * sum;
                    player.capital += 4 * sum;
                    this.state = 24;
                    this.Notify(4 * sum);
                }
                else
                {
                    this.GoBankrupt();
                }
            }
            else if( player.nbCompany == 2)
            {
                if (this.capital > 10 * sum)
                {
                    this.capital -= 10 * sum;
                    player.capital += 10 * sum;
                    this.state = 24;
                    this.Notify(10 * sum);
                }
                else
                {
                    this.GoBankrupt();
                }
            }
        }
    }
    
    // This is the concrete observer class which show differents messages in function of the status of the player.
    class ConcreteObserver : IObserver
    {
        public void Update(IPlayer player,int value)
        {

            if ((player as Player).state == 1)
            {
                Console.WriteLine("{0} uses the function Show().\n", (player as Player).name);
            }

            else if ((player as Player).state == 2)
            {
                Console.WriteLine("{0} is rolling the dices.\n", (player as Player).name);
            }

            else if ((player as Player).state == 3)
            {
                Console.WriteLine("{0} loses {1} by purchasing {2}.\n", (player as Player).name, ((player as Player).position as Field).price, (player as Player).position.name);
            }

            else if ((player as Player).state == 4)
            {
                Console.WriteLine("{0} gains {1} by selling {2} to the Bank.\n", (player as Player).name, (((player as Player).position as Field).price / 2), (player as Player).position.name);
            }

            else if ((player as Player).state == 5)
            {
                Console.WriteLine("{0} uses the function ShowProperties().\n", (player as Player).name);
            }

            else if ((player as Player).state == 6)
            {
                Console.WriteLine("{0} pays {1} to {2} for the rent {3}.\n", (player as Player).name, value, ((player as Player).position as Field).owner, (player as Player).position.name);
            }

            else if ((player as Player).state == 7)
            {
                Console.WriteLine("{0} goes to jail.\n", (player as Player).name);
            }

            else if ((player as Player).state == 8)
            {
                Console.WriteLine("{0} moves to {1}.\n", (player as Player).name, (player as Player).position.name);
            }

            else if ((player as Player).state == 9)
            {
                Console.WriteLine("{0} makes a loop and gains 200.\n", (player as Player).name);
            }

            else if ((player as Player).state == 10)
            {
                Console.WriteLine("{0} loses 200 by paying the income tax.\n", (player as Player).name);
            }

            else if ((player as Player).state == 11)
            {
                Console.WriteLine("{0} loses 100 by paying the luxury tax.\n", (player as Player).name);
            }

            else if ((player as Player).state == 12)
            {
                Console.WriteLine("{0} is on a nothing case.\n", (player as Player).name);
            }

            else if ((player as Player).state == 13)
            {
                Console.WriteLine("{0} goes bankrupt, he loses!\n", (player as Player).name);
            }

            else if ((player as Player).state == 14)
            {
                Console.WriteLine("{0} can go out of jail.\n", (player as Player).name);
            }

            else if ((player as Player).state == 15)
            {
                Console.WriteLine("{0} loses 50 by paying for going out of jail.\n", (player as Player).name);
            }

            else if ((player as Player).state == 16)
            {
                Console.WriteLine("{0} loses {1} by purchasing {2}.\n", (player as Player).name, ((player as Player).position as SpecialField).price, (player as Player).position.name);
            }

            else if ((player as Player).state == 17)
            {
                Console.WriteLine("{0} loses {1} by purchasing {2}.\n", (player as Player).name, ((player as Player).position as SpecialField).price, (player as Player).position.name);
            }
            
            else if ((player as Player).state == 18)
            {
                Console.WriteLine("{0} gains {1} by selling {2} to the Bank.\n", (player as Player).name, (((player as Player).position as Railroad).price / 2), (player as Player).position.name);
            }

            else if ((player as Player).state == 19)
            {
                Console.WriteLine("{0} gains {1} by selling {2} to the Bank.\n", (player as Player).name, (((player as Player).position as Company).price / 2), (player as Player).position.name);
            }

            else if ((player as Player).state == 20)
            {
                Console.WriteLine("{0} pays 25 to {1} for paying the rent of the railroad.\n", (player as Player).name, ((player as Player).position as Railroad).owner);
            }

            else if ((player as Player).state == 21)
            {
                Console.WriteLine("{0} pays 50 to {1} for paying the rent of the railroad.\n", (player as Player).name, ((player as Player).position as Railroad).owner);
            }

            else if ((player as Player).state == 22)
            {
                Console.WriteLine("{0} pays 100 to {1} for paying the rent of the railroad.\n", (player as Player).name, ((player as Player).position as Railroad).owner);
            }

            else if ((player as Player).state == 23)
            {
                Console.WriteLine("{0} pays 200 to {1} for paying the rent of the railroad.\n", (player as Player).name, ((player as Player).position as Railroad).owner);
            }

            else if ((player as Player).state == 24)
            {
                Console.WriteLine("{0} pays {1} to {2} for company case.\n", (player as Player).name,value, ((player as Player).position as SpecialField).owner);
            }
        }
    }

}
