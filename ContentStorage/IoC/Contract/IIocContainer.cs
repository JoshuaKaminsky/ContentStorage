namespace ContentStorage.IoC.Contract
{
    public interface IIocContainer
    {
        void Register();

        T Resolve<T>(string named = "");
    }
}