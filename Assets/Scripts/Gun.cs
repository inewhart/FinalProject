using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    private int maxAmmo = 6;
    private int currAmmo;
    public float reloadTime = 1f;
    public Text ammoCount;
    public Text reloadAnnouncement;
    public Camera PlayerCam;
    public bool reloading = false;
    void Start()
    {
        currAmmo = maxAmmo;
    }
    void Update()
    {
        // Debug.Log(reloading);
        ammoCount.text = "Current Ammo: " + currAmmo;
        if(currAmmo <= 0 && reloading == false)
        {
            StartCoroutine("Reload");
        }
        if (Input.GetButtonDown("Fire1") && reloading == false)
        {
            Shoot();
        }
    }
    IEnumerator Reload()
    {
        reloading = true;
        reloadAnnouncement.gameObject.SetActive(true);
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
        currAmmo = maxAmmo;
        reloadAnnouncement.gameObject.SetActive(false);
    }
    private void Shoot()
    {
        Debug.Log("Help" + gameObject.name);
        currAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(PlayerCam.transform.position,PlayerCam.transform.forward,out hit,range))
        {
            Dummy dummy = hit.transform.GetComponent<Dummy>();
            if(dummy != null)
            {
                dummy.DummyHit();
            }
        }
    }
}

