using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;

public class TriggerForDeletingMaps : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ServiceLocator.Instance.GetService<IObjectPool>().RecycleObject(other.gameObject);
    }
}