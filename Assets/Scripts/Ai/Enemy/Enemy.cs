using Lean.Pool;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MaxHealth = 100;
    [SerializeField] float currentHealth;
    [SerializeField] GameObject enemy;
    [SerializeField] Animator animator;

    private void Awake()
    {
        currentHealth = MaxHealth;
    }


    public void TakeDamage(float damage)
    {
        //Debug.Log(damage);
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            animator.SetBool("StateDeath", true);
            Destroy(enemy);
        }
    }
}
