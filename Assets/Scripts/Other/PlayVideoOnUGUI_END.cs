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
        videoPlayer = GetComponent<VideoPlayer>(); // 获取组件，无需使用this
        rawImage = GetComponent<RawImage>();     // 获取组件，无需使用this

        rawImage.color = Color.clear; // 将 RawImage 的颜色设置为透明，以便后续渐入

        // 确保 videoPlayer 引用不为空
        if (videoPlayer != null)
        {
            // 订阅 prepareCompleted 事件，在视频准备好后设置 RawImage 的纹理并开始播放
            videoPlayer.prepareCompleted += OnVideoPrepared;
            // 订阅 loopPointReached 事件，在视频播放结束时触发
            videoPlayer.loopPointReached += OnVideoFinished;
            videoPlayer.Prepare(); // 开始准备视频
        }
    }

    // 视频准备完成后调用此方法
    void OnVideoPrepared(VideoPlayer vp)
    {
        if (rawImage != null && videoPlayer.texture != null)
        {
            rawImage.texture = videoPlayer.texture; // 将视频纹理分配给 RawImage
        }
        videoPlayer.Play(); // 视频准备好后开始播放
        // 确保视频不循环播放，以便 loopPointReached 事件只在视频自然结束时触发一次
        videoPlayer.isLooping = false;
    }

    void Update()
    {
        // 确保 videoPlayer 引用不为空
        if (videoPlayer != null)
        {
            // 如果视频正在播放，则进行渐入效果
            if (videoPlayer.isPlaying)
            {
                rawImage.color = Color.Lerp(rawImage.color, Color.white, Time.deltaTime * fadeSpeed * 0.5f);
            }
            // 视频结束的逻辑将由 OnVideoFinished 事件处理，Update中不再需要else块
        }
    }

    // 视频播放完成时调用此方法
    void OnVideoFinished(VideoPlayer vp)
    {
        // 确保视频播放器存在且已停止播放时才执行转换逻辑
        GJ_1_CAM_1.SetActive(false);
        GJ_2_CAM_2.SetActive(true);
        GJ_3_VIDEO.SetActive(false);
        GJ_4_END.SetActive(true);
        GJ_5_JM.SetActive(true);
        GJ_6_BACK.SetActive(false);
        GJ_7_MUBIAO.SetActive(false);
    }

    // 当脚本被禁用或销毁时，取消订阅事件以避免内存泄漏
    void OnDisable()
    {
        if (videoPlayer != null)
        {
            videoPlayer.prepareCompleted -= OnVideoPrepared;
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.prepareCompleted -= OnVideoPrepared;
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }
}
