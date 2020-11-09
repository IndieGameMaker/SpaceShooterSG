using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform[] points;
    
    void Start()
    {
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        monsterPrefab = Resources.Load<GameObject>("monster");
        //monsterPrefab = Resources.Load("monster") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
