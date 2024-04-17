using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] m_Spawne;
    [SerializeField] private GameObject m_EnemyPrefab;
    [SerializeField] private int m_EnemyCount = 5; // Количество врагов для спауна
    [SerializeField] private float m_SpawnInterval = 2f; // Интервал между спаунами

    private int m_CurrentSpawned = 0;
    private float m_Timer = 0f;

    void Start()
    {
        // Запускаем спаун врагов
        InvokeRepeating("SpawnEnemies", 0f, m_SpawnInterval);
    }

    void SpawnEnemies()
    {
        // Проверяем, что мы еще не заспаунили все врагов
        if (m_CurrentSpawned < m_EnemyCount)
        {
            // Выбираем случайную точку спауна
            int randomPoint = Random.Range(0, m_Spawne.Length);

            // Спауним врага
            LeanPool.Spawn(m_EnemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity);
            //Instantiate(m_EnemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity);

            // Увеличиваем счетчик заспауненных врагов
            m_CurrentSpawned++;
        }
        else
        {
            // Если все враги заспаунились, отменяем повторяющийся вызов
            CancelInvoke("SpawnEnemies");
        }
    }
}
