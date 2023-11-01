using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class keys : MonoBehaviour
{
    [SerializeField] RawImage left_img;
    [SerializeField] RawImage right_img;
    [SerializeField] RawImage middle_img;
    public static Boolean left_key = false;
    public static Boolean right_key = false;
    public static Boolean middle_key = false;
    // Start is called before the first frame update
    void Start()
    {
        left_img.enabled = false;
        right_img.enabled = false;
        middle_img.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (left_key)
        {
            left_img.enabled = true;
        }
        if (right_key) 
        {
            right_img.enabled = true;
        }
        if (middle_key)
        {
            middle_img.enabled = true;
        }    
    }
}
