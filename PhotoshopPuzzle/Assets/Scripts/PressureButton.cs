using System;
using UnityEngine;
using UnityEngine.Events;

public class PressureButton : MonoBehaviour
{
    public Action ButtonPressedAction;
    public UnityEvent ButtonPressedEvent;
    public Action ButtonReleasedAction;
    public UnityEvent ButtonReleasedEvent;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void ButtonPressed()
    {
        if (animator != null)
            animator.SetBool("IsPressed", true);

        Debug.Log($"{this.name} Button is Pressed", this);
        ButtonPressedAction?.Invoke();
        ButtonPressedEvent?.Invoke();
    }

    private void ButtonReleased()
    {
        if (animator != null)
            animator.SetBool("IsPressed", false);

        Debug.Log($"{this.name} Button is Released", this);
        ButtonReleasedAction?.Invoke();
        ButtonReleasedEvent?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ButtonPressed();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ButtonReleased();
    }
}
