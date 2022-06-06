using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;

public class ParallaxOfMap : MonoBehaviour
{
    [SerializeField] private Generator mapGenerator;
    [SerializeField] private TriggerForCreatedMoreMap trigger;
    [SerializeField] private float speed;

    private void Start()
    {
        ServiceLocator.Instance.GetService<ITransitionService>().Open(() => { });
        trigger.OnTrigger += OnTrigger;
    }

    private void OnTrigger()
    {
        mapGenerator.GenerateMapWithColliders();
    }

    private void Update()
    {
        var transform1 = mapGenerator.transform;
        var position = transform1.position;
        position = new Vector3(transform.position.x, position.y, position.z + (speed * -1));
        transform1.position = position;
    }
}
