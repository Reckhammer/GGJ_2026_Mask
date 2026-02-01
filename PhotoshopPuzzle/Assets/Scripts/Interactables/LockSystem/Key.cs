using UnityEngine;

public class Key : MonoBehaviour
{
    public LockableObject unlockTarget;

    private SpriteRenderer m_SpriteRenderer;
    private Collider2D m_Collider;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        unlockTarget.Unlock();
        BecomeInactive();
    }

    private void BecomeInactive()
    {
        m_SpriteRenderer.enabled = false;
        m_Collider.enabled = false;
    }
}
