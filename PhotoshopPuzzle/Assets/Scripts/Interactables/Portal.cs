using System.Collections;
using UnityEngine;

public class Portal : LockableObject
{
    public Portal exitPortal;
    public float teleportCooldown = 1f;

    private bool isTeleporting = false;

    private AudioSource sfx;

    private void Awake()
    {
        sfx = GetComponent<AudioSource>();
    }

    private void Teleport(GameObject go)
    {
        if (!isTeleporting)
        {
            isTeleporting = true;
            exitPortal.isTeleporting = true;
            StartCoroutine(TeleportSequence(go));
        }
    }

    private IEnumerator TeleportSequence(GameObject go)
    {
        Debug.Log($"{this.name} is teleporting {go.name}", this);
        if (go.TryGetComponent(out Rigidbody2D rb))
            rb.linearVelocity = Vector2.zero;

        SetTeleportCooldown();
        exitPortal.SetTeleportCooldown();
        yield return null;
        go.transform.SetPositionAndRotation(exitPortal.transform.position, Quaternion.identity);
        PlaySFX();
    }

    public void SetTeleportCooldown()
    {
        Debug.Log($"{this.name} Teleport Cooling Down", this);
        StartCoroutine(TeleportCooldownRoutine());
    }

    private IEnumerator TeleportCooldownRoutine()
    {
        yield return new WaitForSeconds(teleportCooldown);
        isTeleporting = false;
        Debug.Log($"{this.name} Teleport Down Finished", this);
    }

    private void PlaySFX()
    {
        if (sfx != null)
            sfx.Play();
    }

    public override void Lock()
    {
        base.Lock();
    }

    public override void Unlock()
    {
        base.Unlock();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isLocked)
            Teleport(collision.gameObject);
    }
}
