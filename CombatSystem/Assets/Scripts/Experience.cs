using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    //
    [SerializeField] private float XP;
    public float MaxXP;

    public void IncreaseXP(float amount)
    {
        XP += amount;
    }


    public float GetExperiencePercent()
    {
        return XP / MaxXP;
    }
}
