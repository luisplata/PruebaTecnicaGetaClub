using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private GameObject[] pointsToSpawn;
    [SerializeField] private int countOfBuildings;
    private BoxCollider boxCollider;

    private void Start()
    {
        for (int i = 0; i < countOfBuildings; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, buildings.Length);
            GameObject building = Instantiate(buildings[randomIndex], transform);
            building.transform.position = pointsToSpawn[i].transform.position;
        }
    }

    public void CreateColliders()
    {
        tag = "Finish";
    }
}
