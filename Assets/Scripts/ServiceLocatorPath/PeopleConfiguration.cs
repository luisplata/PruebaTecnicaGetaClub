using System;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorPath
{
    [CreateAssetMenu(menuName = "Custom/People configuration")]
    public class PeopleConfiguration : ScriptableObject
    {
        [SerializeField] private character_Ctrl[] people;
        private Dictionary<string, character_Ctrl> _idToPerson;

        private void Awake()
        {
            _idToPerson = new Dictionary<string, character_Ctrl>(people.Length);
            foreach (var person in people)
            {
                _idToPerson.Add(person.name, person);
            }
        }

        public character_Ctrl GetPersonPrefabById(string id)
        {
            if (!_idToPerson.TryGetValue(id, out var person))
            {
                throw new Exception($"Person with id {id} does not exit");
            }
            return person;
        }

        public character_Ctrl GetRandomPersonPrefab()
        {
            return people[UnityEngine.Random.Range(0, people.Length)];
        }
    }
}