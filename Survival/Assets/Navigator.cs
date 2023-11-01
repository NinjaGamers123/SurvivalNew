using System;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    public List<GameObject> bunkersList;
    public int currentBunkerIndex;
    public GameObject arrow;
    public GameObject player;

    private void Awake()
    {
        player=GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Vector3 direction = (player.transform.position- bunkersList[currentBunkerIndex].transform
            .position).normalized;
        arrow.transform.LookAt(direction,Vector3.up);
    }

}
