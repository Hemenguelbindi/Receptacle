using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100;
    [SerializeField] float currentHealth;
    [SerializeField] GameObject enemy;

    private void Awake()
    {
        currentHealth = MaxHealth;
    }


    public void TakeDamage(float damage)
    {
        Debug.Log(damage);
        currentHealth -= damage;
        
        if (currentHealth < 0)
        {
            LeanPool.Despawn(enemy);
        }
    }
}
