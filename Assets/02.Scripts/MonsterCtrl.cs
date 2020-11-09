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
    public float traceDist = 10.0f; //추적사정 거리
    public float attacDist = 2.0f;  //공격사정 거리

    [HideInInspector]
    public Transform playerTr;
    private Transform monsterTr;

    private NavMeshAgent agent;

    void Start()
    {
        monsterTr = GetComponent<Transform>();
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
