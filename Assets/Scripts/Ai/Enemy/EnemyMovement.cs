using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player; // —сылка на игрока или его коллайдер
    NavMeshAgent agent;
    Vector3 previousPlayerPosition;
    [SerializeField] float attackRange = 2f;
    Vector3 previousTargetPosition;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    private void Update()
    {
        if (player == null) // ѕровер€ем, что игрок существует
            return;

        // ѕровер€ем, изменилась ли позици€ игрока, и только в этом случае обновл€ем путь
        if (player.transform.position != previousPlayerPosition)
        {
            SetDestination();
        }
    }

    void SetDestination()
    {
        agent.SetDestination(previousPlayerPosition);
        previousPlayerPosition = player.transform.position;
    }

    void Attack()
    {
        // «десь ты можешь реализовать логику атаки
        Debug.Log("Enemy is attacking!");
    }
}