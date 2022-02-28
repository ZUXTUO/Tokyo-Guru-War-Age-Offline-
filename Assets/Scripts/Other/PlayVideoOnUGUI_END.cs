using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayVideoOnUGUI_END : MonoBehaviour
{
    public float fadeSpeed = 1;
    private VideoPlayer videoPlayer;
    private RawImage rawImage;
    public GameObject GJ_1_CAM_1;
    public GameObject GJ_2_CAM_2;
    public GameObject GJ_3_VIDEO;
    public GameObject GJ_4_END;
    public GameObject GJ_5_JM;
    public GameObject GJ_6_BACK;
    public GameObject GJ_7_MUBIAO;
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
            GJ_1_CAM_1.SetActive(false);
            GJ_2_CAM_2.SetActive(true);
            GJ_3_VIDEO.SetActive(false);
            GJ_4_END.SetActive(true);
            GJ_5_JM.SetActive(true);
            GJ_6_BACK.SetActive(false);
            GJ_7_MUBIAO.SetActive(false);
        }
    }
}