using DG.Tweening;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    public Transform cameraShake;

    public void ShakeCamera()
    {
        cameraShake.DOShakePosition(0.07f, 0.1f, 1);
        cameraShake.DOShakeRotation(1f, 1f, 5);
    }
}
