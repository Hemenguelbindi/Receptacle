using UnityEngine;

public class Aiming : MonoBehaviour
{
    Vector3 aimWeaponPosition;
    Vector3 startWeaponPosition;

    public GameObject crossHair;
    public WeaponBobbing bobbing;
    public HeadBobbing headBobbing;
    
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
            aimWeaponPosition = new Vector3(-0.145f, 0.053f, -0.06f);
            transform.localPosition = aimWeaponPosition;
            crossHair.SetActive(false);
            bobbing.isIdle = false;
            bobbing.transform.localPosition = bobbing.startPosition;
            headBobbing._amplitude = 0.002f;
            
        }
        if (Input.GetMouseButtonUp(1))
        {
            transform.localPosition = startWeaponPosition;
            crossHair.SetActive(true);
            bobbing.isIdle = true;
            headBobbing._amplitude = 0.006f;
        }
    }
}
