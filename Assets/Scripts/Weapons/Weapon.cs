using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float damage=21;
    [SerializeField] float fireRate=1;
    [SerializeField] float force = 155;
    [SerializeField] float rage = 15;
    [SerializeField] ParticleSystem muzzelFlash;
    [SerializeField] Transform bulidSpaune;
    [SerializeField] AudioClip shotSFX;
    [SerializeField] AudioSource shotSFXSource;

    public Camera camera;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        shotSFXSource.PlayOneShot(shotSFX);
        muzzelFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, rage)) {
            Debug.Log("œËÛ œËÛ ﬂ ÔÓÔÓ‡Î"+hit.collider);
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }
}
