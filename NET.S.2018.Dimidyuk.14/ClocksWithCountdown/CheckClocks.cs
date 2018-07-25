using System;
using ClockLibrary;

namespace Clocks
{
    class CheckClocks
    {
        static void Main(string[] args)
        {
            while (Console.ReadLine() != "stop")
            {
                Clock clock = new Clock();
                Subscriber subscriber1 = new Subscriber { Name = "Kirill", Surname = "Dimidyuk", EMail = "kirill.dimidyuk@gmail.com" };

                Subscriber subscriber2 = new Subscriber { Name = "Maxim", Surname = "Kondratovich", EMail = "maxim.Kondratovich@gmail.com" };

                Subscriber subscriber3 = new Subscriber { Name = "Sasha", Surname = "Yachnik", EMail = "sasha.yachnik@gmail.com" };

                clock.Message += subscriber1.Remember;

                clock.Message += subscriber2.Remember;

                clock.Message += subscriber3.Remember;

                clock.StartEvent(2, "Life starts now");

                clock.Message -= subscriber3.Remember;

                clock.StartEvent(2, "Life starts now");
            }
        }
    }
}
