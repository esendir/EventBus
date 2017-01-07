using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace EventBus
{
    /// <summary>
    /// event bus implementation
    /// </summary>
    public class EventBus : IEventBus
    {
        private readonly HashSet<object> _subscribers;

        public EventBus()
        {
            _subscribers = new HashSet<object>();
        }

        /// <summary>
        /// register class
        /// </summary>
        /// <param name="subscriber">class object</param>
        public void Register(object subscriber)
        {
            _subscribers.Add(subscriber);
        }

        /// <summary>
        /// unregister class
        /// </summary>
        /// <param name="subscriber">class object</param>
        public void Unregister(object subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        /// <summary>
        /// post event
        /// </summary>
        /// <param name="e"></param>
        public void Post(object e)
        {
            foreach (object instance in _subscribers.ToArray())
            {
                foreach (MethodInfo method in GetSubscribedMethods(instance.GetType(), e))
                {
                    try
                    {
                        method.Invoke(instance, new object[] { e });
                    }
                    catch (Exception ex) {
                    }
                }
            }
        }

        private IEnumerable<MethodInfo> GetSubscribedMethods(Type type, object obj)
        {
            foreach (MethodInfo info in type.GetRuntimeMethods().Where(x => x.GetCustomAttribute<SubscribeAttribute>() != null))
            {
                var paramInfo = info.GetParameters();

                if (paramInfo.Length == 1 && paramInfo[0].ParameterType == obj.GetType())
                {
                    yield return info;
                }
            }
        }
    }
}


