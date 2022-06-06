using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Assertions;

public class Generator : MonoBehaviour
{
    [SerializeField] private Map map;
    [SerializeField] private int firstMapsCount;
    [SerializeField] private int distanceBetweenMaps;
    private int indexOfMap;

    private void Start()
    {
        Map lastMap = null;
        for (int i = 0; i < firstMapsCount; i++)
        {
            lastMap = GenerateMap();
        }
        Assert.IsNotNull(lastMap);
        lastMap.CreateColliders();
    }

    private Map GenerateMap()
    {
        var instantiate = ServiceLocator.Instance.GetService<IObjectPool>().CreateMap(map);
        instantiate.gameObject.transform.SetParent(transform);
        instantiate.transform.localPosition = new Vector3(0, 0, indexOfMap * distanceBetweenMaps);
        indexOfMap++;
        return instantiate;
    }

    public void GenerateMapWithColliders()
    {
        var generateMap = GenerateMap();
        generateMap.CreateColliders();
    }
}
