using DG.Tweening;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    public Transform cameraShake;

    [SerializeField] float _smooth;

    Vector3 startPosition;
    Quaternion startRotation;

    private void Start()
    {
        startPosition = cameraShake.localPosition;
        startRotation = Quaternion.Euler(cameraShake.localRotation.eulerAngles.x, cameraShake.localRotation.eulerAngles.y, 0f);
    }

    private void FixedUpdate()
    {
        cameraShake.localPosition = startPosition;
        cameraShake.localRotation = Quaternion.Slerp(cameraShake.localRotation, startRotation, _smooth);
    }
    public void ShakeCamera()
    {

        cameraShake.DOShakePosition(0.07f, 0.1f, 4);
        cameraShake.DOShakeRotation(0.3f, new Vector3(0.4f, 0.4f, 0f), 5);


    }
}
