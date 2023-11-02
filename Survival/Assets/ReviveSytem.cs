using UnityEngine;

public class ReviveSytem : MonoBehaviour
{
    public Navigator navigator;
    private void OnCollisionEnter(Collision other)
    {
        if (!other.transform.CompareTag("Player")) return;
        if (navigator.currentBunkerIndex==navigator.bunkersList.Count-1)
        {
            navigator.currentBunkerIndex=0;
            navigator.bunkersList[navigator.currentBunkerIndex].GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            navigator.currentBunkerIndex++;
            for (int i = 0; i <   navigator.bunkersList.Count; i++)
            {
                navigator.bunkersList[i].GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
