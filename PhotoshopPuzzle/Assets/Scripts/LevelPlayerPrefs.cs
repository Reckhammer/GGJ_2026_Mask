
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPlayerPrefs : MonoBehaviour
{
    public static LevelPlayerPrefs Instance {  get; private set; }

    public readonly string[] prefNames = {"Level1Complete", "Level2Complete", "Level3Complete", "Level4Complete", "Level5Complete", "Level6Complete" };

    public void SetLevelPrefComplete()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName.IndexOf("_") == -1)
            return;

        string levelNumString = sceneName.Substring(sceneName.IndexOf("_") + 1);
        int levelNum = int.Parse(levelNumString);

        switch (levelNum)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
            case 6:
                PlayerPrefs.SetInt(prefNames[levelNum - 1], 1);
                break;
            default:
                Debug.Log($"LevelPlayerPrefs has an invalid level number to save");
                break;
        }
    }
}
