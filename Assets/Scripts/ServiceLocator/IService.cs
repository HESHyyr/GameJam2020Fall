namespace SpookuleleGames.ServiceLocator
{
    public interface IService
    {
        int Priority { get; }
        void Init();
    }
}