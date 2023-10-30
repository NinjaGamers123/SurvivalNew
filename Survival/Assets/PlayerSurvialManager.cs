using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;

public class PlayerSurvialManager : MonoBehaviour
{
    [SerializeField] vThirdPersonMotor characterController;
    [SerializeField] public GameObject sleepingBag;
    [SerializeField] private List<CapsuleCollider> weaponColliders = new List<CapsuleCollider>();
    private bool acquired;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (acquired)
            {
                ResetSleepingBag();
            }
            else
            {
                EquipedSleepingBag();
            }
        }
    }

    void EquipedSleepingBag()
    {
        acquired = true;
        sleepingBag.SetActive(true);
        WeaponsAcquire(false);
        characterController.strafeSpeed.runningSpeed /= 2;
    }

    void ResetSleepingBag()
    {
        acquired = false;
        sleepingBag.SetActive(false);
        WeaponsAcquire(true);
        characterController.strafeSpeed.runningSpeed *= 2;
    }

    void WeaponsAcquire(bool action)
    {
        if (weaponColliders.Count > 0)
        {
            foreach (var weapon in weaponColliders)
            {
                weapon.enabled = action;
            }
        }
    }

    public void OnWeaponAcquired(CapsuleCollider weapon)
    {
        weaponColliders.Remove(weapon);
    }
}
