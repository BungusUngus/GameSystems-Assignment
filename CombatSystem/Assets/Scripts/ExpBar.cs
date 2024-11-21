using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    [SerializeField] private Experience player;
    [SerializeField] private Gradient gradient;

    private Image expBar;

    private void Start()
    {
        expBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        expBar.fillAmount = player.GetExperiencePercent();
        expBar.color = gradient.Evaluate(player.GetExperiencePercent());
    }
}
