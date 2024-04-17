using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingWeapon : MonoBehaviour
{
    public GameObject[] weapons;

    private void Update()
    {
        Changing();
    }

    void Changing()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
        }
    }
}
