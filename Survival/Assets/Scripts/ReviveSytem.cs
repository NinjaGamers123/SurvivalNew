using UnityEngine;

public class ReviveSytem : MonoBehaviour
{
    public Navigator navigator;
    private void OnCollisionEnter(Collision other)
    {
        if (!other.transform.CompareTag("Player")) return;
        PlayerPrefs.SetFloat("PlayerX",transform.position.x);
        PlayerPrefs.SetFloat("PlayerY",transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ",transform.position.z);
        if (navigator.currentBunkerIndex==navigator.bunkersList.Count-1)
        {
            navigator.currentBunkerIndex=0;
            for (int i = 0; i <   navigator.bunkersList.Count; i++)
            {
                navigator.bunkersList[i].GetComponent<BoxCollider>().enabled = true;
            }
        }
        else
        {
            navigator.bunkersList[navigator.currentBunkerIndex].GetComponent<BoxCollider>().enabled = false;
            navigator.currentBunkerIndex++;
            navigator.bunkersList[navigator.currentBunkerIndex].GetComponent<BoxCollider>().enabled = true;
           
        }
    }
}
