using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{

    [SerializeField] private float XP;
    //The players current maximum xp 
    public float MaxXP;
    //The players current level
    public int LevelCurrent;

    [SerializeField] GameObject levelUpgrades;

    public void IncreaseXP(float amount)
    {

        XP += amount; 
        if (XP >= MaxXP)
        {
            LevelCurrent += 1;
            XP -= MaxXP;
            levelUpgrades.SetActive(true);
        }
    }


    public float GetExperiencePercent()
    {
        return XP / MaxXP;
    }
}
