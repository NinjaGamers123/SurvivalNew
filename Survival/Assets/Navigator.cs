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
        if (player)
        {
            player.transform.position = new Vector3(PlayerPrefs.GetFloat("PlayerX"),PlayerPrefs.GetFloat("PlayerY"),PlayerPrefs.GetFloat("PlayerZ"));
        }
        OffAllColliders();
        
    }

    private void OffAllColliders()
    {
        for (int i = 0; i < bunkersList.Count; i++)
        {
            bunkersList[i].GetComponent<BoxCollider>().enabled = false;
        }

        bunkersList[currentBunkerIndex].GetComponent<BoxCollider>().enabled = true;
    }

    void Update()
    {
        var targetPos = bunkersList[currentBunkerIndex].transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);
    }

}
