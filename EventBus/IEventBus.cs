namespace EventBus
{
    /// <summary>
    /// interface for event bus
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// register class
        /// </summary>
        /// <param name="subscriber">class object</param>
        void Register(object subscriber);

        /// <summary>
        /// unregister class
        /// </summary>
        /// <param name="subscriber">class object</param>
        void Unregister(object subscriber);

        /// <summary>
        /// post event
        /// </summary>
        /// <param name="e"></param>
        void Post(object e);
    }
}
