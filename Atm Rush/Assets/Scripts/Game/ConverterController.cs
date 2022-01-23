using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConverterController : MonoBehaviour
{
    public Material gold;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Money"))
        {
            other.GetComponent<MeshRenderer>().material = gold;
            GameManager.Instance.UpdateMoneyCounterText();
        }
    }
}
