using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public Text Timer;
    public float Health;
    public float timeLeft = 300f;
    public Text HealthText;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
    }
    
    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health Remaining: " + Health;
        Timer.text = "Time Remaining Til Evac: " + timeLeft;
        timeLeft -= Time.deltaTime;
        if ( timeLeft < 0 )
        {
            Application.Quit();
        }
    }
}
