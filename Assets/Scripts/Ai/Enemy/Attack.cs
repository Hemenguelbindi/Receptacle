using UnityEngine;

public class Attack: MonoBehaviour
{
    [SerializeField] private int damage = 10;
   
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Health>(out Health hp))
        { 
            hp.OnTakeDameg?.Invoke(damage);
        }
    }

}
