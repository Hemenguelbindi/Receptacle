using System.Collections;
using TMPro;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public int ammo = 30;
    public int maxAmmo = 120;
    public int ClipSize;

    public float timeReload;

    [SerializeField] TextMeshProUGUI textAmmo;

         
    public void reloading()
    {
        int amountNeeded = ClipSize - ammo;

        if (amountNeeded >= maxAmmo)
        {
            ammo += maxAmmo;
            maxAmmo -= amountNeeded;
        }
        else
        {
            ammo = ClipSize;
            maxAmmo = amountNeeded;
        }
        UpdateAmmoInScreen();
    }

    public void UpdateAmmoInScreen() 
    {
        textAmmo.text = ammo + "/" + maxAmmo;
        if(ammo <= 0) ammo = 0;
        if(maxAmmo <= 0) maxAmmo = 0;
    }
}
