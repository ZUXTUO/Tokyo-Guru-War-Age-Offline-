using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.07f;
    public void Move(Vector3 vector)
    {
        if (vector == Vector3.zero) return;

        vector = vector.normalized;

        transform.position += vector * speed;

        float angleOfLine = Mathf.Atan2(vector.x, vector.z) * 180 / Mathf.PI;

        transform.rotation = Quaternion.Euler(0, angleOfLine, 0);
    }
}