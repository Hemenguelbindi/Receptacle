using UnityEngine;

public class Gun : MonoBehaviour
{
    public Reload reload;
    void Start()
    {
        reload = GetComponent<Reload>();
    }

   
}
