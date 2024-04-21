using Lean.Pool;
using Script.Move;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] m_Spawne;
    [SerializeField] private EnemyMovement[] m_EnemyPrefabs; // Массив префабов врагов
    [SerializeField] private int m_EnemyCount = 5; // Количество врагов для спауна
    [SerializeField] private float m_SpawnInterval = 2f; // Интервал между спаунами

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

            // Выбираем случайный префаб из массива
            EnemyMovement enemyPrefab = m_EnemyPrefabs[Random.Range(0, m_EnemyPrefabs.Length)];

            // Спауним врага
            //var enemy = LeanPool.Spawn(enemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity);
            //Instantiate(enemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity);
            diContainer.InstantiatePrefab(enemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity, null);
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
