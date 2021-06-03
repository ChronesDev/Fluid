using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Fluid.Core
{
    public class PriotisedEvent<T> where T : EventArgs
    {
        /// <summary>
        /// Represents the function holder type
        /// </summary>
        public delegate void EventFunc(T e);

        /// <summary>
        /// Stores the subscribers in different priority groups
        /// </summary>
        public Dictionary<EventPriority, List<EventFunc>> Subscribers = new();

        protected PriotisedEvent()
        {
            Subscribers.Add(EventPriority.Highest, new());
            Subscribers.Add(EventPriority.High, new());
            Subscribers.Add(EventPriority.Normal, new());
            Subscribers.Add(EventPriority.Low, new());
        }
        
        /// <summary>
        /// Adds a subscriber. Note that if the subscriber is already added no other subscriber is being added. 
        /// </summary>
        /// <param name="subscriber">Is being called when the Event has been invoked.</param>
        /// /// <param name="priority">Determines the priority of the subscriber</param>
        public void Add(EventFunc subscriber, EventPriority priority = EventPriority.Normal)
        {
            Subscribers[priority].Add(subscriber);
        }

        /// <summary>
        /// Appends a subscriber. One single function can subscribe multiple times.
        /// </summary>
        /// <param name="subscriber">Is being called when the Event has been invoked.</param>
        /// <param name="priority">Determines the priority of the subscriber</param>
        public void Append(EventFunc subscriber, EventPriority priority = EventPriority.Normal)
        {
            Subscribers[priority].Add(subscriber);
        }

        /// <summary>
        /// Removes the first occurence of the subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber that will be removed once when available</param>
        /// /// <param name="priority">Determines the priority of the subscriber</param>
        public void Remove(EventFunc subscriber, EventPriority priority)
        {
            Subscribers[priority].Remove(subscriber);
        }
        
        /// <summary>
        /// Removes the first occurence of the subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber that will be removed once when available</param>
        public void Remove(EventFunc subscriber)
        {
            foreach (var subscriberList in Subscribers)
            {
                if (subscriberList.Value.Contains(subscriber))
                {
                    subscriberList.Value.Remove(subscriber);
                    break;
                }
            }
        }

        /// <summary>
        /// Removes are subscribers that are equal to the argument
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to remove.</param>
        /// <param name="priority">Determines the priority of the subscriber</param>
        public void RemoveAll(Predicate<EventFunc> match, EventPriority priority)
        {
            Subscribers[priority].RemoveAll(match);
        }
        
        /// <summary>
        /// Removes are subscribers that are equal to the argument
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to remove.</param>
        public void RemoveAll(Predicate<EventFunc> match)
        {
            foreach (var subscriberList in Subscribers) subscriberList.Value.RemoveAll(match);
        }

        /// <summary>
        /// Checks if the subscriber list contains the subscriber
        /// </summary>
        /// <param name="subscriber"></param>
        /// <param name="priority">Determines the priority of the subscriber</param>
        /// <returns>Returns true if the subscriber list contains the subscriber</returns>
        public bool Contains(EventFunc subscriber, EventPriority priority)
        {
            return Subscribers[priority].Contains(subscriber);
        }
        
        /// <summary>
        /// Checks if the subscriber list contains the subscriber
        /// </summary>
        /// <param name="subscriber"></param>
        /// <returns>Returns true if the subscriber list contains the subscriber</returns>
        public bool Contains(EventFunc subscriber)
        {
            foreach (var subscriberList in Subscribers)
            {
                if (subscriberList.Value.Contains(subscriber)) return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the subscriber list
        /// </summary>
        /// <returns>Returns the subscriber list</returns>
        public Dictionary<EventPriority, List<EventFunc>> GetSubscribers()
        {
            return Subscribers;
        }

        public void Invoke(T arg)
        {
            foreach (var func in Subscribers[EventPriority.Highest])
            {
                func.Invoke(arg);
                if (arg.Handled) return;
            }
            foreach (var func in Subscribers[EventPriority.High])
            {
                func.Invoke(arg);
                if (arg.Handled) return;
            }
            foreach (var func in Subscribers[EventPriority.Normal])
            {
                func.Invoke(arg);
                if (arg.Handled) return;
            }
            foreach (var func in Subscribers[EventPriority.Low])
            {
                func.Invoke(arg);
                if (arg.Handled) return;
            }
        }
    }
    
    public class PriotisedEvent : PriotisedEvent<EventArgs> { }
}