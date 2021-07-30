using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    /// <summary>
    /// The adapter pattern is a design pattern that is used to allow two incompatible types to communicate.
    /// Where one class relies upon a specific interface that is not implemented by another class,
    /// the adapter acts as a translator between the two types.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IAdapter adapter = null;

            //Let emulate the decision where the choice of using the underlying system is made
            Console.WriteLine("Enter which library you wanna use to do operation {1,2}");
            int x = Console.Read();

            if (x == '1')
            {
                //Let us choose to use Library one to do something
                adapter = new AdapterOne();
            }
            else if (x == '2')
            {
                //Let us choose to use Library two to do something
                adapter = new AdapterTwo();
            }

            //Just do the operation now
            adapter.Do();
        }

        class LibraryOne
        {
            public void ThisIsHowOneDoesIt()
            {
                Console.Write("Using Library ONE to perform the action\n");
            }
        }

        //Library Two
        class LibraryTwo
        {
            public string ThisIsHowTwoDoesIt()
            {
                return "Using Library TWO to perform the action";
            }
        }

        interface IAdapter
        {
            void Do();
        }

        //Adapter for first library
        class AdapterOne : IAdapter
        {
            private LibraryOne one = null;

            public AdapterOne()
            {
                one = new LibraryOne();
            }

            #region IAdapter Members

            public void Do()
            {
                one.ThisIsHowOneDoesIt();
            }

            #endregion
        }
        //Adapter for second library
        class AdapterTwo : IAdapter
        {
            private LibraryTwo two = null;

            public AdapterTwo()
            {
                two = new LibraryTwo();
            }

            #region IAdapter Members

            public void Do()
            {
                Console.WriteLine(two.ThisIsHowTwoDoesIt() + "\n"); ;
            }

            #endregion
        }

    }
}
