using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class LevelUpgrades : MonoBehaviour
{
    [SerializeField] string[] levelUpUpgrades;
    [SerializeField] private TextMeshProUGUI upgradeText;
    private float timeLimit;

    // Start is called before the first frame update
    void Start()
    {
      this.gameObject.SetActive(false);  
    }

    private void Update()
    {
        timeLimit -= Time.deltaTime;
        if (timeLimit <= 0)
        {
            this.gameObject.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        timeLimit = 2;
        int randomNumber = Random.Range(0, 5);
        upgradeText.text = levelUpUpgrades[randomNumber];
    }
}
