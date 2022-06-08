using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private GameObject[] pointsToSpawn;
    [SerializeField] private GameObject[] pointsToSpawnAPerson;
    [SerializeField] private int countOfBuildings;
    [SerializeField] private int countOfPeople;
    private BoxCollider boxCollider;

    private void Start()
    {
        for (int i = 0; i < countOfBuildings; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, buildings.Length);
            GameObject building = Instantiate(buildings[randomIndex], transform);
            building.transform.position = pointsToSpawn[i].transform.position;
        }
        for (int i = 0; i < countOfPeople; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, pointsToSpawnAPerson.Length);
            character_Ctrl building = ServiceLocator.Instance.GetService<IFactoryPeople>().Create();
            building.transform.SetParent(transform);
            building.transform.position = pointsToSpawnAPerson[randomIndex].transform.position;
        }
    }

    public void CreateColliders()
    {
        tag = "Finish";
    }
}
