using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    [SerializeField] GameObject levelUpMenu;

    [SerializeField] int HealingAmount = 20;

    [SerializeField] int CurrentXp = 0;
    [SerializeField] int NextLvl = 20;
    [SerializeField] GameObject Player1;
    [SerializeField] XpBar xpBar;
    public int PlayerLevel = 0;

    //[SerializeField] GameObject HpPotionz;
    [SerializeField] Player player;
    //[SerializeField] Player MaxHealth;

    [SerializeField] TextMeshPro HealthChangeIndicator;

    //??
    private void Update()
    {
        xpBar.SetLevelText(PlayerLevel);
    }

    void OnTriggerEnter2D(Collider2D collision2D)
    {

        //Debug.Log(this.gameObject.tag);

        if (collision2D.gameObject.CompareTag("XpConsume"))
        {
            Debug.Log("XpSuccess");
            XpGained();
            Destroy(collision2D.gameObject);

        }


        if (collision2D.gameObject.CompareTag("HpPotionz"))
        {
            Debug.Log("HealthRestoredSuccess");

            HpGained();
            Destroy(collision2D.gameObject);

        }

    }

    public void XpGained()
    {
        CurrentXp++;
        xpBar.SetXpBar(CurrentXp, NextLvl);
        Debug.Log("Your Xp is: " + CurrentXp);
        if (CurrentXp == NextLvl)
        {
            LevelUp();

        }
    }


    public void LevelUp()
    {
        Debug.Log("You Gained a Lvl!");
        if (Player1.TryGetComponent(out Player t))
        {
            levelUpMenu.SetActive(true);

            CurrentXp = 0;
            PlayerLevel++;
        }

    }


    public void HpGained()
    {

        //xpBar.SetXpBar(CurrentXp, NextLvl);
        //Debug.Log("Your Xp is: " + CurrentXp);
        if (player.Health < player.MaxHealth)
        {

            float missingHealth= player.MaxHealth - player.Health ;
          

            if (HealingAmount > missingHealth)
            {
                float hpToHeal = missingHealth;
                player.Health += hpToHeal;
                StartCoroutine(showIndicator(0.3f, hpToHeal));
            }
            else
            {
                player.Health += HealingAmount;
                StartCoroutine(showIndicator(0.3f, HealingAmount));
               

            }

            //player.Health += 20;
            //if (player.Health >= player.MaxHealth)
            //{
            //    player.Health = player.MaxHealth;
            //}

        }
    }

    IEnumerator showIndicator(float amount, float num)
    {
        HealthChangeIndicator.text = "+ " + num.ToString();
        HealthChangeIndicator.color = Color.green;
        yield return new WaitForSeconds(amount);
        HealthChangeIndicator.text = "";
        HealthChangeIndicator.color = Color.white;
    }

    /* Start is called before the first frame update
    void Start()
    {
       

       
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    */

}
