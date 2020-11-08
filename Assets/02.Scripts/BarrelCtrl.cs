using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;
    private int hitCount;

    [SerializeField]
    private MeshRenderer renderer;

    void Start()
    {
        renderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        //AddComponent
        Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1500.0f);
        Destroy(this.gameObject, 2.0f);

        //폭발효과
        // Random.Range(0, 10)       0 ~ 9
        // Random.Range(0.0f, 10.0f) 0.0f ~ 10.0f
        Quaternion rot = Quaternion.Euler(0, Random.Range(0, 360), 0);
        var effect = Instantiate(expEffect, this.transform.position, rot);
        Destroy(effect, 5.2f);
    }

}
