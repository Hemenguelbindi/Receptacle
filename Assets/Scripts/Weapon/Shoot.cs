using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float _damage = 15;
    [SerializeField] float _range;
    [SerializeField] float _spread;
    [SerializeField] float _fireRate = 0.1f;

    public GameObject[] effect;

    [SerializeField] LayerMask[] layerMask;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    
    Enemy enemy;

    Camera camera;

    public Recoil recoil;

    public Reload reload;

    public CameraShake shake;

    private float _nextFireTime;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime && reload.ammo > 0)
        {
            Shooting();
            recoil.RecoilFire();
            audioSource.PlayOneShot(clip);
            reload.reloading();
            shake.ShakeCamera();

            _nextFireTime = Time.time + _fireRate;
        }
    }

    void Shooting()
    {
        var ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        GameObject hole;

        if (Physics.Raycast(ray, out hit, _range, layerMask[0]))
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log("Урон");
            enemy = hit.collider.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }
            hole = Instantiate(effect[0], hit.point, Quaternion.identity);
            Destroy(hole, 1f);
        }
        else if (Physics.Raycast(ray, out hit, _range, layerMask[1]))
        {
            Debug.Log("Мимо");
            hole = Instantiate(effect[1], hit.point, Quaternion.identity);
            Destroy(hole, 1f);
        }
    }
}
