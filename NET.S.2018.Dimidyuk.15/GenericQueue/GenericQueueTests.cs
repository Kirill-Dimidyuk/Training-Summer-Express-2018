using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using GenericQueue;

namespace GenericQueue.Tests
{
    [TestClass]
    public class GenericQueueTests
    {
        [Test]
        public void GenericQueue_Enqueue_Success()
        {
            GenericQueue<int> queue = new GenericQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            int[] expected = { 1, 2, 3, 4, 5, 6 };

            NUnit.Framework.CollectionAssert.AreEqual(queue, expected);
        }

        [Test]
        public void GenericQueue_Dequeue_Success()
        {
            GenericQueue<string> queue = new GenericQueue<string>();
            queue.Enqueue("a");
            queue.Enqueue("b");
            queue.Enqueue("c");
            queue.Enqueue("d");
            queue.Enqueue("e");
            queue.Enqueue("f");
            string dequeuedItem = queue.Dequeue();
            string expected = "a";
            string[] expected1 = {"b", "c", "d", "e", "f" };

            NUnit.Framework.Assert.AreEqual(expected, dequeuedItem);

            NUnit.Framework.CollectionAssert.AreEqual(queue, expected1);
        }

        [Test]
        public void GenericQueue_Clear_Success()
        {
            GenericQueue<int> queue = new GenericQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Clear();
            int[] expected = { } ;

            NUnit.Framework.Assert.AreEqual(expected, queue);
        }

        [Test]
        public void GenericQueue_Peek_Success()
        {
            GenericQueue<int> queue = new GenericQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            int[] expected = { 1, 2, 3, 4, 5, 6 };
            int peekedItem = queue.Peek();
            int expected1 = 1;

            NUnit.Framework.Assert.AreEqual(expected1, peekedItem);

            NUnit.Framework.CollectionAssert.AreEqual(queue, expected);
        }
    }
}
