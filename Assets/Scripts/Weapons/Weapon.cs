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
    float nextFire = 0f;
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        shotSFXSource.PlayOneShot(shotSFX);
        muzzelFlash.Play();
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, rage)) {
            Debug.Log("Пиу Пиу Я попоал"+hit.collider);
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * force);
            }
        }
    }
}
