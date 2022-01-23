using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FinishController : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private GameObject finishAtm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Money"))
        {
            other.transform.SetParent(null);
            other.transform.DOMoveX(finishAtm.transform.position.x, .5f).OnComplete(() => Destroy(other.gameObject));
        }
        else if (other.CompareTag("Player"))
        {
            StateManager.Instance.state = State.EndGame;
            EventManager.Instance.StackAction();
        }
    }


}
