using Script.Move;
using UnityEngine;
using UnityEngine.AI;
using Zenject;




public class EnemyMovement : MonoBehaviour
{

    
    NavMeshAgent agent;
    Vector3 previousPlayerPosition;
    private PlayerMove Hero;
    private Health HealthHero;
    private Attack attackState;

    [Inject]
    private void Constract(PlayerMove hero, Health health)
    {
        Hero = hero;
        HealthHero = health;
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    private void Update()
    {
        if (Hero == null) 
            return;


        if (Vector3.Distance(Hero.transform.position, previousPlayerPosition) > 0.01f)
        {
            SetDestination();
        }
        
    }


   

    void SetDestination()
    {
        previousPlayerPosition = Hero.transform.position;
        agent.SetDestination(previousPlayerPosition);
    }

}