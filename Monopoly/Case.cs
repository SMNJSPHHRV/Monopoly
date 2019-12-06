using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // This the main class for the case of the board. In the Monopoly there is several type of cases with differents effects, this is the reason
    // of the creation of several daughter class.
    interface  Case 
    {
        void ShowCase();
        //string GetOwner();
        //void SetOwner(string name);
        //int GetPrice();
        int position { get; set; }
        string name { get; set; }
        string type { get; set; }
        //int GetRent();


    }

    // This class herits to the class Case. It represents the cases which can be purchased and have a color.
    interface Field : Case
    {
        string type { get; set; }
        int price { get; set; }
        int rent { get; set; }
        string owner { get; set; }
        string color { get; set; }

    }

    // This class herits to the class Case. It represents the cases which can be purchased and don't have a color.
    interface SpecialField : Case
    {
        string type { get; set; }
        int price { get; set; }
        string owner { get; set; }
    }

    // This class herits to the class Case. It represents the cases which can't be purchased.
    interface BoardCase : Case
    {
        string type { get; set; }
    }


    // Creator
    interface Creator
    {
        Case FactoryMethod(string name, int value);
    }
    

    // This is the class Special Field.
    class Railroad : SpecialField
    {
        public int position { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public string owner { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, owner: {4}\n", this.name, this.type, this.position, this.price, this.owner);
        }
    }
    class Company : SpecialField
    {
        public int position { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int price { get; set; }
        public string owner { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, owner: {4}\n", this.name, this.type, this.position, this.price, this.owner);
        }
    }

    // This is the class Field
    class PinkField : Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public int price { get; set; }
        public int rent { get; set; }
        public string owner { get; set; }
        public string color { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, rent: {4}, owner: {5}, color: {6}\n", this.name, this.type, this.position, this.price, this.rent, this.owner, this.color);
        }  
    }
    class BlueField : Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public int price { get; set; }
        public int rent { get; set; }
        public string owner { get; set; }
        public string color { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, rent: {4}, owner: {5}, color: {6}", this.name, this.type, this.position, this.price, this.rent, this.owner, this.color);
        }
    }
    class PurpleField : Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public int price { get; set; }
        public int rent { get; set; }
        public string owner { get; set; }
        public string color { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, rent: {4}, owner: {5}, color: {6}", this.name, this.type, this.position, this.price, this.rent, this.owner, this.color);
        }
    }
    class OrangeField : Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public int price { get; set; }
        public int rent { get; set; }
        public string owner { get; set; }
        public string color { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, rent: {4}, owner: {5}, color: {6}", this.name, this.type, this.position, this.price, this.rent, this.owner, this.color);
        }
    }
    class RedField : Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public int price { get; set; }
        public int rent { get; set; }
        public string owner { get; set; }
        public string color { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, rent: {4}, owner: {5}, color: {6}", this.name, this.type, this.position, this.price, this.rent, this.owner, this.color);
        }
    }
    class YellowField : Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public int price { get; set; }
        public int rent { get; set; }
        public string owner { get; set; }
        public string color { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, rent: {4}, owner: {5}, color: {6}", this.name, this.type, this.position, this.price, this.rent, this.owner, this.color);
        }
    }
    class GreenField : Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public int price { get; set; }
        public int rent { get; set; }
        public string owner { get; set; }
        public string color { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, rent: {4}, owner: {5}, color: {6}", this.name, this.type, this.position, this.price, this.rent, this.owner, this.color);
        }
    }
    class BlackField : Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }
        public int price { get; set; }
        public int rent { get; set; }
        public string owner { get; set; }
        public string color { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}, price: {3}, rent: {4}, owner: {5}, color: {6}", this.name, this.type, this.position, this.price, this.rent, this.owner, this.color);
        }
    }


    // This is the class BoardCase
    class BeginCase :BoardCase
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}", this.name, this.type, this.position);
        }
    }
    class NothingCase : BoardCase
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}", this.name, this.type, this.position);
        }      
    }
    class IncomeTaxCase : BoardCase
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}", this.name, this.type, this.position);
        }
    }
    class JailCase : BoardCase
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}", this.name, this.type, this.position);
        }
    }
    class GoToJailCase : BoardCase
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}", this.name, this.type, this.position);
        }
    }
    class LuxuryTaxCase : BoardCase
    {
        public string name { get; set; }
        public string type { get; set; }
        public int position { get; set; }

        // This function allow to show the case.
        public void ShowCase()
        {
            Console.WriteLine("position name: {0}, type: {1}, position: {2}", this.name, this.type, this.position);
        }
    }

    // <== Creator ==>
    class Create_PinkField : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            // the rent is the same for the two pink cell.
            return new PinkField { name = name, type = "Field", position = position, price = 60, rent = 4, owner = "Bank", color = "Pink" };
        }
    }

    class Create_BlueField : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new BlueField { name = name, type = "Field", position = position, price = 100, rent = 6, owner = "Bank", color = "Blue" };
        }
    }

    class Create_BlueFieldUp : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new BlueField { name = name, type = "Field", position = position, price = 120, rent = 8, owner = "Bank", color = "Blue" };
        }
    }

    class Create_PurpleField : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new PinkField { name = name, type = "Field", position = position, price = 140, rent = 10, owner = "Bank", color = "Purple" };
        }
    }

    class Create_PurpleFieldUp : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new PinkField { name = name, type = "Field", position = position, price = 160, rent = 12, owner = "Bank", color = "Purple" };
        }
    }

    class Create_OrangeField : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new OrangeField { name = name, type = "Field", position = position, price = 180, rent = 14, owner = "Bank", color = "Orange" };
        }
    }

    class Create_OrangeFieldUp : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new OrangeField { name = name, type = "Field", position = position, price = 200, rent = 16, owner = "Bank", color = "Orange" };
        }
    }

    class Create_RedField : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new RedField { name = name, type = "Field", position = position, price = 220, rent = 18, owner = "Bank", color = "Red" };
        }
    }

    class Create_RedFieldUp : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new RedField { name = name, type = "Field", position = position, price = 240, rent = 20, owner = "Bank", color = "Red" };
        }
    }

    class Create_YellowField : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new YellowField { name = name, type = "Field", position = position, price = 260, rent = 22, owner = "Bank", color = "Yellow" };
        }
    }

    class Create_YellowFieldUp : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new YellowField { name = name, type = "Field", position = position, price = 280, rent = 24, owner = "Bank", color = "Yellow" };
        }
    }

    class Create_GreenField : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new GreenField { name = name, type = "Field", position = position, price = 300, rent = 26, owner = "Bank", color = "Green" };
        }
    }

    class Create_GreenFieldUp : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new GreenField { name = name, type = "Field", position = position, price = 320, rent = 28, owner = "Bank", color = "Green" };
        }
    }

    class Create_BlackField : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new BlackField { name = name, type = "Field", position = position, price = 350, rent = 35, owner = "Bank", color = "Black" };
        }
    }

    class Create_BlackFieldUp: Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new BlackField { name = name, type = "Field", position = position, price = 400, rent = 50, owner = "Bank", color = "Black" };
        }
    }

    class Create_Railroad : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new Railroad { name = name, type = "Railroad", position = position, price = 200, owner = "Bank" };
        }
    }

    class Create_Company : Creator
    {
        public Case FactoryMethod(string name, int position)
        {
            return new Railroad { name = name, type = "Company", position = position, price = 150, owner = "Bank" };
        }
    }

    class Create_BeginCase : Creator
    {
        public Case FactoryMethod(string name,int position)
        {
            return new BeginCase { name = name, type = "Case", position = position };
        }
    }

    class Create_NothingCase : Creator
    {
        public Case FactoryMethod( string name, int position)
        {
            return new NothingCase { name = name, type = "Case", position = position };
        }
    }

    class Create_IncomeTaxCase : Creator
    {
        public Case FactoryMethod ( string name, int position)
        {
            return new IncomeTaxCase { name = name, type = "Case", position = position };
        }
    }

    class Create_JailCase : Creator
    {
        public Case FactoryMethod (string name, int position)
        {
            return new JailCase { name = name, type = "Case", position = position };
        }
    }

    class Create_GoToJailCase : Creator
    {
        public Case FactoryMethod ( string name, int position)
        {
            return new GoToJailCase { name = name, type = "Case", position = position };
        }
    }

    class Create_LuxuryTaxCase : Creator
    {
        public Case FactoryMethod ( string name, int position)
        {
            return new LuxuryTaxCase { name = name, type = "Case", position = position };
        }
    }
}
