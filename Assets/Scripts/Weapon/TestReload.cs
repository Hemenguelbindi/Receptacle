
using TMPro;
using UnityEngine;

public class TestReload : MonoBehaviour
{
    public int ammo = 30; // ����������� ���������� �����������
    public int maxAmmo = 120; // ������������ ���������� �����������
    public float reloadTime = 2f; // ����� ����������� � ��������

    bool isReloading = false; // ����, ����������� �� ������� �����������
    float reloadTimer = 0f; // ������ ��� ������������ ������� �����������

    [SerializeField] KeyCode reloadKey = KeyCode.R; // ������� ��� ������� ������� �����������
    [SerializeField] TextMeshProUGUI ammoText; // ��������� ���� ��� ����������� ���������� �����������

    void Update()
    {
        // ���������, ����� �� ��������� �������������� �����������
        if (ammo == 0 && !isReloading)
        {
            StartReloading();
        }

        // ���������, ���� �� ������ ������� ����������� � ����� �� �������������� �������
        if (Input.GetKeyDown(reloadKey) && (ammo < 30) && !isReloading)
        {
            StartReloading();
        }

        // ��������� ����� � ����������� �����������
        UpdateAmmoText();

        // ��������� ��������� �����������, ���� ��� � ��������
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

        // ������������ ������� ����������� ����� ������������
        int ammoToAdd = Mathf.Min(maxAmmo, 30 - ammo);

        // ����������� ���������� ����������� �� ��������, ������ �������� ����� maxAmmo � �������� 30 � �������� ammo
        ammo += ammoToAdd;

        // ��������� ������������ ���������� �����������, ��������, ��� ��� �� ����� ����� �������������
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

