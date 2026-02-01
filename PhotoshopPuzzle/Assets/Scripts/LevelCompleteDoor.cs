using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteDoor : MonoBehaviour
{
    public Action OnLevelComplete;

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
        yield return new WaitForSeconds(3f);
        LevelPlayerPrefs.Instance.SetLevelPrefComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            CompleteLevel();
    }
}

