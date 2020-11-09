using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    [HideInInspector]
    public Transform playerTr;
    private NavMeshAgent agent;

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
