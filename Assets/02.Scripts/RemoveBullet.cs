using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    //충돌 시점에 1번 호출
    //Collider 컴포넌트의 Is Trigger 언체크
    void OnCollisionEnter(Collision coll)
    {
        //if (coll.gameObject.tag == "BULLET")
        if (coll.gameObject.CompareTag("BULLET"))
        {
            ContactPoint[] points = coll.contacts;
            Vector3 point = points[0].point; //충돌 지점
            Vector3 normal = points[0].normal; //법선벡터 (Normal Vector)

            //Quaterion 쿼터니언 (사원수 x, y, z, w), 각도 단위
            //오일러회전을 할 경우 짐벌락(김벌락 , Gimbal Lock) 현상
            Quaternion rot = Quaternion.LookRotation(normal);

            Instantiate(sparkEffect, point, rot);

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
