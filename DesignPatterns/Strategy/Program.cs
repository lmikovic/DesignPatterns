using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        /// <summary>
        /// The strategy pattern is a design pattern that allows a set of similar algorithms to be defined and encapsulated in their own classes.
        /// The algorithm to be used for a particular purpose may then be selected at run-time according to your requirements.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var robot1 = new Robot("4of11", new BorgBehaviour());
            var robor2 = new Robot("Military Robot", new AggresiveBehaviour());
            var robot3 = new Robot("rotoROBOt", new NormalBehaviour());

            robot1.Move();
            robor2.Move();
            robot3.Move();
        }

        public class AggresiveBehaviour : IRobotBehaviour
        {
            public void Move()
            {
                Console.WriteLine("\tAggresive Behaviour: if find another robot, attack it");
            }
        }

        public class BorgBehaviour : IRobotBehaviour
        {
            public void Move()
            {
                Console.WriteLine("\tBorg Behaviour: if find another robot, assimilate it");
            }
        }

        public class DefensiveBehaviour : IRobotBehaviour
        {
            public void Move()
            {
                Console.WriteLine("\tDefensive Behaviour: if find another robot, run from it");
            }
        }

        public class NormalBehaviour : IRobotBehaviour
        {
            public void Move()
            {
                Console.WriteLine("\tNormal Behaviour: if find another robot, ignore it");
            }
        }

        public interface IRobotBehaviour
        {
            void Move();
        }

        public class Robot
        {
            private readonly IRobotBehaviour _behaviour;
            private readonly string _name;
            public Robot(string name, IRobotBehaviour behaviour)
            {
                _behaviour = behaviour;
                _name = name;
            }

            public void Move()
            {
                Console.WriteLine(_name);
                _behaviour.Move();
            }
        }

    }
}
