using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
  
    [SerializeField] TextMeshProUGUI currentLevel;
    [SerializeField] TextMeshProUGUI KillCounter;
    [SerializeField] TextMeshProUGUI maxHealthValueLabel;
    [SerializeField] TextMeshProUGUI MovementSpeed;
    [SerializeField] TextMeshProUGUI SwordDamage;
    [SerializeField] TextMeshProUGUI BowAttackSpeed;
    [SerializeField] TextMeshProUGUI BowDamage;
    [SerializeField] TextMeshProUGUI AxeDamage;
    [SerializeField] TextMeshProUGUI AxeOrbitSpeed;
  


    [SerializeField] WeaponSword Sword;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] UpgradeManager upgradeManager;
    [SerializeField] WeaponBow Bow;
    [SerializeField] ArrowHead Arrow;
    [SerializeField] WeaponOrbitAxe Axe;


    private void OnEnable()
    {
        SetCharacterPanelStats();
    }

    void SetCharacterPanelStats()
    {
   
        currentLevel.text = Mathf.CeilToInt(upgradeManager.PlayerLevel).ToString();
        KillCounter.text = Mathf.CeilToInt(enemyManager.EnemyKills).ToString();
        maxHealthValueLabel.text = Mathf.CeilToInt(GamesManager.Instance.player.MaxHealth).ToString();
        MovementSpeed.text = (GamesManager.Instance.player.MoveSpeed).ToString();
        SwordDamage.text = Mathf.CeilToInt(Sword.damageAmount).ToString();
        BowAttackSpeed.text = Mathf.CeilToInt(Bow.ArrowSpeed).ToString();
        BowDamage.text = Mathf.CeilToInt(Arrow.damageAmount + Bow.DamageIncrease).ToString();
        AxeDamage.text = Mathf.CeilToInt(Axe.damageAmount).ToString();
        AxeOrbitSpeed.text = Mathf.CeilToInt(GamesManager.Instance.player.Orbitspeed).ToString();

    }

}
