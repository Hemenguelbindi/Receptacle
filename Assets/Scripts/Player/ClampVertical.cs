using UnityEngine;

public class CharCont : MonoBehaviour
{
    private Vector2 InputVector;

    public float slopeAngle = 20f;

    void Update()
    {
        InputVector.x = Input.GetAxis("Horizontal");
        InputVector.y = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f);

        transform.Rotate(0, InputVector.x * 90f * Time.deltaTime, 0);
        Vector3 Vel = transform.forward;

        float SurfNormalDotVel = Vector3.Dot(hit.normal, Vel);
        float UpSurfNormalAng = Vector3.Angle(Vector3.up, hit.normal);

        //Debug.Log(SurfNormalDotVel + " SurfNormalDotVel");

        if (SurfNormalDotVel < 0f && UpSurfNormalAng > slopeAngle || InputVector.y < 0.1f)// если идём не под гору и угол больше допустимого или не двигаемся  
        {
            Vel = Vector3.zero;
        }

        transform.Translate(Vel * 10f * Time.deltaTime, Space.World);
    }
}

