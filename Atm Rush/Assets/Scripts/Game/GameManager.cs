using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public GameObject moneyCounter;

    private int _moneyCounter;
    private int _totalMoney;
    private int _moneyInAtm;
    private int _multiplier;


    public int MoneyCounter { get => _moneyCounter; set => _moneyCounter = value; }
    public int TotalMoney { get => _totalMoney; set => _totalMoney = value; }
    public int MoneyInAtm { get => _moneyInAtm; set => _moneyInAtm = value; }
    public int Multiplier { get => _multiplier; set => _multiplier = value; }

    private void Start()
    {
        TotalMoney = PlayerPrefs.GetInt("Money");
        MoneyCounter = -1;
        MoneyInAtm = 0;
    }

    public void UpdateMoneyCounterText()
    {
        MoneyCounter += 1;
        moneyCounter.GetComponent<TextMesh>().text = MoneyCounter.ToString();
    }
}
