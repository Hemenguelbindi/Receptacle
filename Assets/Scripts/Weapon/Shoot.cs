using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] float _damage;
    [SerializeField] float _range;
    [SerializeField] float _spread;

    public GameObject effect;

    [SerializeField] LayerMask layerMask;

    Camera camera;

    public Recoil recoil;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Shooting();
            recoil.RecoilFire();
        }
    }

    void Shooting()
    {
        var ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _range, layerMask))
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log("Урон");
            var hole = Instantiate(effect, hit.point, Quaternion.identity);
        }
        else
        {
            Debug.Log("Мимо");
        }
    }
}
