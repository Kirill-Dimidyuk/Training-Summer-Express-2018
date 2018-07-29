using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericQueue
{
    #region Queue
    /// <summary>
    /// class of Queue
    /// </summary>
    public class GenericQueue<T> : IEnumerable<T>
    {
        private T[] queue;
        private int begin = 0;
        private int end = -1;
        private int count = 0;
        private int capacity;
        private const int defaultCapacity = 4;

        #region Ctors
        public GenericQueue() : this(defaultCapacity) { }

        public GenericQueue(int capacity) 
        {
            if(capacity <= 0)
            {
                throw new ArgumentException($"{nameof(capacity)} must be grater than zero");
            }

            this.capacity = capacity;
            queue = new T[capacity];
        }
        #endregion

        #region Public Methods        
        /// <summary>
        /// Adds the specified object into a queue.
        /// </summary>
        /// <param name="obj">The object to be added</param>
        public void Enqueue (T obj)
        {
            if((count + 1 > capacity))
            {
                ExtensionOfQueue();
            }

            end++;
            count++;
            queue[end] = obj;
        }

        /// <summary>
        /// Deletes object from the queue
        /// </summary>
        /// <returns>deleted object</returns>
        /// <exception cref="ArgumentException"></exception>
        public T Dequeue()
        {
            if(count == 0)
            {
                throw new ArgumentException($"Queue is empty");
            }

            T item = queue[begin];

            for (int i = 0; i < count - 1; i++)
            {
                queue[i] = queue[i + 1];
            }

            queue[count] = default(T);
            count--;
            end--;

            return item;
        }

        /// <summary>
        /// retures object fron the queue
        /// </summary>
        /// <returns>object fron the queue</returns>
        /// <exception cref="ArgumentException"></exception>
        public T Peek()
        {
            if (count == 0)
            {
                throw new ArgumentException($"Queue is empty");
            }

            return queue[begin];
        }

        /// <summary>
        /// Makes the queue empty
        /// </summary>
        public void Clear()
        {
            queue = new T[defaultCapacity];
            begin = 0;
            end = -1;
            count = 0;
            capacity = defaultCapacity;
        }
        #endregion

        #region Private Methods        
        /// <summary>
        /// Extends the queue.
        /// </summary>
        private void ExtensionOfQueue()
        {
            Array.Resize(ref queue, capacity * 2);
            capacity *= 2;
        }
        #endregion

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            T[] copiedQueue = new T[capacity];
            Array.Copy(queue, copiedQueue, copiedQueue.Length);
            return new EnumeratorOfQueue<T>(copiedQueue, end, begin, count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            T[] copiedQueue = new T[capacity];
            Array.Copy(queue, copiedQueue, copiedQueue.Length);
            return new EnumeratorOfQueue<T>(copiedQueue, end, begin, count);
        }
    }
    #endregion

    #region Enumerator
    /// <summary>
    /// Enumerator of queue
    /// </summary>
    public struct EnumeratorOfQueue<T> : IEnumerator<T>
    {
        private readonly T[] queue;
        private readonly int end;
        private readonly int begin;
        private readonly int count;
        private int currentIndex;
        private int currentCount;

        #region Ctor
        public EnumeratorOfQueue(T[] queue, int end, int begin, int count)
        {
            if (queue is null)
            {
                throw new ArgumentNullException($"{nameof(queue)} can`t be null");
            }

            this.queue = queue;
            this.end = end;
            this.begin = begin;
            this.count = count;
            currentIndex =  begin - 1;
            currentCount = 0;
        }
        #endregion

        #region Methods of Enumerator
        public T Current
        {
            get
            {
                if (currentIndex == -1 || currentIndex == count)
                {
                    throw new InvalidOperationException();
                }

                return queue[currentIndex];
            }
        }

        object IEnumerator.Current => queue[currentIndex];

        public void Dispose() { }

        public bool MoveNext()
        {
            if (currentCount >= count)
            {
                return false;
            }

            if (currentIndex == queue.Length - 1)
            {
                currentIndex = -1;
            }
            currentIndex++;
            currentCount++;
            return true;
        }

        public void Reset()
        {
            currentIndex = begin;
            currentCount = 0;
        }
    }
    #endregion
    #endregion
}
