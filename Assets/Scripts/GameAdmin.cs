using Script.Move;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameAdmin : MonoBehaviour
{

    public static GameAdmin Instance { get; private set; }
    private Transform Hero;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Задаем позицию игрока
    public void SetPlayer(Transform hero)
    {
        Hero = hero;
    }

    public Transform GetPlayer()
    {
         return Hero;
    }
}
