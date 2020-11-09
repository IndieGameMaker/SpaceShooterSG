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
    private Animator anim;

    private NavMeshAgent agent;
    public bool isDie = false;
    private int hashIsAttack = Animator.StringToHash("isAttack");
    private int hashHit = Animator.StringToHash("Hit");
    private int hashDie = Animator.StringToHash("Die");

    public float hp = 100.0f;

    void Start()
    {
        monsterTr = GetComponent<Transform>();
        anim      = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("PLAYER");
        if (player != null)
        {
            playerTr = player.GetComponent<Transform>();
        }

        agent = GetComponent<NavMeshAgent>();

        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    //몬스터의 상태를 체크하는 코루틴
    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            //몬스터와 주인공 간의 거리를 계산
            float dist = Vector3.Distance(playerTr.position, monsterTr.position);
            if (dist <= attacDist) //공격사정거리 이내의 거리
            {
                state = STATE.ATTACK;
            }
            else if (dist <= traceDist) //추적사정거리 이내
            {
                state = STATE.TRACE;
            }
            else
            {
                state = STATE.IDLE;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }


    //몬스터의 상태에 따라서 행동을 처리하는 코루틴
    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (state)
            {
                case STATE.IDLE: 
                    agent.isStopped = true;
                    anim.SetBool("isTrace", false);
                    break;

                case STATE.TRACE: 
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;
                    anim.SetBool("isTrace", true);
                    anim.SetBool(hashIsAttack, false);
                    break;

                case STATE.ATTACK: 
                    // Hashtable
                    // Key , Value
                    anim.SetBool(hashIsAttack, true);
                    break;

                case STATE.DIE: break;                            
            }

            yield return new WaitForSeconds(0.2f);
        }
    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);
            anim.SetTrigger(hashHit);

            hp -= 20.0f;
            if (hp <= 0.0f)
            {
                MonsterDie();
            }
        }
    }

    void MonsterDie()
    {
        Debug.Log("Monster Die !!!");
        anim.SetTrigger(hashDie);

        StopAllCoroutines();
        agent.isStopped = true;
    }
}
