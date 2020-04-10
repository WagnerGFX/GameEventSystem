namespace EventSystem
{
    /// <summary>
    /// Used to call the ClearListeners() without defining the generic type
    /// </summary>
    public interface IEventHolderClear
    {
        void ClearListeners();
    }
}
