using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;

    public AudioSource audio;
    public AudioClip fireSfx;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audio.PlayOneShot(fireSfx, 0.8f);
            // audio.clip = fireSfx;
            // audio.Play();
            //(생성할 객체, 위치, 회전)
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
