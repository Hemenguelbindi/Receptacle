using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] float swayAmount = 0.02f;
    [SerializeField] float maxSwayAmount = 0.06f;
    [SerializeField] float smoothFactor = 4f;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        float moveX = -Input.GetAxis("Mouse X") * swayAmount;
        float moveY = -Input.GetAxis("Mouse Y") * swayAmount;

        moveX = Mathf.Clamp(moveX, -maxSwayAmount, maxSwayAmount);
        moveY = Mathf.Clamp(moveY, -maxSwayAmount, maxSwayAmount);

        Vector3 targetPosition = new Vector3(moveX, moveY, 0f);

        transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition + targetPosition, Time.deltaTime * smoothFactor);

    }
}
