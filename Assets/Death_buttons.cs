using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Death_buttons : MonoBehaviour
{

    [SerializeField] UIDocument buttonDocument;
    Button menuButton;
    [SerializeField] GameObject glow;
    public void OnMenuClick(ClickEvent evt)
    {
        Debug.Log("menu has been clicked");
        SceneManager.LoadScene("title screen");
    }

    // Start is called before the first frame update
    void Start()
    {
        menuButton = buttonDocument.rootVisualElement.Q("menu") as Button;
        menuButton.RegisterCallback<ClickEvent>(OnMenuClick);
        Invoke("delayed", 1.5f);
    }
    void delayed()
    {
        glow.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
