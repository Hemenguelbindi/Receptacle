using System;
using System.Threading;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.Move
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        CharacterController controller;

        [SerializeField] LayerMask mask;
        [SerializeField] Transform groundCheck;
        [SerializeField] AudioClip[] steps;
        [SerializeField] HeadBobbing[] bobbing;

        AudioSource audioSource;

        //параметры скорости
        [Header("Speed Parameters")]
        [SerializeField] float _walkSpeed = 2f;
        [SerializeField] float _runSpeed = 4f;
        [SerializeField] float _crouchSpeed = 1f;

        //начальная скорость
        float _currentSpeed;

        //кинематика
        [Header("Gravitation and Jump")]
        [SerializeField] float _jumpForce = 2f;
        [SerializeField] float _gravity = -25f;
        [SerializeField] float _groundCheckDistance = 0.4f;

        [Header("Settings Move Sounds")]
        [SerializeField] float _timer = 0.7f;
        [SerializeField] float _timerDown = 0.1f;


        public bool _isGrounded;

        Vector3 directionMove = Vector3.zero;
        Vector3 velocity = Vector3.zero;

        public bool _canMove { get; private set; } = true;
        public bool _canJump { get; private set; } = true;

        [NonSerialized]
        public float horizontal;
        [NonSerialized]
        public float vertical;


        private void Start()
        {
            _currentSpeed = _walkSpeed;

            controller = GetComponent<CharacterController>();
            audioSource = GetComponent<AudioSource>();


        }

        private void Update()
        {
            if (_canMove)
            {
                Walk();

                Sprint(Input.GetKey(KeyCode.LeftShift));

                Crouch(Input.GetKey(KeyCode.LeftControl));
            }

            HundleGravity();

            if (_canJump)
            {
                if (Input.GetButtonDown("Jump") && _isGrounded)
                {
                    velocity.y = Mathf.Sqrt(_gravity * -2f * _jumpForce);
                }
            }
        }

        private void FixedUpdate()
        {
            FootStep();
        }

        private void Walk()
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            directionMove = (transform.forward * vertical + transform.right * horizontal).normalized;

            controller.Move(directionMove * _walkSpeed * Time.deltaTime);

           
        }

        void HundleGravity()
        {
            _isGrounded = Physics.CheckSphere(groundCheck.position, _groundCheckDistance, mask);

            velocity.y += _gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            if (_isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
        }

        void Sprint(bool canSprint)
        {
            _walkSpeed = canSprint ? _runSpeed : _currentSpeed;

            if(canSprint)
            {
                bobbing[0]._speedBobbing = 9f;
                bobbing[1]._speedBobbing = 9f;
                _timer = 0.3f;
            }
            else
            {
                bobbing[0]._speedBobbing = 7f;
                bobbing[1]._speedBobbing = 7f;
                _timer = 0.48f;
            }
        }

        void Crouch(bool canCrouch)
        {
            controller.height = canCrouch ? 1f : 2f;
        }

        void FootStep()
        {
            if (_timerDown > 0)
            {
                _timerDown -= Time.deltaTime;
            }

            if ((Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f) && _isGrounded)
            {
                if (_timerDown <= 0)
                {
                    audioSource.PlayOneShot(steps[Random.Range(0, steps.Length)]);

                    _timerDown = _timer;
                }
            }
            else
            {
                _timerDown = 0f;
            }
        }
    }
}

