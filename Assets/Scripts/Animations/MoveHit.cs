using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHit : MonoBehaviour
{

    [SerializeField] private LegData[] lengs;

    [SerializeField] private float stepLength = 0.75f;

    private void Update()
    {
        foreach (var lenData in lengs)
        {
            if (!lenData.Leng.IsMoving && !(Vector3.Distance(lenData.Leng.Position, lenData.Raycast.Position) > stepLength)) continue;
            lenData.Leng.MoveTo(lenData.Raycast.Position);
        }
    }

    [Serializable]
    private struct LegData
    {
        public LengTarget Leng;
        public LangRaycast Raycast;
    }
}
