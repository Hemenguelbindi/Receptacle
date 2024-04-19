using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    public Health health;

    private void Start()
    {
        damage = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(damage);
        }
    }
}
