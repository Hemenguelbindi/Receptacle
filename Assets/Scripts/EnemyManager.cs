using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] m_Spawne;
    [SerializeField] private GameObject m_EnemyPrefab;
    [SerializeField] private int m_EnemyCount = 5; // ���������� ������ ��� ������
    [SerializeField] private float m_SpawnInterval = 2f; // �������� ����� ��������

    private int m_CurrentSpawned = 0;
    private float m_Timer = 0f;

    void Start()
    {
        // ��������� ����� ������
        InvokeRepeating("SpawnEnemies", 0f, m_SpawnInterval);
    }

    void SpawnEnemies()
    {
        // ���������, ��� �� ��� �� ���������� ��� ������
        if (m_CurrentSpawned < m_EnemyCount)
        {
            // �������� ��������� ����� ������
            int randomPoint = Random.Range(0, m_Spawne.Length);

            // ������� �����
            LeanPool.Spawn(m_EnemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity);
            //Instantiate(m_EnemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity);

            // ����������� ������� ������������ ������
            m_CurrentSpawned++;
        }
        else
        {
            // ���� ��� ����� ������������, �������� ������������� �����
            CancelInvoke("SpawnEnemies");
        }
    }
}
