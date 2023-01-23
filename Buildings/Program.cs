namespace Buildings
{
    // Parent Building class
    public class Building
    {
        // Initialisation with defaults for attributes
        protected int numberFloors = 1;
        protected float width = 0.0f;
        protected float length = 0.0f;

        // Constructor taking 3 parameters for floors, width, height
        public Building(int pNF, float pW, float pL)
        {
            this.numberFloors = pNF;
            this.width = pW;
            this.length = pL;
        }

        // Public getter/setters
        public int NumberFloors
        {
            get { return numberFloors; }
            set { numberFloors = value; }
        }

        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        public float Length
        {
            get { return length; }
            set { length = value; }
        }

        // class method to calculate total floor area
        public float FootPrint()
        {
            return this.width * this.length * this.numberFloors;
        }

        // Comparitor method to give equality if total footprint of both objects equal
        public override bool Equals(object? obj)
        {
            Building item = (Building) obj;
            return (item.FootPrint() == this.FootPrint());
        }

        // Use of virtual means derived classes can override the behaviour
        public virtual void Display()
        {
            Console.WriteLine("Property: The building has a width of "+this.Width+"m, a length of "+this.length+"m and is a "+this.calcSize()+" size");
        }

        public virtual string calcSize()
        {
            float tms = this.width * this.length * this.numberFloors;
            if (tms < 80)
            {
                return "Small";
            }
            else if (tms <= 150)
            {
                return "Medium";
            }
            else
            {
                return "Large";
            }
        }
    }

    public class House : Building
    {
        // Could add number of bathrooms too
        private int numBedrooms;
        private int numBaths;

        // Could calc as small/medium/large dependent
        // on number bedrooms 1-2, 3-5, 6+

        public int NumBedrooms
        {
            get { return numBedrooms; }
            set { numBedrooms = value; }
        }

        // Calling base\super
        public House(int pNF, float pW, float pL, int pNB, int pNBath) : base(pNF,pW,pL)
        {
            this.numBedrooms = pNB;
            this.numBaths = pNBath;
        }

        // Polymorphism in action overriding the parent class method
        // to also print the number of bedrooms
        public override string calcSize()
        {
            if (this.numBedrooms == 1 || this.numBedrooms == 2)
            {
                return "Small";
            }
            else if (this.numBedrooms >=3 && this.numBedrooms <= 5)
            {
                return "Medium";
            }
            else
            {
                return "Large";
            }
        }

        public override void Display()
        {
            Console.WriteLine("House: The building has a width of " + this.Width + "m, a length of " + this.length + "m and is a " + this.calcSize() + " size");
        }
    }

    // Composition (aggregation) of street made up of buildings
    public class Portfolio
    {
        // private variable built keeps count of number of instances added
        private int built = 0;
        // set as ar array of 10 object spaces reserves (could use list...)
        private Building[] buildings = new Building[10];

        // Add new building to the street
        public void addBuilding(Building b)
        {
            this.buildings[built] = b;
            built += 1;
        }

        public Portfolio()
        {
        }

        public void PrintPortfolio()
        {
            for (int i=0; i< built; i++)
            {
                this.buildings[i].Display();
            }
        }
    }

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Property system - based on OCR H446_02 Oct 2021 Q5");
            Building[] street = new Building[10];
            int PropertyNum = 0;

            Building Building1 = new Building(2, 8.4f, 7.8f);
            Building1.Display();

            // Testing aggregating class
            Portfolio s = new Portfolio();
            s.addBuilding(new House(2, 7, 8, 2, 1));
            s.addBuilding(new House(2, 7, 8, 3, 2));
            s.addBuilding(new House(1, 7, 8, 2, 1));
            s.addBuilding(new House(3, 11, 10, 6, 3));
            s.addBuilding(new House(2, 7, 6, 1, 1));
            s.addBuilding(new Building(4, 5, 10));
            s.addBuilding(new Building(3, 6.2f, 7));
            s.addBuilding(new Building(2, 20, 8));
            s.addBuilding(new Building(2, 10, 8));
            s.addBuilding(new Building(1, 5, 5));
            s.PrintPortfolio();

            Console.WriteLine("\n\nTesting file read-write\n\n");

            try
            {
                // Extension reading data from file to populate objects
                string myFile = "DataFiles\\property.txt";
                string nextLine;
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                myFile = Path.Combine(docPath, myFile);
                string[] lines = File.ReadAllLines(myFile);

                foreach (string line in lines)
                {
                    string[] vals = line.Split(',');
                    int floors = Convert.ToInt32(vals[0]);
                    float w = Convert.ToSingle(vals[1]);
                    float l = Convert.ToSingle(vals[2]);
                    if (vals.Length == 3)
                    {
                        street[PropertyNum] = new Building(floors, w, l);
                    }
                    else
                    {
                        int nbed = Convert.ToInt32(vals[3]);
                        int nbath = Convert.ToInt32(vals[4]);
                        street[PropertyNum] = new House(floors, w, l, nbed, nbath);
                    }
                    Console.WriteLine("Num " + PropertyNum + " data " + w + " " + l);
                    PropertyNum += 1;
                }
                
                // Display the values loaded
                foreach (Building b in street)
                {
                    b.Display();
                }
            }
            catch(IOException){
                Console.WriteLine("Error processing file...");
            }

        }
    }
}