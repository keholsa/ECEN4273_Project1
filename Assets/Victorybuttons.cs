using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Victorybuttons : MonoBehaviour
{
    UIDocument buttonDocument;
    Button menuButton;
    Button hiddenButton;

    void OnEnable()
    {
        buttonDocument = GetComponent<UIDocument>();
        Debug.Log("uibutton made");
        if (buttonDocument == null)
        {
            Debug.LogError("no button doc found");
        }
        menuButton = buttonDocument.rootVisualElement.Q("menu") as Button;
        hiddenButton = buttonDocument.rootVisualElement.Q("hidden_button") as Button;

        menuButton.RegisterCallback<ClickEvent>(OnmenuClick);
        hiddenButton.RegisterCallback<ClickEvent>(hiddenClick);
    }


    public void hiddenClick(ClickEvent evt)
    {
        Debug.Log("credits has been clicked");
        SceneManager.LoadScene("Game_Over");
        Time.timeScale = 1f;
    }

    public void OnmenuClick(ClickEvent evt)
    {
        Debug.Log("start has been clicked");
        SceneManager.LoadScene("title screen");
        Time.timeScale = 1f;
    }
}
