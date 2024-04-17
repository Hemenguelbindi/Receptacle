using UnityEngine;


public class InitResorses : MonoBehaviour
{
    [SerializeField] private Transform Hero;
    private void Start()
    {
        GameAdmin.Instance.SetPlayer(Hero);
    }
}
