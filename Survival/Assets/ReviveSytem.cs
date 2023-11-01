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
        }
        else
        {
            navigator.currentBunkerIndex++;
        }
    }
}
