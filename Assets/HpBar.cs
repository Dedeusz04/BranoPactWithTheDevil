using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth;
    private float MaxHealth = 100f;
    public bool mg;
    public bool mgmele;
    public cel Bot;
    public cel2 Bot2;
    public graczhp Player;


    // Start is called before the first frame update
    private void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<graczhp>();
        Bot = FindObjectOfType<cel>();
        Bot2 = FindObjectOfType<cel2>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (mg)
        {
            CurrentHealth = Player.zycie;
            HealthBar.fillAmount = CurrentHealth / MaxHealth;
        }
        if (!mg)
        {
            CurrentHealth = Bot.zycie;
            HealthBar.fillAmount = CurrentHealth / MaxHealth;
        }
        if (mgmele)
        {
            CurrentHealth = Bot2.zycie;
            HealthBar.fillAmount = CurrentHealth / MaxHealth;
        }
    }
}