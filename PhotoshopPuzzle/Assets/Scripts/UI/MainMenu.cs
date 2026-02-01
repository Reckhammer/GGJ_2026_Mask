using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

// Deprecate or repurpose into changing UI only
public class MainMenu : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("IntroVideo");
    }

    public void OnVideoSkipButtonClicked()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void OnQuitClickedClicked()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

        Application.Quit();   
    }

    public void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnCreditsButtonClicked()
    {
        Debug.Log("Button");
        SceneManager.LoadScene("Credits_Scene");
    }

    public void OnMainSceneButtonClicked()
    {
        SceneManager.LoadScene("Level_01");
    }

    public void OnLevelComplete()
    {
        LevelPlayerPrefs.Instance.SetLevelPrefComplete();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
