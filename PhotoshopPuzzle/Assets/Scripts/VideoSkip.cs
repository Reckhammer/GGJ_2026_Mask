using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoSkip : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Debug Return"))
        {
            Debug.Log("Skipping video");
            SceneManager.LoadScene("Level_1");
        }
    }
}
