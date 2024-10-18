using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI LevelNumbers;

    public void SetXpBar(int startingXp, int maxXPToLevelUp)
    {
        slider.maxValue = maxXPToLevelUp;
        slider.value = startingXp;
    }


    public void SetLevelText(float CurrentLevel)
    {
        LevelNumbers.text = "Current Level: " + CurrentLevel.ToString();

    }

    /*public void SetMaxHealth(int health)
    {
        slider.maxValue = Xp;
        slider.value = Xp;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int Xp)
    {
        slider.value = Xp;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    */
}
