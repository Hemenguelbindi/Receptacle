using Lean.Pool;
using TMPro;
using UnityEngine;


public class Health : MonoBehaviour
{
    int MaxHealth = 100;
    [SerializeField] int currentHealth;

    int maxArmor = 0;
    [SerializeField] int currentArmor;

    [SerializeField] GameObject character;

    [SerializeField] TextMeshProUGUI textHelth;
    [SerializeField] TextMeshProUGUI textArmor;

    private void Awake()
    {
        currentHealth = MaxHealth;
        currentArmor = 0;
    }

    private void Update()
    {
        if (character.gameObject.CompareTag("Player"))
        {
            textHelth.text = "HP : " + currentHealth.ToString();
            textArmor.text = "Armor : Брони нет";
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Armor: " + currentArmor);
        Debug.Log("Health: " + currentHealth);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            character.SetActive(false);
        }
    }
}
