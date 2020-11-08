using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;

    public AudioSource audio;
    public AudioClip fireSfx;

    public Renderer muzzleFlash;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    
    void Fire()
    {
        audio.PlayOneShot(fireSfx, 0.8f);
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        StartCoroutine(ShowMuzzleFlash());
    }

    //코루틴 (서브 루틴) 
    IEnumerator ShowMuzzleFlash()
    {
        muzzleFlash.enabled = true;
        
        yield return new WaitForSeconds(0.3f);
        
        muzzleFlash.enabled = false;
    }
    
}
