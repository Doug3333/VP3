using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] Player  myPlayer;
    [SerializeField] GameObject levelUpMenu;

    public void OnClickUpgradeSpeed()
    {
        myPlayer.SpeedUpgrade();
        levelUpMenu.SetActive(false);
    }

    public void OnClickUpgradeHealth()
    {
        myPlayer.IncresseMaxHealth();
        levelUpMenu.SetActive(false);
    }

}
