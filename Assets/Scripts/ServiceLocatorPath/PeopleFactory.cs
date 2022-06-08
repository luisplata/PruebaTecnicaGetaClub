using UnityEngine;

namespace ServiceLocatorPath
{
    public class PeopleFactory : IFactoryPeople
    {
        private readonly PeopleConfiguration _peopleConfiguration;

        public PeopleFactory(PeopleConfiguration peopleConfiguration)
        {
            _peopleConfiguration = peopleConfiguration;
        }
        
        public character_Ctrl Create(string id)
        {
            var prefab = _peopleConfiguration.GetPersonPrefabById(id);
            return Object.Instantiate(prefab);
        }

        public character_Ctrl Create()
        {
            var prefab = _peopleConfiguration.GetRandomPersonPrefab();
            return Create(prefab.name);
        }
    }
}