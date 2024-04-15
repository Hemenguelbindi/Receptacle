using TMPro;
using UnityEngine;

public class ReplenishmentOfAmmunition : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Reload ammo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);


        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && ammo.maxAmmo < 120)
            {
                ammo.maxAmmo = 120;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            text.gameObject.SetActive(false);
        }
    }

}
