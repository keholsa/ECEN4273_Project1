using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to transition to.
    public LayerMask interactableLayer; // The layer for the objects you want to interact with.
    private bool isInteracting = false;

    void Update()
    {
        if (isInteracting)
        {
            // Check if the "E" key is pressed.
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Load the new scene.
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & interactableLayer) != 0)
        {
            isInteracting = true;
            Debug.Log("Press 'E' to interact.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & interactableLayer) != 0)
        {
            isInteracting = false;
            Debug.Log("No longer interacting.");
        }
    }
}
