using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Level : MonoBehaviour
{
    private Rigidbody2D rd;
    public float Xvelocity, speed ;

     void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        speed = PlayerPrefs.GetInt("Hero speed");

    }
    
}
