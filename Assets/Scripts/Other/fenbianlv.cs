using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System;


public class fenbianlv : MonoBehaviour
{
    public static int Bilv = 1;
    public Canvas Canvas;
    public Image[] MoHu;
    public float W;
    public float H;
    void Start()
    {
        SetFBL();
        if (UnityEngine.Screen.width < 1920)
        {
            W = 1920;
            H = 1080;
        }
        else
        {
            W = UnityEngine.Screen.width;
            H = UnityEngine.Screen.height;
        }
        FBL();
    }
    public void SetFBL()
    {
        Application.targetFrameRate = 60;
    }
    public void FBL()
    {
        MoHu[0].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
        MoHu[1].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
        MoHu[2].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
        MoHu[3].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
        MoHu[4].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
        MoHu[5].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
        MoHu[6].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
        MoHu[7].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
        MoHu[8].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
        MoHu[9].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(W, H);
    }
}