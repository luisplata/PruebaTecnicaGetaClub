namespace ServiceLocatorPath
{
    public interface ISaveData
    {
        void SaveBird(TypeOfBird typeOfBird);
        bool HasSelectedBird();
        void ClearData();
    }
}