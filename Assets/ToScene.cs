using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour
{
    public string sceneToLoad;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}