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
    Button giveupButton;
    RadioButton left_button;
    RadioButton middle_button;
    RadioButton right_button;
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
        //Time.timeScale = 1f; //doesnt work put else where
        GamePauseState = false;
    }
    public void OnGiveupClick(ClickEvent evt)
    {
        Debug.Log("giveup has been clicked");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game_Over");
        //Time.timeScale = 1f; //doesnt work put else where
        GamePauseState = false;
    }
    public void leftkey_click(ClickEvent evt)
    {
        keys.left_key = true;
       // Debug.Log("radio button pressed");
    }
    public void middlekey_click(ClickEvent evt)
    {
        keys.middle_key = true;
       // Debug.Log("radio button pressed");
    }
    public void rightkey_click(ClickEvent evt)
    {
        keys.right_key = true;
        //Debug.Log("radio button pressed");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("excp"); //pause button pressed
            GamePauseState = !GamePauseState;
            pauseUI.SetActive(!pauseUI.activeInHierarchy);

            if (GamePauseState )
            {
                Time.timeScale = 0; //no movement
                menuButton = buttonDocument.rootVisualElement.Q("mainmenu") as Button;  //on screen buttons
                menuButton.RegisterCallback<ClickEvent>(OnMenuClick);

                giveupButton = buttonDocument.rootVisualElement.Q("giveup") as Button;  //on screen buttons
                giveupButton.RegisterCallback<ClickEvent>(OnGiveupClick);
                left_button = buttonDocument.rootVisualElement.Q("left_button") as RadioButton;  //on screen buttons
                left_button.RegisterCallback<ClickEvent>(leftkey_click);
                middle_button = buttonDocument.rootVisualElement.Q("middle_button") as RadioButton;  //on screen buttons
                middle_button.RegisterCallback<ClickEvent>(middlekey_click);
                right_button = buttonDocument.rootVisualElement.Q("right_button") as RadioButton;  //on screen buttons
                right_button.RegisterCallback<ClickEvent>(rightkey_click);

            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}
