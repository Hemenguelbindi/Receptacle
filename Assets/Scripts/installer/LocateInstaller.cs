using Script.Move;
using Zenject;
using UnityEngine;


public class LocateInstaller : MonoInstaller
{
    public Transform StartPoint;
    public GameObject PlayerPrefab;
    public override void InstallBindings()
    {
        BindPlayer();
    }

    private void BindPlayer()
    {
        GameObject playerGameObject = Container.InstantiatePrefab(PlayerPrefab, StartPoint.position, Quaternion.identity, null);
        PlayerMove playerMove = playerGameObject.GetComponent<PlayerMove>();
        Container.Bind<PlayerMove>().FromInstance(playerMove).AsSingle().NonLazy();
    }
}