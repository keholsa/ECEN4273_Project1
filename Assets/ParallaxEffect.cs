using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;

    // Start pos for parallax
    Vector2 startingPos;

    // Start Z
    float startingZ;

    Vector2 camMoveStart => (Vector2) cam.transform.position - startingPos;

    float zDistfromTarget => followTarget.position.z - transform.position.z;

    float clippingPlane => (cam.transform.position.z + (zDistfromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));

    float parallaxFactor => Mathf.Abs(zDistfromTarget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = startingPos + camMoveStart * parallaxFactor;

        transform.position = new Vector3(newPos.x, newPos.y, startingZ);
    }
}
