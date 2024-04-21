using UnityEngine;
using Zenject;

public class Attack: MonoBehaviour
{
    [SerializeField] private int attackRange = 15;
    private Health heroHealth;
    [Inject]
    private void Contstract(Health HeroHealt)
    {
        Health heroHealth = HeroHealt;
    }

    public void NearAttack(int attackRange)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           heroHealth.TakeDamage(attackRange);
           Debug.Log("нанес урон");
        }
    }
}
