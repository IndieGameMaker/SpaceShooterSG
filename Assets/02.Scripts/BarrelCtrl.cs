using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;
    private int hitCount;

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

    }

}
