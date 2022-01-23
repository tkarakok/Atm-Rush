using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void StateAciton();
    public StateAciton MainMenu;
    public StateAciton InGame;
    public StateAciton EndGame;


    public delegate void InGameAction();
    public InGameAction CollectMoney;

    public delegate void EndGameAction();
    public EndGameAction StackAction;

    private void Awake()
    {
        MainMenu += SubscribeAllEvent;
        MainMenu();
    }

    void SubscribeAllEvent()
    {
        InGame += () => MovementController.Instance.animator.SetBool("Run",true);
        InGame += () => UIManager.Instance.inGameTotalMoneyText.text = GameManager.Instance.TotalMoney.ToString();
        InGame += GameManager.Instance.UpdateMoneyCounterText;
        InGame += UIManager.Instance.InGame;

        
        
        EndGame += UIManager.Instance.EndGameScoreUpdate;
        EndGame += UIManager.Instance.EndGame;


        StackAction += () => MovementController.Instance.animator.SetBool("Win", true);
        StackAction += Stack.Instance.StartStacks;

        CollectMoney += GameManager.Instance.UpdateMoneyCounterText;
        CollectMoney += MovementController.Instance.StartWaveMoney;
    }


    

}
