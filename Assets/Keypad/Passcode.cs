using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this using directive to resolve the 'Text' type
using UnityEngine.SceneManagement;

public class Passcode : MonoBehaviour
{
    string Code = "1234";
    string Nr = "";
    int NrIndex = 0;
    public Text UiText;
   public string sceneToLoad; // The name of the scene to transition to.

    public void CodeFunction(string Numbers)
    {
        NrIndex++;
        Nr = Nr + Numbers;
        UiText.text = Nr;
    }

    public void Enter()
    {
        if (Nr == Code)
        {
            SceneManager.LoadScene(sceneToLoad);
            Debug.Log("Correct code entered. Transition to the next scene here.");
            // Add your scene transition code here.
        }
        else
        {
            Debug.Log("Incorrect code entered.");
            Nr = "";
            UiText.text = Nr;
        }
    }

    public void Delete()
    {
        if (Nr.Length > 0)
        {
            Nr = Nr.Substring(0, Nr.Length - 1);
            UiText.text = Nr;
        }
    }
}