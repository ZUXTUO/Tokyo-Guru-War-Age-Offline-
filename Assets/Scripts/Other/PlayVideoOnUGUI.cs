using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayVideoOnUGUI : MonoBehaviour
{
    public float fadeSpeed = 1;
    public VideoPlayer videoPlayer;
    public RawImage rawImage;
    public GameObject UI;
    public GameObject CAM;
    public GameObject VIDEO;
    public GameObject ZHU;

    void Start()
    {
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
            // 移除 else 块，视频结束的逻辑将由 OnVideoFinished 事件处理
        }
    }

    // 视频播放完成时调用此方法
    void OnVideoFinished(VideoPlayer vp)
    {
        // 确保视频播放器存在且已停止播放时才执行转换逻辑
        UI.SetActive(true); // 激活 UI
        VIDEO.SetActive(false); // 禁用视频 GameObject
        ZHU.SetActive(false); // 禁用 ZHU GameObject

        // 确保 CAM 引用不为空，并尝试获取 CameraManager 组件
        if (CAM != null)
        {
            CameraManager camManager = CAM.GetComponent<CameraManager>();
            if (camManager != null)
            {
                camManager.enabled = true; // 启用 CameraManager
            }
        }
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
