using UnityEngine;

public class WeaponBobbing : MonoBehaviour
{
    [SerializeField] float bobbingSpeed = 0.18f;
    [SerializeField] float bobbingAmount = 0.2f;
    [SerializeField] float midpoint = 2.0f;

    private float timer = 0.0f;
    public bool isIdle = true;

    private void Update()
    {

        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 0 || Mathf.Abs(Input.GetAxis("Vertical")) == 0)
        {
            if (isIdle)
            StateIdle();
        }

    }


    void StateIdle()
    {
        float waveslice = Mathf.Sin(timer);
        timer = timer + bobbingSpeed;
        if (timer > Mathf.PI * 2)
        {
            timer = timer - (Mathf.PI * 2);
        }

        float translateChange = waveslice * bobbingAmount;
        float newPositionY = midpoint + translateChange;

        Vector3 newPosition = new Vector3(transform.localPosition.x, newPositionY, transform.localPosition.z);

        transform.localPosition = newPosition;
    }
}