using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] private Transform[] m_Spawne;
    [SerializeField] private GameObject m_EnenamyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
          
    }

    void SpawnerEnemy()
    {
        Instantiate(m_EnenamyPrefab, m_Spawne[0].transform.position, Quaternion.identity);
    }

}
