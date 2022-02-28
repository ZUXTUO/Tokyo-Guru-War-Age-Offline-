using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class GenZong : MonoBehaviour
{
    [SerializeField]
    GameObject worldPos;
    [SerializeField]
    RectTransform rectTrans;
    public Vector2 offset_;
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos.transform.position);
        rectTrans.position = screenPos + offset_;
    }
}