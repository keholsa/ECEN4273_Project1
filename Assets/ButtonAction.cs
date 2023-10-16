using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonAction : MonoBehaviour
{
    UIDocument buttonDocument;
    Button uiButton;
    void OnEnable()
    {
        buttonDocument = GetComponent<UIDocument>();
        Debug.Log("uibutton made");
        if (buttonDocument == null)
        {
            Debug.LogError("no button doc found");
        }
        uiButton = buttonDocument.rootVisualElement.Q("start") as Button;


        if (uiButton != null)
        {
            Debug.Log("buttonfound");
        }

        uiButton.RegisterCallback<ClickEvent>(OnButtonClick);
        
    }

    public void OnButtonClick(ClickEvent evt)
    {
        Debug.Log("start has been clicked");
        SceneManager.LoadScene("Level1");
    }    
}
