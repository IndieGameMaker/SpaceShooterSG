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

    private RaycastHit hit;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(firePos.position, firePos.forward * 10.0f, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            if (Physics.Raycast(firePos.position, firePos.forward, out hit, 10.0f, 1<<8)) //2^8 = 256
            {
                Debug.Log(hit.collider.name);
            }
        }
    }
    
    void Fire()
    {
        audio.PlayOneShot(fireSfx, 0.8f);
        //Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        StartCoroutine(ShowMuzzleFlash());
    }

    //코루틴 (서브 루틴) 
    IEnumerator ShowMuzzleFlash()
    {
        //텍스처의 오프셋 값을 변경
        // (0.0 ~ 0.5)
        Vector2 offset = new Vector2(Random.Range(0,2), Random.Range(0,2)) * 0.5f;
        muzzleFlash.material.mainTextureOffset = offset;
        //muzzleFlash.material.SetTextureOffset("_MainTex", offset);

        //MuzzleFlash 크기를 변경
        muzzleFlash.transform.localScale = Vector3.one * Random.Range(1.0f, 3.0f);

        muzzleFlash.enabled = true;
        
        yield return new WaitForSeconds(0.3f);
        
        muzzleFlash.enabled = false;
    }
    
}
