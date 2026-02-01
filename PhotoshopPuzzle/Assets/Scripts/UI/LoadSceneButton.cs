using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public string sceneToLoad = "Invalid Scene"; // Todo: some make only scenes in build order as only options
    private Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
        myButton.onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        // Todo: Make some scene manager that can transition into a loading scene and load scenes async
        SceneManager.LoadScene(sceneToLoad);
    }
}
