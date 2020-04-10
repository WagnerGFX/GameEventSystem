namespace EventSystem
{
    public struct OnSomethingHappened : IEventArgs
    {
        public object sender { get; }

        public OnSomethingHappened(object sender)
        {
            this.sender = sender;
        }
    }
}