using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraController : MonoBehaviour
{
    public float speed = 0.01f;
    public void Move(Vector3 vector)
    {
        if (vector == Vector3.zero) return;
        vector = vector.normalized;
        transform.position += vector * speed;
    }
}