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


    public int MoneyCounter { get => _moneyCounter; set => _moneyCounter = value; }
    public int TotalMoney { get => _totalMoney; set => _totalMoney = value; }
    public int MoneyInAtm { get => _moneyInAtm; set => _moneyInAtm = value; }

    private void Start()
    {
        TotalMoney = PlayerPrefs.GetInt("Money");
        MoneyCounter = 34;
        MoneyInAtm = 0;
        UpdateMoneyCounterText();
    }

    public void UpdateMoneyCounterText()
    {
        MoneyCounter += 1;
        moneyCounter.GetComponent<TextMesh>().text = MoneyCounter.ToString();
    }
}
