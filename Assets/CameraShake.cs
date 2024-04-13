using DG.Tweening;
using UnityEngine;


public class CameraShake : MonoBehaviour
{
    public Transform cameraShake;
    public float _dur;
    public float _str;
    public int _vibr;
    public float _random;


    public void ShakeCamera()
    {
        cameraShake.DOShakePosition(_dur, _str, _vibr);
    }
}
