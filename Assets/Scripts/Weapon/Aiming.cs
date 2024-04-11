using UnityEngine;

public class Aiming : MonoBehaviour
{
    Vector3 aimWeaponPosition;
    Vector3 startWeaponPosition;

    public GameObject crossHair;
    public WeaponBobbing bobbing;
    
    private void Start()
    {
        startWeaponPosition = transform.localPosition;
    }

    private void Update()
    {
        Aim();
    }

    void Aim()
    {
        if (Input.GetMouseButtonDown(1))
        {
            aimWeaponPosition = new Vector3(-0.145f, 0.055f, 0f);
            transform.localPosition = aimWeaponPosition;
            crossHair.SetActive(false);
            bobbing.isIdle = false;
        }
        if (Input.GetMouseButtonUp(1))
        {
            transform.localPosition = startWeaponPosition;
            crossHair.SetActive(true);
            bobbing.isIdle = true;
        }
    }
}
