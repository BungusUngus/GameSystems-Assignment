using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPContainer : MonoBehaviour
{
    public float expGiven;

    public void GiveExp()
    {
        FindObjectOfType<Experience>().IncreaseXP(expGiven);
    }
}
