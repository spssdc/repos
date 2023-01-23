namespace Buildings
{
    // Parent Building class
    public class Building
    {
        // Initialisation with defaults for attributes
        private int numberFloors = 1;
        private float width = 0.0f;
        private float length = 0.0f;

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
            Console.WriteLine("The building has a width of "+this.Width+"m, a length of "+this.length+"m and is a "+this.calcSize()+" size");
        }

        public string calcSize()
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

        // Could calc as small/medium/large dependent
        // on number bedrooms 1-2, 3-5, 6+

        public int NumBedrooms
        {
            get { return numBedrooms; }
            set { numBedrooms = value; }
        }

        // Calling base/super
        public House(int pNF, float pW, float pL, int pNB) : base(pNF,pW,pL)
        {
            Console.WriteLine("Instantiating... a House");
            this.numBedrooms = pNB;
        }

        // Polymorphism in action overriding the parent class method
        // to also print the number of bedrooms
        public override void Display()
        {
            Console.WriteLine("House");
            Console.WriteLine("Floors: "+this.NumberFloors+"Beds: "+this.numBedrooms);
        }
    }

    // Composition (aggregation) of street made up of buildings
    public class Street
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

        public Street()
        {
        }

        public void PrintStreet()
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
            Building Building1 = new Building(2, 8.4f, 7.8f);
            Building1.Display();
            List<House> block = new List<House>();
            block.Add(new House(2, 15, 20, 3));
            block.Add(new House(2, 10, 10, 5));
            block.Add(new House(2, 20, 10, 4));
            block.Add(new House(2, 10, 20, 2));
            foreach (Building b in block)
            {
                Console.WriteLine(b.FootPrint());
            }
            // Using new equality operator
            if (block[1].Equals(block[2])){
                Console.WriteLine("Equality");
            }
            else
            {
                Console.WriteLine("NOT");
            }
            Street s = new Street();
            s.addBuilding(new House(1, 1, 1, 1));
            s.addBuilding(new Building(2, 20, 8));
            s.PrintStreet();
        }
    }
}