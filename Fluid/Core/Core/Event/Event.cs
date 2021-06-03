using System;
using System.Collections.Generic;

namespace Fluid.Core
{
    public class Event<T> where T : EventArgs
    {
        /// <summary>
        /// Represents the function holder type
        /// </summary>
        public delegate void EventFunc(T e);

        /// <summary>
        /// Stores the subscribers
        /// </summary>
        public List<EventFunc> Subscribers = new();

        /// <summary>
        /// Adds a subscriber. Note that if the subscriber is already added no other subscriber is being added. 
        /// </summary>
        /// <param name="subscriber">Is being called when the Event has been invoked.</param>
        public void Add(EventFunc subscriber)
        {
            if (!Subscribers.Contains(subscriber))
            {
                Subscribers.Add(subscriber);
            }
        }
        
        /// <summary>
        /// Appends a subscriber. One single function can subscribe multiple times.
        /// </summary>
        /// <param name="subscriber">Is being called when the Event has been invoked.</param>
        public void Append(EventFunc subscriber)
        {
            Subscribers.Add(subscriber);
        }

        /// <summary>
        /// Removes the first occurence of the subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber that will be removed once when available</param>
        public void Remove(EventFunc subscriber)
        {
            Subscribers.Remove(subscriber);
        }

        /// <summary>
        /// Removes are subscribers that are equal to the argument
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to remove.</param>
        public void RemoveAll(Predicate<EventFunc> match)
        {
            Subscribers.RemoveAll(match);
        }

        /// <summary>
        /// Checks if the subscriber list contains the subscriber
        /// </summary>
        /// <param name="subscriber"></param>
        /// <returns>Returns true if the subscriber list contains the subscriber</returns>
        public bool Contains(EventFunc subscriber)
        {
            return Subscribers.Contains(subscriber);
        }

        /// <summary>
        /// Returns the subscriber list
        /// </summary>
        /// <returns>Returns the subscriber list</returns>
        public List<EventFunc> GetSubscribers()
        {
            return Subscribers;
        }

        public void Invoke(T arg)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Invoke(arg);
                if (arg.Handled) break;
            }
        }
    }
    
    public class Event : Event<EventArgs> { }
}