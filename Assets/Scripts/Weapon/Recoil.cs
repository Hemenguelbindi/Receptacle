using UnityEngine;

public class Recoil : MonoBehaviour
{
    private Vector3 currentRotation;
    private Vector3 targetRotation;
    private Vector3 targetPosition;
    private Vector3 initalGunPosition;
    private Vector3 currentPosition;

    [SerializeField] private float _recoilX;
    [SerializeField] private float _recoilY;
    [SerializeField] private float _recoilZ;
    [SerializeField] private float _kickBackZ;

    [SerializeField] private float _snappiness;
    [SerializeField] private float _returnSpeed;

    private void Start()
    {
        initalGunPosition = transform.localPosition;
    }

    private void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, _returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, _snappiness * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(currentRotation);
        KickBack();
    }

    public void RecoilFire()
    {
        targetPosition -= new Vector3(0, 0, _kickBackZ);
        targetRotation += new Vector3(_recoilX, Random.Range(-_recoilY, _recoilY), Random.Range(-_recoilZ, _recoilZ));
    }

    public void KickBack()
    {
        targetPosition = Vector3.Lerp(targetPosition, initalGunPosition, _returnSpeed * Time.deltaTime);
        currentPosition = Vector3.Slerp(currentPosition, targetPosition, _snappiness * Time.fixedDeltaTime);
        transform.localPosition = currentPosition;
    }
}
