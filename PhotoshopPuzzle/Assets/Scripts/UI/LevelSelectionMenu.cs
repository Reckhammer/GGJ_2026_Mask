using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionMenu : MonoBehaviour
{
    public Button lvl2Btn;
    public Button lvl3Btn;
    public Button lvl4Btn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetButtonInteractability();
    }

    private void SetButtonInteractability()
    {
        lvl2Btn.interactable = PlayerPrefs.HasKey(LevelPlayerPrefs.Instance.prefNames[0]);
        lvl3Btn.interactable = PlayerPrefs.HasKey(LevelPlayerPrefs.Instance.prefNames[1]);
        lvl4Btn.interactable = PlayerPrefs.HasKey(LevelPlayerPrefs.Instance.prefNames[2]);
    }
}
