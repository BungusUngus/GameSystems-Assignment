using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerWallet : MonoBehaviour
{
    public float currentMoney;
    public TextMeshProUGUI moneyLabel;

    // Start is called before the first frame update
    void Start()
    {
        AddMoney(0);
    }
    public void AddMoney(float amount)
    {
        currentMoney += amount;
        moneyLabel.text = "Money" + currentMoney;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
