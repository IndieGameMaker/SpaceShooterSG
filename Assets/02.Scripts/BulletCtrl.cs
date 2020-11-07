using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * 1000.0f);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
