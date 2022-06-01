using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Rules : MonoBehaviour
{
    [SerializeField] private List<EventsToImages> images;

    private void Start()
    {
        foreach (var image in images)
        {
            image.OnSelected += OnSelected;
        }

        ServiceLocator.Instance.GetService<ISaveData>().ClearData();
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(1);
        ServiceLocator.Instance.GetService<ITransitionService>().Open(() => { });
    }
    private void OnSelected()
    {
        foreach (var image in images)
        {
            image.Unselected();
        }
    }

    public void StartGame()
    {
        if (ServiceLocator.Instance.GetService<ISaveData>().HasSelectedBird())
        {
            ServiceLocator.Instance.GetService<ITransitionService>().Close(() =>
            {
                SceneManager.LoadScene(0);
            });   
        }
        else
        {
            //mandar un mensaje de que no selecciono ninguna ave
            ServiceLocator.Instance.GetService<IMessageService>().ShowMessage("You must select a bird", "Please select a bird");
        }
    }
}
