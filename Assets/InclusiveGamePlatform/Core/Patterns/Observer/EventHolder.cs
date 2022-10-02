using System;
using System.Collections.Generic;
using UnityEngine;

namespace InclusiveGamePlatform.Core.Patterns.Observer
{
    public static class EventHolder<T> where T : class
    {
        private static readonly List<Action<T>> _subscribers = new List<Action<T>>();
        
        public static void Subscribe(Action<T> subscriber)
        {
            if (!_subscribers.Contains(subscriber))
                _subscribers.Add(subscriber);
            else
                Debug.LogWarning($"You can't add a subscriber - {subscriber.GetType()}, because it's already subscribed.");
        }

        public static void Unsubscribe(Action<T> subscriber)
        {
            if (_subscribers.Contains(subscriber))
                _subscribers.Remove(subscriber);
            else
                Debug.LogWarning($"You can't remove a subscriber - {subscriber.GetType()}, because it's already removed.");
        }

        public static void Notify(T state)
        {
            foreach (var subscriber in _subscribers)
                subscriber?.Invoke(state);
        }
    }
}