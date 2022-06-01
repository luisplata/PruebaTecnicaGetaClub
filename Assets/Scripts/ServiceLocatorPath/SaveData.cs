using UnityEngine;

namespace ServiceLocatorPath
{
    public class SaveData : ISaveData
    {
        private TypeOfBird _typeOfBirdSelected = TypeOfBird.None;
        public void SaveBird(TypeOfBird typeOfBird)
        {
            Debug.Log($"type {typeOfBird}");
            _typeOfBirdSelected = typeOfBird;
        }

        public bool HasSelectedBird()
        {
            return _typeOfBirdSelected != TypeOfBird.None;
        }

        public void ClearData()
        {
            _typeOfBirdSelected = TypeOfBird.None;
        }
    }
}