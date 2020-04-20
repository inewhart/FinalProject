using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public GameObject Player;
    public GameObject Dummy;
    float  timeLeft;
    private static Factory _instance; 
    void Awake()
    {
        _instance = this; 
    }
    public void Initialize(GameObject player)
    {
        PlayerGameObject = player;
        PlayerObject = PlayerGameObject.GetComponent<Player>();
    }
    void Start()
    {
        
    }
    public Dummy Dummyspawn() 
    {
    var random = new System.Random();
    var startPositionY = 2; 
    var startPositionX = (float) (random.NextDouble() - 0.5f) * ; 
    var startPositionZ = (float) (random.NextDouble() - 0.5f) * ; 
    var startPosition = new Vector3(startPositionX, startPositionY, startPositionZ); 
    return Create(startPosition); 
}
private Dummy Create(Vector3 startPosition) 
{ 
    var zombieGameObject = Object.Instantiate(_instance.Dummy, startPosition, Quaternion.identity);
    var zombieObject = zombieGameObject.GetComponent<Dummy>(); 
    zombieObject.Initialize(Player); 
    return zombieObject; 
}
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if ( timeLeft < 0 )
        {
            Application.Quit();
        }
    }
}
