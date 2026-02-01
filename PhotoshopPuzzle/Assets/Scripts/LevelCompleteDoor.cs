using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelCompleteDoor : MonoBehaviour
{
    public Action OnLevelComplete;
    public UnityEvent OnLevelCompleteEvent;

    private AudioSource sfx;

    private void Awake()
    {
        sfx = GetComponent<AudioSource>();
    }

    private void CompleteLevel()
    {
        StartCoroutine(LevelCompleteRoutine());
    }

    private IEnumerator LevelCompleteRoutine()
    {
        Debug.Log("Level Complete. Going to next level");
        if (sfx != null)
            sfx.Play();

        OnLevelComplete?.Invoke();
        OnLevelCompleteEvent?.Invoke();
        yield return new WaitForSeconds(3f);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CompleteLevel();
            if (collision.TryGetComponent(out PlayerController player))
            {
                player.canMove = false;
                player.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            }
        }
    }
}

