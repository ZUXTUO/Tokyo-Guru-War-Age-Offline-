using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayVideoOnUGUI : MonoBehaviour
{
    public float fadeSpeed = 1;
    private VideoPlayer videoPlayer;
    private RawImage rawImage;
    public GameObject UI;
    public GameObject CAM;
    public GameObject VIDEO;
    public GameObject ZHU;
    void Start()
    {
        videoPlayer = this.GetComponent<VideoPlayer>();
        rawImage = this.GetComponent<RawImage>();
        rawImage.color = Color.clear;
    }
    void Update()
    {
        if (videoPlayer.texture == null)
        {
            return;
        }
        rawImage.texture = videoPlayer.texture;
        if (videoPlayer.isPlaying)
        {
        rawImage.color = Color.Lerp(rawImage.color, Color.white, Time.deltaTime * fadeSpeed * 0.5f);
        }
        else
        {
            UI.SetActive(true);
            VIDEO.SetActive(false);
            ZHU.SetActive(false);
            CAM.GetComponent<CameraManager>().enabled = true;
        }
    }
}