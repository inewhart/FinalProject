using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public int maxAmmo = 6;
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
        ammoCount.text = "Current Ammo: " + currAmmo;
        if(currAmmo <= 0)
        {
            reloadAnnouncement.gameObject.SetActive(true);
            Reload();
            reloadAnnouncement.gameObject.SetActive(false);
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    IEnumerator Reload()
    {
        reloading = true;

        yield return new WaitForSeconds(reloadTime);
        currAmmo = maxAmmo;
    }
    private void Shoot()
    {
        Debug.Log("Help");
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
