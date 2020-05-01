using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

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
        if(Health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        Timer.text = "Time Remaining Til Evac: " + timeLeft;
        timeLeft -= Time.deltaTime;
        if ( timeLeft <= 0 )
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
