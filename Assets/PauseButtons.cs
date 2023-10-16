using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;



public class PauseButtons : MonoBehaviour
{
    public static bool GamePauseState = false;

    [SerializeField]  UIDocument buttonDocument;
    Button menuButton;
    [SerializeField] GameObject pauseUI;

    void Start()
    {
        if (buttonDocument == null)
        {
            Debug.LogError("no button doc found");
        }
        pauseUI.SetActive(false);
    }

    public void OnMenuClick(ClickEvent evt)
    {
        Debug.Log("menu has been clicked");
        SceneManager.LoadScene("title screen");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("excp");
            GamePauseState = !GamePauseState;
            pauseUI.SetActive(!pauseUI.activeInHierarchy);
            menuButton = buttonDocument.rootVisualElement.Q("mainmenu") as Button;
            menuButton.RegisterCallback<ClickEvent>(OnMenuClick);
        }
    }
}
