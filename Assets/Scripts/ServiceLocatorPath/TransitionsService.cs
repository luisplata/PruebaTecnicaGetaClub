using System;
using System.Threading.Tasks;
using UnityEngine;

public class TransitionsService : MonoBehaviour, ITransitionService
{
    [SerializeField] private Animator animator;
    private bool hasFinishedTransition;
    
    public void AnimationFinished()
    {
        hasFinishedTransition = true;
    }

    public void Open()
    {
        animator.SetBool("open", false);
    }

    public async void Open(Action callback)
    {
        Open();
        while (!hasFinishedTransition)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(10));   
        }
        callback?.Invoke();
        hasFinishedTransition = false;
    }

    public void Close()
    {
        animator.SetBool("open", true);
    }

    public async void Close(Action callback)
    {
        Close();
        while (!hasFinishedTransition)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(10));   
        }
        callback?.Invoke();
        hasFinishedTransition = false;
    }
}