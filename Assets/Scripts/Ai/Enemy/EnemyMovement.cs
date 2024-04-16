using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject player; // ������ �� ������ ��� ��� ���������
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
        if (player == null) // ���������, ��� ����� ����������
            return;

        // ���������, ���������� �� ������� ������, � ������ � ���� ������ ��������� ����
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
        // ����� �� ������ ����������� ������ �����
        Debug.Log("Enemy is attacking!");
    }
}