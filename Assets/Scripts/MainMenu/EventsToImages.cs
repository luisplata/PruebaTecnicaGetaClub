using System;
using System.Collections;
using System.Collections.Generic;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventsToImages : MonoBehaviour
{
    public Action OnSelected;
    [SerializeField] private Color normal, hover, selected;
    [SerializeField] private TypeOfBird _typeOfBird;
    [SerializeField] private Bird bird;
    private bool isSeleted;

    private void Start()
    {
        bird.SetColor(normal);
    }

    public void Click(BaseEventData evento){
        OnSelected?.Invoke();
        bird.SetColor(selected);
        isSeleted = true;
        ServiceLocator.Instance.GetService<ISaveData>().SaveBird(_typeOfBird);
        bird.Selected();
    }
    public void MouseEnter(BaseEventData evento)
    {
        if (isSeleted) return;
        bird.SetColor(hover);
    }
    public void MouseLeave(BaseEventData evento)
    {
        if (isSeleted) return;
        bird.SetColor(normal);
    }

    public void Unselected()
    {
        bird.SetColor(normal);
        isSeleted = false;
        bird.UnSelected();
    }
}