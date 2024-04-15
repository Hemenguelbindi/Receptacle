using System.Collections;
using TMPro;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public Shoot shoot;
    public Animator controller;

    public int ammo = 30;
    public int maxAmmo = 120;

    public float timer;

    public float timeReload;

    bool isReloading = false;

    [SerializeField] TextMeshProUGUI textAmmo;

    private void Update()
    {

        if (isReloading)
        {
            timer += Time.deltaTime;

            if (timer >= timeReload)
            {
                controller.SetBool("isReload", false);
                isReloading = false;
                timer = 0;
            }
        }

        else if (Input.GetKeyDown(KeyCode.R) && ammo != 30 && !isReloading)
        {
            controller.SetBool("isReload", true);
            isReloading = true;
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
    }

    public void Reloading()
    {
        if (ammo != 0)
        {
            ammo--;
        }
    }
}
