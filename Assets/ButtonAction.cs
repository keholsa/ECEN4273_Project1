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
    Button hiddenButton;

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
        hiddenButton = buttonDocument.rootVisualElement.Q("hidden_button") as Button;
        /* debug info
        if (startButton != null)
        {
            Debug.Log("buttonfound");
        }
        */

        startButton.RegisterCallback<ClickEvent>(OnStartClick);
        exitButton.RegisterCallback<ClickEvent>(OnExitClick);
        hiddenButton.RegisterCallback<ClickEvent>(CreditsClick);
    }

    public void CreditsClick(ClickEvent evt)
    {
        Debug.Log("credits has been clicked");
        SceneManager.LoadScene("Game_Over");
        Time.timeScale = 1f;
    }

    public void OnStartClick(ClickEvent evt)
    {
        Debug.Log("start has been clicked");
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }
    public void OnExitClick(ClickEvent evt)
    {
        Debug.Log("Exit has been clicked");
        Application.Quit();
    }
}
