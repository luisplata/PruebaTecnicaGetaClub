using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;

public class InstallerServiceLocator : MonoBehaviour
{
    [SerializeField] private TransitionsService transitionsService;
    [SerializeField] private MessageService messageService;
    [SerializeField] private PeopleConfiguration peopleConfiguration;
    private void Awake()
    {
        if (FindObjectsOfType<InstallerServiceLocator>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        var saveData = new SaveData();
        ServiceLocator.Instance.RegisterService<ISaveData>(saveData);
        ServiceLocator.Instance.RegisterService<ITransitionService>(transitionsService);
        ServiceLocator.Instance.RegisterService<IMessageService>(messageService);
        ServiceLocator.Instance.RegisterService<IObjectPool>(new ObjectPoolBadImplementation());
        ServiceLocator.Instance.RegisterService<IFactoryPeople>(new PeopleFactory(Instantiate(peopleConfiguration)));
        DontDestroyOnLoad(gameObject);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

}