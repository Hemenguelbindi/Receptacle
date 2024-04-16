using UnityEngine;
using Zenject;



public class ScenInstaller : MonoInstaller
{
    [SerializeField] private GameObject player;

    [SerializeField] private Transform playerSpawnPoint;
    public override void InstallBindings()
    {
        var playerInstance = Container.InstantiatePrefabForComponent<GameObject>(player, playerSpawnPoint.position, Quaternion.identity, null);
        Container.Bind<GameObject>().FromInstance(playerInstance).AsSingle().NonLazy();

    }
}