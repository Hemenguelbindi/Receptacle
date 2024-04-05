using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public CharacterController _controller;
    public bool isGrounded;
    public Vector3 velocity;

    public static GroundChecker instance { get; set; }

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        isGrounded = _controller.isGrounded;
    }




}
