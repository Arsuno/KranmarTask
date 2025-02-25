namespace _Project.Source.SaveLoadSystems
{
    public interface ISaveLoadSystem
    {
        void Save<T>(T data);
        T Load<T>();
        bool SaveExists();
    }
}