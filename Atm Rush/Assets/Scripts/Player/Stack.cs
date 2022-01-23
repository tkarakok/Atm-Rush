using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : Singleton<Stack>
{
    public Transform spawnPoint;
    public GameObject moneyPrefab;

    public void StartStacks()
    {
        StartCoroutine(Stacks());
    }

    IEnumerator Stacks()
    {
        for (int i = 0; i < GameManager.Instance.MoneyCounter; i++)
        {
            GameObject instance = Instantiate(moneyPrefab);
            instance.transform.position = spawnPoint.position + new Vector3(0, -i * .15f, 0);
            instance.transform.SetParent(transform);
            yield return new WaitForSeconds(.1f);
        }
        EventManager.Instance.EndGame();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Multiplier"))
        {
            GameManager.Instance.Multiplier = other.GetComponent<Multiplier>().multiplier;
        }
    }
}
