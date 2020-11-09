using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterCtrl : MonoBehaviour
{
    public enum STATE
    {
        IDLE,
        TRACE,
        ATTACK,
        DIE
    }

    public STATE state = STATE.IDLE;

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

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTr.position);
    }
}
