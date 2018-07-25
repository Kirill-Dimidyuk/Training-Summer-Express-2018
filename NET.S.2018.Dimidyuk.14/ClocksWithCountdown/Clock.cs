using System;
using System.Threading;

namespace ClockLibrary
{
    #region Clock
    /// <summary>
    /// class for timer
    /// </summary>
    public class Clock
    {
        static void Main(string[] args)
        { }

        public event EventHandler<MessageEventArgs> Message;

        public Clock() { }

        /// <summary>
        /// Stops stream for some time
        /// </summary>
        /// <param name="time">time of pause of programm</param>
        public void StartTimer(int time)
        {
            Thread.Sleep(time * 1000);
        }

        /// <summary>
        /// Tells subscribers about events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void EventStarted(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"The event {e.message} is started.\n");
        }

        /// <summary>
        /// Starst the event
        /// </summary>
        /// <param name="time"></param>
        /// <param name="message"></param>
        public void StartEvent(int time, string message)
        {
            StartTimer(time);

            Subscription(new MessageEventArgs(time, message));
        }

        /// <summary>
        /// Subscribes people to event
        /// </summary>
        /// <param name="messageEventArgs"></param>
        private void Subscription(MessageEventArgs messageEventArgs)
        {
            Message.Invoke(this, messageEventArgs);
        }
    }
    #endregion

    #region MessageEventArgs
    public class MessageEventArgs
    {
        /// <summary>
        /// Time before event
        /// </summary>
        public readonly int time;
        
        /// <summary>
        /// Message of the event
        /// </summary>
        public readonly string message;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="time">Time before event</param>
        /// <param name="message">Message of the event</param>
        public MessageEventArgs(int time, string message)
        {
            this.time = time;

            this.message = message;
        }
    }
    #endregion
    
    #region Subscriber
    /// <summary>
    /// Class of Subscribers
    /// </summary>
    public class Subscriber
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    
        public string EMail { get; set; }

        /// <summary>
        /// Remembers subscribers about event
        /// </summary>
        public void Remember(object sender, MessageEventArgs e)
        {
            Console.WriteLine($"{Surname} {Name}, you have subscribed for {e.message}");
            Clock.EventStarted(sender, e);
        }
    }
    #endregion
}
