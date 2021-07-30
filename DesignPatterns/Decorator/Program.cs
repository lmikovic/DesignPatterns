using System;

namespace Decorator
{
    /// <summary>
    /// The decorator pattern is a design pattern that extends the functionality of individual objects by wrapping them with one or more decorator classes.
    /// These decorators can modify existing members and add new methods and properties at run-time.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Sandwich mySandwich = new VeggieSandwich();
            Console.WriteLine(mySandwich.GetPrice());
            Console.WriteLine(mySandwich.GetDescription());
            mySandwich = new Cheese(mySandwich);
            Console.WriteLine(mySandwich.GetPrice());
            Console.WriteLine(mySandwich.GetDescription());
            mySandwich = new Corn(mySandwich);
            Console.WriteLine(mySandwich.GetPrice());
            Console.WriteLine(mySandwich.GetDescription());
            mySandwich = new Olives(mySandwich);
            Console.WriteLine(mySandwich.GetPrice());
            Console.WriteLine(mySandwich.GetDescription());
            Console.Read();
        }

        public abstract class Sandwich
        {
            public abstract string GetDescription();

            public abstract double GetPrice();

            public string Description { get; set; }
        }

        public class TunaSandwich : Sandwich
        {
            public TunaSandwich()
            {
                Description = "Tuna Sandwich";
            }

            public override string GetDescription()
            {
                return Description;
            }

            public override double GetPrice()
            {
                return 4.10;
            }
        }

        public class VeggieSandwich : Sandwich
        {
            public VeggieSandwich()
            {
                Description = "Veggie Sandwich";
            }

            public override string GetDescription()
            {
                return Description;
            }

            public override double GetPrice()
            {
                return 3.45;
            }
        }

        public class Cheese : SandwichDecorator
        {
            public Cheese(Sandwich sandwich) : base(sandwich)
            {
                Description = "Cheese";
            }

            public override string GetDescription()
            {
                return Sandwich.GetDescription() + ", " + Description;
            }

            public override double GetPrice()
            {
                return Sandwich.GetPrice() + 1.23;
            }
        }

        public class Corn : SandwichDecorator
        {
            public Corn(Sandwich sandwich)
                : base(sandwich)
            {
                Description = "Corn";
            }

            public override string GetDescription()
            {
                return Sandwich.GetDescription() + ", " + Description;
            }

            public override double GetPrice()
            {
                return Sandwich.GetPrice() + 0.35;
            }
        }

        public class Olives : SandwichDecorator
        {
            public Olives(Sandwich sandwich)
                : base(sandwich)
            {
                Description = "Olives";
            }

            public override string GetDescription()
            {
                return Sandwich.GetDescription() + ", " + Description;
            }

            public override double GetPrice()
            {
                return Sandwich.GetPrice() + 0.89;
            }
        }

        public class SandwichDecorator : Sandwich
        {
            protected Sandwich Sandwich;

            public SandwichDecorator(Sandwich sandwich)
            {
                Sandwich = sandwich;
            }

            public override string GetDescription()
            {
                return Sandwich.GetDescription();
            }

            public override double GetPrice()
            {
                return Sandwich.GetPrice();
            }
        }
    }
}
