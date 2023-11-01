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
    Button creditsButton;
    Button InstructionsButton;
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
        creditsButton = buttonDocument.rootVisualElement.Q("Credits") as Button;
        exitButton = buttonDocument.rootVisualElement.Q("exit") as Button;
        InstructionsButton = buttonDocument.rootVisualElement.Q("Instructions") as Button;
        hiddenButton = buttonDocument.rootVisualElement.Q("hidden_button") as Button;
        /* debug info
        if (startButton != null)
        {
            Debug.Log("buttonfound");
        }
        */

        startButton.RegisterCallback<ClickEvent>(OnStartClick);
        creditsButton.RegisterCallback<ClickEvent>(OnCreditsClick);
        exitButton.RegisterCallback<ClickEvent>(OnExitClick);
        InstructionsButton.RegisterCallback<ClickEvent>(OnInstructionsClick);
        hiddenButton.RegisterCallback<ClickEvent>(hiddenClick);
    }

    public void hiddenClick(ClickEvent evt)
    {
        Debug.Log("lose has been clicked");
        SceneManager.LoadScene("Game_Over");
        Time.timeScale = 1f;
    }

    public void OnStartClick(ClickEvent evt)
    {
        Debug.Log("start has been clicked");
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
        keys.left_key = false;
        keys.right_key =false;
        keys.middle_key = false;
    }
    public void OnCreditsClick(ClickEvent evt)
    {
        Debug.Log("credit has been clicked");
        SceneManager.LoadScene("Victory");
        Time.timeScale = 1f;
    }
    public void OnInstructionsClick(ClickEvent evt)
    {
        Debug.Log("inst has been clicked");
        SceneManager.LoadScene("Instructions");
    }
    public void OnExitClick(ClickEvent evt)
    {
        Debug.Log("Exit has been clicked");
        Application.Quit();
    }
}
