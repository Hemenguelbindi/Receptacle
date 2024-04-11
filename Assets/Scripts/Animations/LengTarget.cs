using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LengTarget : MonoBehaviour
{
    [SerializeField] private float speedFood = 5.0f;
    [SerializeField] private AnimationCurve speedCurve;
    
    private Vector3 posotions;
    private Movment? movement;
    private Transform transform;

    public Vector3 Position => posotions;
    public bool IsMoving => movement != null;
    private void Awake()
    {
        transform = base.transform;
        posotions = transform.position;
    }

    private void Update()
    {
        if (movement != null)
        {
            var m = movement.Value;
            m.Progress = Mathf.Clamp01(m.Progress + Time.deltaTime * speedFood);
            posotions = m.Evaluate(Vector3.up, speedCurve);
            movement = m.Progress < 1 ? m: null;
        }
        transform.position = posotions;

    }

    public void MoveTo(Vector3 targetPositions)
    {
        if (movement == null)
            movement = new Movment
            {
                Progress = 0,
                FromPosition = posotions,
                ToPosition = targetPositions
            };
        else
            movement = new Movment
            {
                Progress = movement.Value.Progress,
                FromPosition = movement.Value.FromPosition,
                ToPosition = targetPositions
            };
    }

    private struct Movment
    {
        public float Progress;
        public Vector3 FromPosition;
        public Vector3 ToPosition;
        public Vector3 Evaluate(in Vector3 up, AnimationCurve speedCurve)
        {
            return Vector3.Lerp(@FromPosition, ToPosition, Progress) + up * speedCurve.Evaluate(Progress);
        }
    }

   
}
