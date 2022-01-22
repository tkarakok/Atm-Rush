using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtmController : MonoBehaviour
{
    public GameObject atmMoneyCounter;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Money"))
        {
            Destroy(other.gameObject);
            AtmMoneyCounter(GameManager.Instance.MoneyInAtm++);
        }
    }

    void AtmMoneyCounter(int value)
    {
        atmMoneyCounter.GetComponent<TextMesh>().text = value.ToString();
    }

}
