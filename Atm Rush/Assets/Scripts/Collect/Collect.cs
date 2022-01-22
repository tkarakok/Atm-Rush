using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public Transform parent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Money"))
        {
            other.tag = "Untagged";
            other.transform.SetParent(parent);
            other.gameObject.transform.position = transform.position + new Vector3(.3f,0,.3f);
            Destroy(transform.GetComponent<Collect>());
            other.gameObject.AddComponent<Collect>().parent = parent;
        }
    }

    
}
