using System.Windows.Markup;

namespace ConsoleRPG.Items
{
    enum IthemType
    {
        // Weapon
        Sword,
        Hummer,
        Axe,
        Spear,

        //Armor
        Helmet,
        Chest,
        Leggins,
        Boots
    }   

    enum IthemRank
    {
        Heavy,
        Light
    }

    class Item
    {
        private string name = "";
        // Initialization of variables 
        public string Name { 
            get { return name; } 
            set { if (value.Length > 0) name = value; else name = "Name"; } 
        }
        public int Level { get; }

        // Constructor of Ithems
        public Item(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }
}
