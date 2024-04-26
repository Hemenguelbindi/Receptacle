using System.Collections;
using TMPro;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public Shoot shoot;
    public Animator controller;

    public int ammo;
    public int currentAmmo;

    public int maxAmmo;
    public int currentMaxAmmo;

    public float timer;

    public float timeReload;

    bool isReloading = false;

    [SerializeField] TextMeshProUGUI textAmmo;

    public AudioClip reload;
    public AudioSource reloadSource;

    private void Start()
    {
        currentAmmo = ammo;
        currentMaxAmmo = maxAmmo;
    }

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

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != ammo && !isReloading)
        {
            reloadSource.PlayOneShot(reload);
            isReloading = true;
            reloadSource.PlayOneShot(reload);
            controller.SetBool("isReload", true);
            StartCoroutine(StatsReloading());
        }

        textAmmo.text = currentAmmo + "/" + currentMaxAmmo;
    }

    public IEnumerator StatsReloading()
    {
        int ammoToAdd = Mathf.Min(currentMaxAmmo, ammo - currentAmmo);

        shoot.isShooting = false;

        yield return new WaitForSeconds(timeReload);

        shoot.isShooting = true;

        currentAmmo += ammoToAdd;

        currentMaxAmmo = Mathf.Max(0, currentMaxAmmo - ammoToAdd);
    }

    public void Reloading()
    {
        if (currentAmmo != 0)
        {
            currentAmmo--;
        }
    }
}