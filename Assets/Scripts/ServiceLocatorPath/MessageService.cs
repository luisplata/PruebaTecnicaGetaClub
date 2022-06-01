using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageService : MonoBehaviour ,IMessageService
{
    [SerializeField] private TextMeshProUGUI title, message;
    [SerializeField] private Animator animator;
    [SerializeField] private Button okButton;

    private void Start()
    {
        okButton.onClick.AddListener(() =>
        {
            animator.SetBool("open", false);
        });
    }

    public void ShowMessage(string title, string message)
    {
        Debug.Log($"title {title} message {message}");
        this.title.text = title;
        this.message.text = message;
        animator.SetBool("open", true);
    }
}