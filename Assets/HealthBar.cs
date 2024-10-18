using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI HpNumbers;
    
    public void SetMaxHealth(float health, float MaxHealth)
    {

        slider.maxValue = MaxHealth;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealthText(float health, float MaxHealth)
    {
        HpNumbers.text = health.ToString() + " / " + MaxHealth.ToString();

    }

    

    public void SetHealth(int health)
    {
        //Debug.Log(this.gameObject.name);
         slider.value = health;

         fill.color =gradient.Evaluate(slider.normalizedValue);
    }
}
