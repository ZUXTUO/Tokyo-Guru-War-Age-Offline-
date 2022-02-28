using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;
using System;

public class GetTime : MonoBehaviour
{
    int hour;
    int minute;
    int second;
    // 已经花费的时间 
    float timeSpend;
    // 显示时间区域的文本 
    public Text text_timeSpend;
    StreamWriter writer_Time;
    List<int> Allmytxt = new List<int>();
    public string SaveTXT_Time = "/Save_Time.txt";
    public bool On;
    public Slider TimeMain;
    public GameObject Bei_X;
    public GameObject YiNiao_X;
    public Text MainInfo;
    void Start()
    {
        On = false;
        Bei_X.SetActive(true);
        text_timeSpend = text_timeSpend.GetComponent<Text>();
#if UNITY_EDITOR
        FileInfo file = new FileInfo(Application.dataPath + SaveTXT_Time);
#elif UNITY_ANDROID
    FileInfo file = new FileInfo(Application.persistentDataPath + SaveTXT_Time);
#endif
        if (file.Exists)
        {
            ReadOutTxt();
        }
        else
        {
            timeSpend = 0f;
            text_timeSpend.text = timeSpend.ToString("f0");
        }
    }

    void Update()
    {
        timeSpend += Time.deltaTime;
        WriteIntoTxt();
        hour = (int)timeSpend / 3600;
        minute = ((int)timeSpend - hour * 3600) / 60;
        second = (int)timeSpend - hour * 3600 - minute * 60;
        text_timeSpend.text = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
        if (On)
        {
            if (timeSpend > 3600)
            {
                Bei_X.SetActive(false);
                YiNiao_X.SetActive(false);
            }
            else
            {
                if (timeSpend / 3600 >= 0.3)
                {
                    Bei_X.SetActive(false);
                    if (timeSpend / 3600 >= 1)
                    {
                        YiNiao_X.SetActive(false);
                    }
                }
            }
            TimeMain.value = timeSpend / 3600;
            MainInfo.text = TimeMain.value.ToString();
        }
    }

    public void WriteIntoTxt()
    {
#if UNITY_EDITOR
        FileInfo file = new FileInfo(Application.dataPath + SaveTXT_Time);
#elif UNITY_ANDROID
    FileInfo file = new FileInfo(Application.persistentDataPath + SaveTXT_Time);
#endif
        if (!file.Exists)
        {
            writer_Time = file.CreateText();
        }
        else
        {
            file.Delete();
            file.Refresh();
            writer_Time = file.CreateText();
        }
        writer_Time.WriteLine(timeSpend);
        writer_Time.Flush();
        writer_Time.Dispose();
        writer_Time.Close();
    }
    public void ReadOutTxt()
    {
#if UNITY_EDITOR
        var fileAddress = System.IO.Path.Combine(Application.dataPath + SaveTXT_Time);
#elif UNITY_ANDROID
        var fileAddress = System.IO.Path.Combine(Application.persistentDataPath + SaveTXT_Time);
#endif
        FileInfo fInfo0 = new FileInfo(fileAddress);
        string st = "";
        if (fInfo0.Exists)
        {
            StreamReader rt = new StreamReader(fileAddress);
            st = rt.ReadToEnd();
            timeSpend = float.Parse(st);
            text_timeSpend.text = st;
        }
    }
    public List<int> GetmytxtList()
    {
        ReadOutTxt();
        return Allmytxt;
    }
    public void OnStart()
    {
        On = true;
    }
    public void NoStart()
    {
        On = false;
    }
}
