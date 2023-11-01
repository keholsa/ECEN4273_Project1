using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DevButtons : MonoBehaviour
{

    UIDocument buttonDocument;
    Button Castle_CoutyardButton;
    Button Castle_InteriorButton;
    Button DungeonCombatButton;
    Button DungeonMazeButton;
    Button Level1Button;
    Button lever_puzzleButton;
    Button Main_worldButton;
    Button hiddenButton;

    void OnEnable()
    {
        buttonDocument = GetComponent<UIDocument>();
        Debug.Log("uibutton made");
        if (buttonDocument == null)
        {
            Debug.LogError("no button doc found");
        }
        Castle_CoutyardButton = buttonDocument.rootVisualElement.Q("Castle_Coutyard") as Button;
        Castle_InteriorButton = buttonDocument.rootVisualElement.Q("Castle_Interior") as Button;
        DungeonCombatButton = buttonDocument.rootVisualElement.Q("DungeonCombat") as Button;
        DungeonMazeButton = buttonDocument.rootVisualElement.Q("DungeonMaze") as Button;
        Level1Button = buttonDocument.rootVisualElement.Q("Level1") as Button;
        lever_puzzleButton = buttonDocument.rootVisualElement.Q("lever_puzzle") as Button;
        Main_worldButton = buttonDocument.rootVisualElement.Q("Main_world") as Button;
        //exitButton = buttonDocument.rootVisualElement.Q("exit") as Button;
        hiddenButton = buttonDocument.rootVisualElement.Q("hidden_button") as Button;


        Castle_CoutyardButton.RegisterCallback<ClickEvent>(Castle_CoutyardClick);
        Castle_InteriorButton.RegisterCallback<ClickEvent>(Castle_InteriorClick);
        DungeonCombatButton.RegisterCallback<ClickEvent>(DungeonCombatClick);
        DungeonMazeButton.RegisterCallback<ClickEvent>(DungeonMazeClick);
        Level1Button.RegisterCallback<ClickEvent>(Level1Click);
        lever_puzzleButton.RegisterCallback<ClickEvent>(lever_puzzleClick);
        Main_worldButton.RegisterCallback<ClickEvent>(Main_worldClick);
        //exitButton.RegisterCallback<ClickEvent>(OnExitClick);
        hiddenButton.RegisterCallback<ClickEvent>(CreditsClick);
    }

    public void CreditsClick(ClickEvent evt)
    {
        Debug.Log("credits has been clicked");
        SceneManager.LoadScene("Game_Over");
        Time.timeScale = 1f;
    }

    public void Castle_CoutyardClick(ClickEvent evt)
    {
        //Debug.Log("start has been clicked");
        SceneManager.LoadScene("CastleCourtyardCombat");
        Time.timeScale = 1f;
    }

    public void Castle_InteriorClick(ClickEvent evt)
    {
        //Debug.Log("start has been clicked");
        SceneManager.LoadScene("CastleInteriorCombat");
        Time.timeScale = 1f;
    }
    public void DungeonCombatClick(ClickEvent evt)
    {
        //Debug.Log("start has been clicked");
        SceneManager.LoadScene("DungeonCombat");
        Time.timeScale = 1f;
    }
    public void DungeonMazeClick(ClickEvent evt)
    {
        //Debug.Log("start has been clicked");
        SceneManager.LoadScene("DungeonMaze");
        Time.timeScale = 1f;
    }
    public void Level1Click(ClickEvent evt)
    {
        //Debug.Log("start has been clicked");
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }
    public void lever_puzzleClick(ClickEvent evt)
    {
        //Debug.Log("start has been clicked");
        SceneManager.LoadScene("lever_puzzle");
        Time.timeScale = 1f;
    }
    public void Main_worldClick(ClickEvent evt)
    {
        //Debug.Log("start has been clicked");
        SceneManager.LoadScene("MainWorldCombat");
        Time.timeScale = 1f;
    }



    /*
    public void OnExitClick(ClickEvent evt)
    {
        Debug.Log("Exit has been clicked");
        Application.Quit();
    }
    */
}
