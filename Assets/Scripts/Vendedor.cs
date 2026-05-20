using UnityEngine;

public class Vendedor : MonoBehaviour
{
   public GameObject shopUI;

void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
        shopUI.SetActive(true);
}

void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
        shopUI.SetActive(false);
}
}
