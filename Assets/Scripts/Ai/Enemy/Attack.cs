using UnityEngine;

public class Attack: MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject particle;


    private void OnEnable()
    {
        particle.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Health>(out Health hp))
        {
            if(particle == null)
            {
                hp.OnTakeDameg?.Invoke(damage);
                animator.SetBool("StateAttack", true);
            }
            else
            {
                hp.OnTakeDameg?.Invoke(damage);

                particle.SetActive(true);
                animator.SetBool("StateAttack", true);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        animator.SetBool("StateAttack", false);
    }

}
