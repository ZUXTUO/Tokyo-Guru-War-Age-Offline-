using UnityEngine;
using UnityEngine.UI;

public class fenbianlv : MonoBehaviour
{
    public static int Bilv = 1;
    public Image[] MoHu;
    private float W;
    private float H;

    void Start()
    {
        SetFBL();
        if (Screen.width < 1920)
        {
            W = 1920;
            H = 1080;
        }
        else
        {
            W = Screen.width;
            H = Screen.height;
        }
        FBL();
    }

    public void SetFBL()
    {
        Application.targetFrameRate = 60;
    }

    public void FBL()
    {
        foreach (Image img in MoHu)
        {
            if (img != null)
            {
                img.rectTransform.sizeDelta = new Vector2(W, H);
            }
        }
    }
}
