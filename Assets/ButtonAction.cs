using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonAction : MonoBehaviour
{
    UIDocument buttonDocument;
    Button startButton;
    Button exitButton;

    void OnEnable()
    {
        buttonDocument = GetComponent<UIDocument>();
        Debug.Log("uibutton made");
        if (buttonDocument == null)
        {
            Debug.LogError("no button doc found");
        }
        startButton = buttonDocument.rootVisualElement.Q("start") as Button;
        exitButton = buttonDocument.rootVisualElement.Q("exit") as Button;

        if (startButton != null)
        {
            Debug.Log("buttonfound");
        }

        startButton.RegisterCallback<ClickEvent>(OnStartClick);
        exitButton.RegisterCallback<ClickEvent>(OnExitClick);
    }

    public void OnStartClick(ClickEvent evt)
    {
        Debug.Log("start has been clicked");
        SceneManager.LoadScene("Level1");
    }
    public void OnExitClick(ClickEvent evt)
    {
        Debug.Log("Exit has been clicked");
        Application.Quit();
    }
}
