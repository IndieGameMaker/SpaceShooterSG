using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    public Transform playerTr;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PLAYER");
        if (player != null)
        {
            playerTr = player.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
