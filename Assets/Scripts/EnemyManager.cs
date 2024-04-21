using Lean.Pool;
using Script.Move;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] m_Spawne;
    [SerializeField] private EnemyMovement[] m_EnemyPrefabs; // ������ �������� ������
    [SerializeField] private int m_EnemyCount = 5; // ���������� ������ ��� ������
    [SerializeField] private float m_SpawnInterval = 2f; // �������� ����� ��������

    private int m_CurrentSpawned = 0;
    private float m_Timer = 0f;

    private DiContainer diContainer;
    private PlayerMove Hero;

    [Inject]
    private void Constract(DiContainer dicontainer, PlayerMove hero)
    {
        diContainer = dicontainer;
        Hero = hero;
        Debug.Log(Hero);
    }

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

            // �������� ��������� ������ �� �������
            EnemyMovement enemyPrefab = m_EnemyPrefabs[Random.Range(0, m_EnemyPrefabs.Length)];

            // ������� �����
            //var enemy = LeanPool.Spawn(enemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity);
            //Instantiate(enemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity);
            diContainer.InstantiatePrefab(enemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity, null);
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
