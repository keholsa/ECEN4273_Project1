using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : MonoBehaviour
{
    public TileCoordinates tileCoordinates;
    public float rotationSpeed = 90.0f; // The speed at which the tiles rotate.
    private bool isRotating = false; // To prevent multiple rotations.
    // public Gate gate;

    private static List<TileCoordinates> inputCode = new List<TileCoordinates>
    {
        new TileCoordinates(-28, 5, 0),
        new TileCoordinates(-25, 5, 0),
        new TileCoordinates(-10, 5, 0),
        new TileCoordinates(-7, 5, 0)
    };
    private static List<TileCoordinates> enteredCode = new List<TileCoordinates>();

    public LayerMask leverLayer; // Specify the layer for levers in the Inspector.

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isRotating) // Left mouse button and not already rotating
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, leverLayer); // Use the leverLayer mask

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (enteredCode.Count < inputCode.Count)
                {
                    enteredCode.Add(tileCoordinates);
                    CheckCode();
                }
                RotateTile();
            }
        }
    }

    private void RotateTile()
    {
        // Rotate the tile by 90 degrees along the Z-axis (assuming 2D rotation).
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void CheckCode()
    {
        if (enteredCode.Count == inputCode.Count)
        {
            bool correctCode = true;

            for (int i = 0; i < inputCode.Count; i++)
            {
                if (!enteredCode[i].Equals(inputCode[i]))
                {
                    correctCode = false;
                    break;
                }
            }

            if (correctCode)
            {
                // gate.OpenGate();
                // Clear the enteredCode list for the next attempt.

                Debug.Log("correct code");
                enteredCode.Clear();
            }
            else
            {
                // Incorrect code, so clear the entered code and start over.
                enteredCode.Clear();

                Debug.Log("incorrect code");
            }
        }
    }

    [System.Serializable]
public class TileCoordinates
{
    public int x;
    public int y;
    public int z;

    public TileCoordinates(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public bool Equals(TileCoordinates other)
    {
        return this.x == other.x && this.y == other.y && this.z == other.z;
    }
} 
}
