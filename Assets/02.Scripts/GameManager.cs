using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] points;
    public float createTime = 3.0f;
    
    void Start()
    {
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        monsterPrefab = Resources.Load<GameObject>("monster");
        //monsterPrefab = Resources.Load("monster") as GameObject;
        InvokeRepeating("CreateMonster", 1.0f, createTime);
    }

    void CreateMonster()
    {
        int idx = UnityEngine.Random.Range(1, points.Length);
        GameObject monster = Instantiate<GameObject>(monsterPrefab);
        monster.name = "Monster";
        monster.transform.position = points[idx].position;
        monster.transform.rotation = Quaternion.LookRotation(points[0].position - points[idx].position);
    }
}
