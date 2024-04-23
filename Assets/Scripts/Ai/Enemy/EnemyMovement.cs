﻿using Script.Move;
using UnityEngine;
using UnityEngine.AI;
using Zenject;



public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 previousPlayerPosition;
    [SerializeField] private Animator Animation;
    [SerializeField] private Attack EnemyAttack;
    private PlayerMove Hero; 

    [Inject]
    private void Constract(PlayerMove hero)
    {
        Hero = hero;
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
        Animation.SetBool("StateWalk", true);
    }
  
}