using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : MonoBehaviour
{
    public Reload reload;

    private void Start()
    {
        reload = GetComponent<Reload>();
    }
}
