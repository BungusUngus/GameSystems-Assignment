using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Experience player;
    [SerializeField] private Gradient gradient;

    [SerializeField] private TextMeshProUGUI levelLabel;
    private Image expBar;

    private void Start()
    {
        expBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        levelLabel.text = "LEVEL\n" + player.LevelCurrent;
        expBar.fillAmount = player.GetExperiencePercent();
        expBar.color = gradient.Evaluate(player.GetExperiencePercent());
    }
}
