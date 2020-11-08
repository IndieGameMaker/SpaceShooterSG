using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    //충돌 시점에 1번 호출
    //Collider 컴포넌트의 Is Trigger 언체크
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "BULLET")
        {
            Destroy(coll.gameObject);
        }
    }

/*
    //충돌을 하고 있는 동안 계속 호출
    void OnCollisionStay(Collision coll)
    {}

    //두 물체가 떨어졌을 경우에 1번 호출
    void OnCollisionExit(Collision coll)
    {}
*/


/*
Collider Is Trigger 체크 : 관통하는 성격
OnTriggerEnter
OnTriggerStay
OnTriggerExit

*/
}
