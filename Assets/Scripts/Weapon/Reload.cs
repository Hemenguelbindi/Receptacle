using System.Collections;
using TMPro;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public Shoot shoot;

    public int ammo = 30;
    public int maxAmmo = 120;

    public float timeReload;

    [SerializeField] TextMeshProUGUI textAmmo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && ammo != 30)
        {
            StartCoroutine(StatsReloading());
        }

        textAmmo.text = ammo + "/" + maxAmmo;
    }

    public IEnumerator StatsReloading()
    {
        int ammoToAdd = Mathf.Min(maxAmmo, 30 - ammo);

        shoot.isShooting = false;

        yield return new WaitForSeconds(timeReload);

        shoot.isShooting = true;

        ammo += ammoToAdd;

        maxAmmo = Mathf.Max(0, maxAmmo - ammoToAdd);

        yield return new WaitForSeconds(0.1f);

    }

    public void Reloading()
    {
        if (ammo != 0)
        {
            ammo--;
        }
    }


}
