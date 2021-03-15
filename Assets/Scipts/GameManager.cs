using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text moneyText;

    //gamemanager is basically just tracking money
    //just made some save stuff and some singleton stuff
    private const string PREF_KEY_MONEY = "moneyKey";
    private int money=0;

    public int Money
    {
        get
        {
            if (money == 0)
            {
                money = PlayerPrefs.GetInt(PREF_KEY_MONEY, 1);
            }
            return money;
        }
        set
        {
            money = value; 
            PlayerPrefs.SetInt(PREF_KEY_MONEY, money);
        }
    }
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //money text being set to money to show player what they have
    private void Update()
    {
        moneyText.text = Money + "";
    }
}
