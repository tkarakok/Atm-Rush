using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject moneyPrefab;


    IEnumerator Stacks()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject instance = Instantiate(moneyPrefab);
            instance.transform.position = spawnPoint.position + new Vector3(0, -i * .15f, 0);
            instance.transform.SetParent(transform);
            yield return new WaitForSeconds(.5f);
        }
    }

}
