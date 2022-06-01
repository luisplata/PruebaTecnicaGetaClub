using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Image image;
    
    public void SetColor(Color color)
    {
        image.color = color;
    }

    public void Selected()
    {
        animator.SetBool("selected", true);
    }
    public void UnSelected()
    {
        animator.SetBool("selected", false);
    }
}
