using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Load_Save_Kuang : MonoBehaviour
{
    public Sprite[] Sp1,Sp2;
    public Image[] Kuang1,Kuang2;
    public void OnEnable()
    {
        Load();
    }
    public void Load()
    {
        Kuang1[0].sprite = Sp1[Save_All.StaticSaveList.Kuang1];
        Kuang1[1].sprite = Sp1[Save_All.StaticSaveList.Kuang1];
        Kuang2[0].sprite = Sp2[Save_All.StaticSaveList.Kuang2];
        Kuang2[1].sprite = Sp2[Save_All.StaticSaveList.Kuang2];
        Save_All.Write();
    }
    public void ChangeKuang1(int a)
    {
        Save_All.StaticSaveList.Kuang1 = a;
        Load();
    }
    public void ChangeKuang2(int b)
    {
        Save_All.StaticSaveList.Kuang2 = b;
        Load();
    }
    public void ChangeQuality(int c)
    {
        Save_All.StaticSaveList.Quality = c;
        QualitySettings.SetQualityLevel(c, true);
        if (c == 2)
        {
            GameObject.Find("Save").layer = 8;
        }
        else
        {
            GameObject.Find("Save").layer = 0;
        }
        Save_All.Write();
    }
}
