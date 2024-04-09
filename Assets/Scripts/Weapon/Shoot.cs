using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] float _range;
    [SerializeField] float _spread;
    [SerializeField] float _fireRate = 0.1f;

    public GameObject[] effect;

    [SerializeField] LayerMask[] layerMask;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    Camera camera;

    public Recoil recoil;

    private float _nextFireTime;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
        {
            Shooting();
            recoil.RecoilFire();
            audioSource.PlayOneShot(clip);

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
            hole = Instantiate(effect[0], hit.point, Quaternion.identity);
        }
        else if (Physics.Raycast(ray, out hit, _range, layerMask[1]))
        {
            Debug.Log("Мимо");
            hole = Instantiate(effect[1], hit.point , Quaternion.identity);
        }
    }
}
