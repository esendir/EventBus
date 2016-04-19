using System;

namespace EventBus
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SubscribeAttribute : Attribute
    {
        public SubscribeAttribute() : base()
        {
        }
    }
}
