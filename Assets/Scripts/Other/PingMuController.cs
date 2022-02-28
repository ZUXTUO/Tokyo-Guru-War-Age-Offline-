using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PingMuController : MonoBehaviour
{
    public Image rocker;
    private Vector3 beginPos;
    private CameraController controller;
    public float W;
    public float H;
    public Transform Wuti;
    void Start()
    {
        W = Screen.width;
        H = Screen.height;
        rocker.transform.gameObject.SetActive(false);
        controller = FindObjectOfType<CameraController>();
    }

    private void Update()
    {
            Rocker();
            var position = Wuti.gameObject.transform.position;
            position = new Vector3(Mathf.Clamp(position.x, -8, 10), 0, -10);
            Wuti.gameObject.transform.position = position;
    }
    public void Rocker()
    {
        //if (Input.mousePosition.x < W / 2)
        //{
            if (Input.GetMouseButtonDown(0))
            {
                rocker.transform.parent.gameObject.SetActive(true);
                beginPos = Input.mousePosition;
                rocker.transform.transform.position = beginPos;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 vector = Input.mousePosition - beginPos;
                vector = vector.normalized;
                rocker.transform.localPosition = Mathf.Clamp(Vector3.Distance(beginPos, Input.mousePosition), 0, 120f) * vector;
                controller.Move(new Vector3(Mathf.Cos(-45) * vector.x + Mathf.Sin(-45) * vector.y, 0, 0));
            }
            else if (Input.GetMouseButtonUp(0))
            {
                beginPos = Vector3.zero;
                rocker.transform.localPosition = Vector3.zero;
                rocker.transform.gameObject.SetActive(false);
            }
        //}
    }
    public void MenuOn()
    {
        this.GetComponent<PingMuController>().enabled = true;
    }
    public void MenuOff()
    {
        this.GetComponent<PingMuController>().enabled = false;
    }
}