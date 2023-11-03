using System.Collections.Generic;
using UnityEngine;
using Invector.vCharacterController;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSurvialManager : MonoBehaviour
{
    public static PlayerSurvialManager Instance;
    [SerializeField] vThirdPersonMotor characterController;
    [SerializeField] private GameObject sleepingBag;
    [SerializeField] private List<CapsuleCollider> weaponColliders = new List<CapsuleCollider>();
    public bool sleepingBagAcquired;
    [SerializeField] private Slider energySlider;
    public GameObject myPlayer;
    public GameObject restartPanel;

    private void Awake()
    {
      //  myPlayer=GameObject.FindGameObjectWithTag("Player");
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating("EnergyValueChange",5f,5f);
    }
    private void EnergyValueChange()
    {
        if (sleepingBagAcquired)
        {
            energySlider.value -= 3;
        }
        else
        {
            energySlider.value -= 6;
        }

        PlayerDied();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (sleepingBagAcquired)
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
        sleepingBagAcquired = true;
        sleepingBag.SetActive(true);
        WeaponsAcquire(false);
        characterController.strafeSpeed.runningSpeed /= 2;
    }

    void ResetSleepingBag()
    {
        sleepingBagAcquired = false;
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

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    private void PlayerDied()
    {
        if (energySlider.value <= 0)
        {
            myPlayer.SetActive(false);
            restartPanel.SetActive(true);
        }
    }
}
