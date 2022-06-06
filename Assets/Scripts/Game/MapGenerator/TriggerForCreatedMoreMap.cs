using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerForCreatedMoreMap : MonoBehaviour
{
    public Action OnTrigger;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger with {other.name} and tag {other.tag}");
        if(!other.CompareTag("Finish")) return;
        Debug.Log($"Trigger with {other.name}");
        OnTrigger?.Invoke();
    }
}
