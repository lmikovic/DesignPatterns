using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            //list of participants
            IColleague<string> colleagueA = new ConcreteColleague<string>("ColleagueA");
            IColleague<string> colleagueB = new ConcreteColleague<string>("ColleagueB");
            IColleague<string> colleagueC = new ConcreteColleague<string>("ColleagueC");
            IColleague<string> colleagueD = new ConcreteColleague<string>("ColleagueD");

            //first mediator
            IMediator<string> mediator1 = new ConcreteMediator<string>();
            //participants registers to the mediator
            mediator1.Register(colleagueA);
            mediator1.Register(colleagueB);
            mediator1.Register(colleagueC);
            //participantA sends out a message
            colleagueA.SendMessage(mediator1, "MessageX from ColleagueA");

            //second mediator
            IMediator<string> mediator2 = new ConcreteMediator<string>();
            //participants registers to the mediator
            mediator2.Register(colleagueB);
            mediator2.Register(colleagueD);
            //participantB sends out a message
            colleagueB.SendMessage(mediator2, "MessageY from ColleagueB");

            Console.Read();
        }
    }

    public interface IColleague<T>
    {
        void SendMessage(IMediator<T> mediator, T message);

        void ReceiveMessage(T message);
    }

    public class ConcreteColleague<T> : IColleague<T>
    {
        private string name;

        public ConcreteColleague(string name)
        {
            this.name = name;
        }

        void IColleague<T>.SendMessage(IMediator<T> mediator, T message)
        {
            mediator.DistributeMessage(this, message);
        }

        void IColleague<T>.ReceiveMessage(T message)
        {
            Console.WriteLine(this.name + " received " + message.ToString());
        }
    }

    public interface IMediator<T>
    {
        List<IColleague<T>> ColleagueList { get; }

        void DistributeMessage(IColleague<T> sender, T message);

        void Register(IColleague<T> colleague);
    }

    public class ConcreteMediator<T> : IMediator<T>
    {
        private List<IColleague<T>> colleagueList = new List<IColleague<T>>();

        List<IColleague<T>> IMediator<T>.ColleagueList
        {
            get { return colleagueList; }
        }

        void IMediator<T>.Register(IColleague<T> colleague)
        {
            colleagueList.Add(colleague);
        }

        void IMediator<T>.DistributeMessage(IColleague<T> sender, T message)
        {
            foreach (IColleague<T> c in colleagueList)
                if (c != sender)    //don't need to send message to sender
                    c.ReceiveMessage(message);
        }
    }
}
