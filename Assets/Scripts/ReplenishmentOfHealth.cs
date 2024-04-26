using TMPro;
using UnityEngine;

public class ReplenishmentOfHealth : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Health health;

    private void Start()
    {
        health = FindAnyObjectByType<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && health.currentHealth < health.MaxHealth)
            {
                health.currentHealth = health.MaxHealth;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
        }
    }
}
