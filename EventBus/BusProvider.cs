using System;

namespace EventBus
{
    /// <summary>
    /// Singleton pattern for eventbus
    /// </summary>
    public class BusProvider
    {
        private static Lazy<EventBus> _instance = new Lazy<EventBus>();

        public static EventBus Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private BusProvider()
        {
        }
    }
}
