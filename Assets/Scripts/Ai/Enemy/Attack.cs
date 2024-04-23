using UnityEngine;

public class Attack: MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private Animator animator;
   
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Health>(out Health hp))
        { 
            hp.OnTakeDameg?.Invoke(damage);
            animator.SetBool("StateAttack", true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        animator.SetBool("StateAttack", false);
    }

}
