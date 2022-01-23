using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuPanel, inGamePanel, endGamePanel;
    public Text inGameTotalMoneyText, endGameTotalMoneyText, endGameMultiplierText, endGameEarnedMoneyText;

    private GameObject currentPanel;


    private void Start()
    {
        currentPanel = mainMenuPanel;
    }



    #region Buttons
    public void StartGame()
    {
        StateManager.Instance.state = State.InGame;
        PanelChange(currentPanel, inGamePanel);
        EventManager.Instance.InGame();
    }
    public void NextLevelButton()
    {
        //LevelManager.Instance.ChangeLevel("LEVEL " + LevelManager.Instance.CurrentLevel);
    }
    #endregion


    #region Panels
    public void EndGame()
    {
        PanelChange(currentPanel, endGamePanel);
    }
    public void InGame()
    {
        PanelChange(currentPanel, inGamePanel);
    }
    public void PanelChange(GameObject closePanel, GameObject openPanel)
    {
        closePanel.SetActive(false);
        openPanel.SetActive(true);
        currentPanel = openPanel;
    }
    #endregion


    #region Score Functions
    public void EndGameScoreUpdate()
    {
        endGameEarnedMoneyText.text = GameManager.Instance.MoneyCounter.ToString();
        endGameMultiplierText.text = GameManager.Instance.Multiplier.ToString();
        endGameTotalMoneyText.text = (GameManager.Instance.MoneyCounter * GameManager.Instance.Multiplier).ToString();
    }
    #endregion

}
