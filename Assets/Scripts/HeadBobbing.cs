using UnityEngine;

public class HeadBobbing : MonoBehaviour
{
    public float _amplitude = 0.12f;
    public float _speedBobbing = 0.1f;
    [SerializeField] float _speedReturn = 5f;

    //float timer = Mathf.PI / 2;

    Vector3 currentPosition;
    Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.localPosition;
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) != 0 || Mathf.Abs(Input.GetAxis("Vertical")) != 0)
        {
            //timer += _speedBobbing;
            float swingX = _amplitude * Mathf.Cos(Time.timeSinceLevelLoad * _speedBobbing);
            float swingY = startPosition.y + Mathf.Abs(_amplitude * Mathf.Sin(Time.timeSinceLevelLoad * _speedBobbing));


            currentPosition = new Vector3(swingX, swingY, startPosition.z);
            transform.localPosition = currentPosition;
        }
        else
        {
            currentPosition = Vector3.Lerp(transform.localPosition, startPosition, _speedReturn * Time.deltaTime);
            transform.localPosition = currentPosition;
        }

        //if (timer > Mathf.PI * 2)
        //{
        //  timer = 0.0f;
        //}
    }

}

