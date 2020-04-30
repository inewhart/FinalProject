using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Factory : MonoBehaviour
{
    public GameObject Player;
    public Player player;
    public GameObject Dummy;
    private static float SpawnTime = 10.0f;
    public float Timer;
    
    
    private static Factory _instance; 
    void Awake()
    {
        _instance = this; 
    }
    
    void Start()
    {
        InvokeRepeating("Dummyspawn",0f,2.0f);
    }
    public Dummy Dummyspawn() 
    {
    var random = new System.Random();
    var startPositionY = 2; 
    var startPositionX = (float) (random.Next(40, 80)); 
    var startPositionZ = (float) (random.Next(40, 80));
    var startPosition = new Vector3(startPositionX, startPositionY, startPositionZ); 
    Debug.Log("x " + startPositionX +","+" z " +startPositionZ);
    return Create(startPosition); 
    
}
private Dummy Create(Vector3 startPosition) 
{ 
    var DummyGameObject = Object.Instantiate(_instance.Dummy, startPosition, Quaternion.identity);
    var DummyObject = DummyGameObject.GetComponent<Dummy>(); 
    DummyObject.Initialize(Player); 
    return DummyObject; 
}
}
