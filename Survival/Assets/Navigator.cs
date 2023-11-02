using System;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    public List<GameObject> bunkersList;
    public int currentBunkerIndex;
    public GameObject player;

    private void Awake()
    {
        player=GameObject.FindWithTag("Player");
    }

    void Update()
    {
        var targetPos = bunkersList[currentBunkerIndex].transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
    }

}
