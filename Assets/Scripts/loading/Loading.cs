using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    public Slider m_Slider;
    public Text m_Text;
    public string Sce_Input;
    public static string Sce;
    void Start()
    {
        Sce= Sce_Input;
        StartCoroutine(loadScene());
    }
    IEnumerator loadScene()
    {
        int displayProgress = 0;
        int toProgress = 0;
        //AsyncOperation op = Application.LoadLevelAsync(Global.GetInstance().loadName);
        AsyncOperation op = SceneManager.LoadSceneAsync(Global.GetInstance().loadName);
        op.allowSceneActivation = false;
        while (op.progress < 0.9f)
        {
            toProgress = (int)op.progress * 100;
            while (displayProgress < toProgress)
            {
                ++displayProgress;
                SetLoadingPercentage(displayProgress);
                yield return new WaitForEndOfFrame();
            }
        }
        toProgress = 100;
        while (displayProgress < toProgress)
        {
            ++displayProgress;
            SetLoadingPercentage(displayProgress);
            yield return new WaitForEndOfFrame();
        }
        op.allowSceneActivation = true;
    }
    public void SetLoadingPercentage(int DisplayProgress)
    {
        m_Slider.value = DisplayProgress * 0.01f;
        m_Text.text = DisplayProgress.ToString() + "%";
    }
}