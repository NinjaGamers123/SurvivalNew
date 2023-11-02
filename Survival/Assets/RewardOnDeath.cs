using Polyperfect.Common;
using UnityEngine;
using UnityEngine.AI;

public class RewardOnDeath : MonoBehaviour
{

    public void Dead()
    {
        GetComponent<Animator>().SetBool("isDead",true);
        GetComponent<Common_WanderScript>().CurrentState = Common_WanderScript.WanderState.Dead;
        GetComponent<NavMeshAgent>().enabled = false;
        GameRewards.instance.SpawnReward(this.gameObject);
        Destroy(gameObject, 1.5f);
        print("dead");
    }
}
