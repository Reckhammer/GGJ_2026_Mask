using System;
using UnityEngine;
using UnityEngine.Events;

public class LockableObject : MonoBehaviour, IUnlockable, ILockable
{
    public bool isLocked;

    public Action OnLocked;
    public UnityEvent OnLockedEvent;
    public Action OnUnlocked;
    public UnityEvent OnUnlockedEvent;

    public virtual void Lock()
    {
        isLocked = true;
        OnLocked?.Invoke();
        OnLockedEvent?.Invoke();
    }

    public virtual void Unlock()
    {
        isLocked = false;
        OnUnlocked?.Invoke();
        OnUnlockedEvent?.Invoke();
    }
}
