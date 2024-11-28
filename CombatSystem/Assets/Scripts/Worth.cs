using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worth : MonoBehaviour
{
    public float worth;

    public void AddToWallet()
    {
        FindObjectOfType<PlayerWallet>().AddMoney(worth);
    }
   
}
