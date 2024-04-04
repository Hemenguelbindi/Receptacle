using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform body;

    //Параметры мыши
    [Header("Mouse")]
    [SerializeField, Range(0f, 250f)] float _sensitivityX;
    [SerializeField, Range(0f, 250f)] float _sensitivityY;

    float _mouseX;
    float _mouseY;

    Vector2 _rotation;

    //параметры ограничения поворота по оси Y
    [Header("Clamp")]
    [SerializeField, Range(0f, -90f)] float _min;
    [SerializeField, Range(0f, 90f)] float _max;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        _mouseX = Input.GetAxis("Mouse X") * _sensitivityX * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensitivityY * Time.deltaTime;

        RotateCamera(_mouseX, _mouseY);

    }

    private void RotateCamera(float x, float y)
    {
        _rotation.y += x;
        _rotation.x -= y;

        _rotation.x = Mathf.Clamp(_rotation.x, _min, _max);

        transform.localRotation = Quaternion.Euler(new Vector3(_rotation.x, 0f, 0f));
        body.transform.localRotation = Quaternion.Euler(new Vector3(0f, _rotation.y, 0f));
    }


}

