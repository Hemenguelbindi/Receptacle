using Lean.Pool;
using Script.Move;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] m_Spawne;
    [SerializeField] private EnemyMovement[] m_EnemyPrefabs; // ������ �������� ������
    [SerializeField] private int m_EnemiesPerWave = 5; // ���������� ������ � ����� �����
    [SerializeField] private int m_TotalWaves = 3; // ����� ���������� ����
    [SerializeField] private float m_WaveInterval = 10f; // �������� ����� �������
    [SerializeField] private float m_EnemySpawnInterval = 0.5f; // �������� ����� �������� ������� �����
    [SerializeField] private string nextSceneName; // ��� ��������� �����

    private int m_CurrentWave = 0;
    private int m_EnemiesSpawnedInWave = 0;
    private bool m_IsSpawningWave = false;

    private DiContainer diContainer;
    private PlayerMove Hero;

    [Inject]
    private void Constract(DiContainer dicontainer, PlayerMove hero)
    {
        diContainer = dicontainer;
        Hero = hero;
    }

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (m_CurrentWave < m_TotalWaves)
        {
            yield return new WaitForSeconds(m_WaveInterval);
            m_IsSpawningWave = true;
            m_EnemiesSpawnedInWave = 0;

            // ����������� ���������� ������ �� ������� �����
            m_EnemiesPerWave *= 2; // ����������� � ��� ����

            while (m_EnemiesSpawnedInWave < m_EnemiesPerWave)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(m_EnemySpawnInterval); // �������� ����� �������� ������ ������ �����
            }

            // ���������, ��� �� ����� �� ���������� ����� ����������
            while (AnyEnemiesAlive())
            {
                yield return null;
            }

            m_IsSpawningWave = false;
            m_CurrentWave++;
        }

        // ������� �� ��������� ����� ����� ���������� ���� ����
        SceneManager.LoadScene(nextSceneName);
    }

    bool AnyEnemiesAlive()
    {
        foreach (var enemy in m_EnemyPrefabs)
        {
            if (enemy != null && enemy.gameObject.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    void SpawnEnemy()
    {
        if (m_EnemiesSpawnedInWave < m_EnemiesPerWave)
        {
            int randomPoint = Random.Range(0, m_Spawne.Length);
            EnemyMovement enemyPrefab = m_EnemyPrefabs[Random.Range(0, m_EnemyPrefabs.Length)];
            diContainer.InstantiatePrefab(enemyPrefab, m_Spawne[randomPoint].position, Quaternion.identity, null);
            m_EnemiesSpawnedInWave++;
        }
    }
}
