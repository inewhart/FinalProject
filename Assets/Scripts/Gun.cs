using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public int total ammo = 36;
    public int maxAmmo = 6;
    private int currAmmo;
    public float reloadTime = 1f;
    public Camera PlayerCam;
    void Start()
    {
        currAmmo = maxAmmo;
    }
    IEnumerator reload()
    {
        
    } 
    void Update()
    {
        if(currAmmo <= 0)
        {
            reload();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            
        }

    }
    void Shoot()
    {
        currAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(PlayerCam.transform.position,PlayerCam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            Dummy dummy = hit.transform.GetComponent<Dummy>();
            if(dummy != null)
            {
                dummy.DummyHit();
            }
        }
    }
}
