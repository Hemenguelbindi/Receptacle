
using TMPro;
using UnityEngine;

public class TestReload : MonoBehaviour
{
    public int ammo = 30; // »значальное количество боеприпасов
    public int maxAmmo = 120; // ћаксимальное количество боеприпасов
    public float reloadTime = 2f; // ¬рем€ перезар€дки в секундах

    bool isReloading = false; // ‘лаг, указывающий на процесс перезар€дки
    float reloadTimer = 0f; // “аймер дл€ отслеживани€ времени перезар€дки

    [SerializeField] KeyCode reloadKey = KeyCode.R; //  лавиша дл€ ручного запуска перезар€дки
    [SerializeField] TextMeshProUGUI ammoText; // “екстовое поле дл€ отображени€ количества боеприпасов

    void Update()
    {
        // ѕровер€ем, нужно ли запустить автоматическую перезар€дку
        if (ammo == 0 && !isReloading)
        {
            StartReloading();
        }

        // ѕровер€ем, была ли нажата клавиша перезар€дки и нужно ли перезар€жатьс€ вручную
        if (Input.GetKeyDown(reloadKey) && (ammo < 30) && !isReloading)
        {
            StartReloading();
        }

        // ќбновл€ем текст с количеством боеприпасов
        UpdateAmmoText();

        // ќбновл€ем состо€ние перезар€дки, если она в процессе
        if (isReloading)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadTime)
            {
                FinishReloading();
            }
        }
    }

    void StartReloading()
    {
        isReloading = true;
        reloadTimer = 0f;

        // –ассчитываем сколько боеприпасов можно восстановить
        int ammoToAdd = Mathf.Min(maxAmmo, 30 - ammo);

        // ”величиваем количество боеприпасов на величину, равную минимуму между maxAmmo и разницей 30 и текущего ammo
        ammo += ammoToAdd;

        // ”меньшаем максимальное количество боеприпасов, учитыва€, что оно не может стать отрицательным
        maxAmmo = Mathf.Max(0, maxAmmo - ammoToAdd);
    }

    void FinishReloading()
    {
        isReloading = false;
    }

    void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammo + "/" + maxAmmo;
    }
}

