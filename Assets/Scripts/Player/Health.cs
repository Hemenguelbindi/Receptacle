using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    public int currentHealth;

    int maxArmor = 0;
    [SerializeField] int currentArmor;

    [SerializeField] GameObject character;

    [SerializeField] TextMeshProUGUI textHelth;
    [SerializeField] TextMeshProUGUI textArmor;
    public Action<int> OnTakeDameg;


    private void OnEnable()
    {
        OnTakeDameg += TakeDamage;
    }

    private void OnDisable()
    {
        OnTakeDameg -= TakeDamage;
    }


    private void Awake()
    {
        currentHealth = MaxHealth;
        currentArmor = 0;
    }

    private void Update()
    {
        textHelth.text = "HP : " + currentHealth.ToString();
        textArmor.text = "Armor : Отсутвует";
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Armor: " + currentArmor);
        Debug.Log("Health: " + currentHealth);

        currentHealth -= damage;

        textHelth.text = "HP : " + currentHealth.ToString();
        textArmor.text = "Armor : Отсутвует";

        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("Dead");
        }
    }
}