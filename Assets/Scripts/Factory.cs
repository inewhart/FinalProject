using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Factory : MonoBehaviour
{
    public GameObject Player;
    public GameObject Dummy;
    
    
    private static Factory _instance; 
    void Awake()
    {
        _instance = this; 
    }
    
    void Start()
    {
        
    }
    public Dummy Dummyspawn() 
    {
    var random = new System.Random();
    var startPositionY = 2; 
    var startPositionX = (float) (random.NextDouble() - 38f) * 90; 
    var startPositionZ = (float) (random.NextDouble() - 38f) * 90; 
    var startPosition = new Vector3(startPositionX, startPositionY, startPositionZ); 
    return Create(startPosition); 
}
private Dummy Create(Vector3 startPosition) 
{ 
    var DummyGameObject = Object.Instantiate(_instance.Dummy, startPosition, Quaternion.identity);
    var DummyObject = DummyGameObject.GetComponent<Dummy>(); 
    DummyObject.Initialize(Player); 
    return DummyObject; 
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
