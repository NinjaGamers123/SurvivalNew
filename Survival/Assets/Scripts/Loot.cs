using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private int lootIncreaseAmount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            PlayerSurvialManager.Instance.energySlider.value += lootIncreaseAmount;
            gameObject.SetActive(false);
        }
    }
}
