using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameRewards : MonoBehaviour
{
    public List<GameObject> rewardsList;

    public static GameRewards instance;

    private void Awake()
    {
        instance = this;
    }

    public void SpawnReward(GameObject parent)
    {
        Instantiate(rewardsList[Random.Range(0, rewardsList.Count)], parent.transform.position,Quaternion.identity);
    }
}
