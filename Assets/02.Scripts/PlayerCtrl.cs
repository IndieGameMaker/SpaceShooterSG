using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float h = 0.0f;
    private float v = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        h = Input.GetAxis("Horizontal"); //Left, Right Arrow, A, D    -1.0f ~ 0.0f ~ +1.0f
        v = Input.GetAxis("Vertical");   //-1.0f ~ 0.0f ~ +1.0f
        //Debug.Log("h=" + h);
        Debug.Log($"h={h} / v={v}");

        //transform.position += new Vector3(0, 0, 0.1f);
        transform.Translate(Vector3.forward * 0.1f * v); //Vector3.forward = new Vector3(0, 0, 1)
    }

    /* 정규화 벡터(Normalized Vector), 단위 벡터(Unit Vector)
        Vector3.forward = Vector3(0, 0, 1)
        Vector3.up      = Vector3(0, 1, 0)
        Vector3.right   = Vector3(1, 0, 0)
        
        Vector3.zero    = Vector3(0, 0, 0)
        Vector3.one     = Vector3(1, 1, 1)
    */

/*    
    // #1 호출, 1회 호출
    // 게임, 콘텐츠 데이터를 초기화
    // 스크립트가 비활성화 상태에도 호출됨. <== *****
    // 모든 스크립트의 Start함수가 호출되기 전에 호출됨
    void Awake()
    {

    }

    // #2 호출, 활성화될때마다 호출
    void OnEnable()
    {

    }

    // #3 호출, 1번 호출
    // 코루틴으로 호출할 수 있음.
    void Start()
    {
        
    }

    // 프레임 마다 호출
    // 렌더링 주기
    // 호출주기 (불규칙적인 호출주기),  60fps 
    void Update()
    {
        
    }

    // 0.02 sec, 규칙호출
    // 물리엔진의 계산주기(시뮬레이션 주기)
    void FixedUpdate()
    {

    }

    // 모든 스크립트의 Update 함수가 끝난후에 호출됨
    void LateUpdate()
    {

    }
*/
}
