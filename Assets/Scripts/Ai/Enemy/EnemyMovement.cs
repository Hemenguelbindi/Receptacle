using UnityEngine;
using UnityEngine.AI;



public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 previousPlayerPosition;
    [SerializeField] float attackRange = 2f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    private void Update()
    {
        if (GameAdmin.Instance.GetPlayer().position == null) 
            return;


        if (GameAdmin.Instance.GetPlayer().position != previousPlayerPosition)
        {
            SetDestination();
        }
    }

    void SetDestination()
    {
        previousPlayerPosition = GameAdmin.Instance.GetPlayer().position;
        agent.SetDestination(previousPlayerPosition);
    }


    void Attack()
    {
        Debug.Log("Enemy is attacking!");
    }
}