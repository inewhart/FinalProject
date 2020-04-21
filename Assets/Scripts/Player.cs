using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public Text Timer;
    public float timeLeft = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Timer.text = "Time Remaining Til Evac: " + timeLeft;
        timeLeft -= Time.deltaTime;
        if ( timeLeft < 0 )
        {
            Application.Quit();
        }
    }
}
