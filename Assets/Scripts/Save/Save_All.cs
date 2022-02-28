using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public class Save_All : MonoBehaviour
{
    public All_SaveList SaveList;
    public static All_SaveList StaticSaveList;
    public GameObject ThisGJ;
    public static GameObject ThisGJS;
    public void Start()
    {
        StaticSaveList = SaveList;
        ThisGJS = ThisGJ;
        DontDestroyOnLoad(this.gameObject);
        Read();
    }
    public static void Read()
    {
        string fileadress_PC = Application.dataPath + "/Save.json";
        string fileadress_Android = Application.persistentDataPath + "/Save.json";
#if UNITY_EDITOR
        System.IO.FileInfo file = new System.IO.FileInfo(fileadress_PC);
#elif UNITY_ANDROID
        System.IO.FileInfo file = new System.IO.FileInfo(fileadress_Android);
#endif
        if (!file.Exists)
        {
            StaticSaveList.UserName = "À×±©A";
            StaticSaveList.GoldCoin = 1000;
            StaticSaveList.Diamond = 1000;
            StaticSaveList.Quality = 2;
            StaticSaveList.Kuang1 = 0;
            StaticSaveList.Kuang2 = 0;
            StaticSaveList.X00001 = true;
            StaticSaveList.X00002 = StaticSaveList.X00003 = StaticSaveList.X00004 = StaticSaveList.X00005 = StaticSaveList.X00006 = StaticSaveList.X00007 = StaticSaveList.X00008 = StaticSaveList.X00009 = StaticSaveList.X00010
            = StaticSaveList.X00011 = StaticSaveList.X00012 = StaticSaveList.X00013 = StaticSaveList.X00014 = StaticSaveList.X00015 = StaticSaveList.X00016 = StaticSaveList.X00017 = StaticSaveList.X00018 = StaticSaveList.X00019 = StaticSaveList.X00020
            = StaticSaveList.X00021 = StaticSaveList.X00022 = StaticSaveList.X00023 = StaticSaveList.X00024 = StaticSaveList.X00025 = StaticSaveList.X00026 = StaticSaveList.X00027 = StaticSaveList.X00028 = StaticSaveList.X00029 = StaticSaveList.X00030
            = StaticSaveList.X00031 = StaticSaveList.X00032 = StaticSaveList.X00033 = StaticSaveList.X00034 = StaticSaveList.X00035 = StaticSaveList.X00036 = StaticSaveList.X00037 = StaticSaveList.X00038 = StaticSaveList.X00039 = StaticSaveList.X00040
            = StaticSaveList.X00041 = StaticSaveList.X00042 = StaticSaveList.X00043 = StaticSaveList.X00044 = StaticSaveList.X00045 = StaticSaveList.X00046 = StaticSaveList.X00047 = StaticSaveList.X00048 = StaticSaveList.X00049 = StaticSaveList.X00050
            = StaticSaveList.X00051 = StaticSaveList.X00052 = StaticSaveList.X00053 = StaticSaveList.X00054 = StaticSaveList.X00055 = StaticSaveList.X00056 = StaticSaveList.X00057 = StaticSaveList.X00058 = StaticSaveList.X00059 = false;
            QualitySettings.SetQualityLevel(StaticSaveList.Quality, true);
        }
        else
        {
#if UNITY_EDITOR
            System.IO.StreamReader streamReader = new System.IO.StreamReader(System.IO.Path.Combine(fileadress_PC));
#elif UNITY_ANDROID
            System.IO.StreamReader streamReader = new System.IO.StreamReader(System.IO.Path.Combine(fileadress_Android));
#endif
            string str = streamReader.ReadToEnd();
            JsonData Data = JsonMapper.ToObject(str);
            JsonData newsJson = Data;
            for (int i = 0; i < newsJson.Count; i++)
            {
                StaticSaveList.UserName = (string)newsJson[i]["UserName"];
                StaticSaveList.GoldCoin = (int)newsJson[i]["GoldCoin"];
                StaticSaveList.Diamond = (int)newsJson[i]["Diamond"];
                StaticSaveList.Quality = (int)newsJson[i]["Quality"];
                StaticSaveList.Kuang1 = (int)newsJson[i]["Kuang1"];
                StaticSaveList.Kuang2 = (int)newsJson[i]["Kuang2"];

                StaticSaveList.X00001 = (bool)newsJson[i]["X00001"];
                StaticSaveList.X00002 = (bool)newsJson[i]["X00002"];
                StaticSaveList.X00003 = (bool)newsJson[i]["X00003"];
                StaticSaveList.X00004 = (bool)newsJson[i]["X00004"];
                StaticSaveList.X00005 = (bool)newsJson[i]["X00005"];
                StaticSaveList.X00006 = (bool)newsJson[i]["X00006"];
                StaticSaveList.X00007 = (bool)newsJson[i]["X00007"];
                StaticSaveList.X00008 = (bool)newsJson[i]["X00008"];
                StaticSaveList.X00009 = (bool)newsJson[i]["X00009"];
                StaticSaveList.X00010 = (bool)newsJson[i]["X00010"];

                StaticSaveList.X00011 = (bool)newsJson[i]["X00011"];
                StaticSaveList.X00012 = (bool)newsJson[i]["X00012"];
                StaticSaveList.X00013 = (bool)newsJson[i]["X00013"];
                StaticSaveList.X00014 = (bool)newsJson[i]["X00014"];
                StaticSaveList.X00015 = (bool)newsJson[i]["X00015"];
                StaticSaveList.X00016 = (bool)newsJson[i]["X00016"];
                StaticSaveList.X00017 = (bool)newsJson[i]["X00017"];
                StaticSaveList.X00018 = (bool)newsJson[i]["X00018"];
                StaticSaveList.X00019 = (bool)newsJson[i]["X00019"];
                StaticSaveList.X00020 = (bool)newsJson[i]["X00020"];

                StaticSaveList.X00021 = (bool)newsJson[i]["X00021"];
                StaticSaveList.X00022 = (bool)newsJson[i]["X00022"];
                StaticSaveList.X00023 = (bool)newsJson[i]["X00023"];
                StaticSaveList.X00024 = (bool)newsJson[i]["X00024"];
                StaticSaveList.X00025 = (bool)newsJson[i]["X00025"];
                StaticSaveList.X00026 = (bool)newsJson[i]["X00026"];
                StaticSaveList.X00027 = (bool)newsJson[i]["X00027"];
                StaticSaveList.X00028 = (bool)newsJson[i]["X00028"];
                StaticSaveList.X00029 = (bool)newsJson[i]["X00029"];
                StaticSaveList.X00030 = (bool)newsJson[i]["X00030"];

                StaticSaveList.X00031 = (bool)newsJson[i]["X00031"];
                StaticSaveList.X00032 = (bool)newsJson[i]["X00032"];
                StaticSaveList.X00033 = (bool)newsJson[i]["X00033"];
                StaticSaveList.X00034 = (bool)newsJson[i]["X00034"];
                StaticSaveList.X00035 = (bool)newsJson[i]["X00035"];
                StaticSaveList.X00036 = (bool)newsJson[i]["X00036"];
                StaticSaveList.X00037 = (bool)newsJson[i]["X00037"];
                StaticSaveList.X00038 = (bool)newsJson[i]["X00038"];
                StaticSaveList.X00039 = (bool)newsJson[i]["X00039"];
                StaticSaveList.X00040 = (bool)newsJson[i]["X00040"];

                StaticSaveList.X00041 = (bool)newsJson[i]["X00041"];
                StaticSaveList.X00042 = (bool)newsJson[i]["X00042"];
                StaticSaveList.X00043 = (bool)newsJson[i]["X00043"];
                StaticSaveList.X00044 = (bool)newsJson[i]["X00044"];
                StaticSaveList.X00045 = (bool)newsJson[i]["X00045"];
                StaticSaveList.X00046 = (bool)newsJson[i]["X00046"];
                StaticSaveList.X00047 = (bool)newsJson[i]["X00047"];
                StaticSaveList.X00048 = (bool)newsJson[i]["X00048"];
                StaticSaveList.X00049 = (bool)newsJson[i]["X00049"];
                StaticSaveList.X00050 = (bool)newsJson[i]["X00050"];

                StaticSaveList.X00051 = (bool)newsJson[i]["X00051"];
                StaticSaveList.X00052 = (bool)newsJson[i]["X00052"];
                StaticSaveList.X00053 = (bool)newsJson[i]["X00053"];
                StaticSaveList.X00054 = (bool)newsJson[i]["X00054"];
                StaticSaveList.X00055 = (bool)newsJson[i]["X00055"];
                StaticSaveList.X00056 = (bool)newsJson[i]["X00056"];
                StaticSaveList.X00057 = (bool)newsJson[i]["X00057"];
                StaticSaveList.X00058 = (bool)newsJson[i]["X00058"];
                StaticSaveList.X00059 = (bool)newsJson[i]["X00059"];
            }
            QualitySettings.SetQualityLevel(StaticSaveList.Quality, true);
            if (StaticSaveList.Quality == 2)
            {
                GameObject.Find("Save").layer = 8;
            }
            else
            {
                GameObject.Find("Save").layer = 0;
            }
        }
        Write();
    }
    public static void Write()
    {
        string fileadress_PC = Application.dataPath + "/Save.json";
        string fileadress_Android = Application.persistentDataPath + "/Save.json";
#if UNITY_EDITOR
        System.IO.FileInfo file = new System.IO.FileInfo(fileadress_PC);
#elif UNITY_ANDROID
        System.IO.FileInfo file = new System.IO.FileInfo(fileadress_Android);
#endif
        file.Delete();
        file.Refresh();
        System.IO.StreamWriter sw = file.CreateText();
        string json = JsonMapper.ToJson(StaticSaveList);
        sw.WriteLine("[" + json + "]");
        sw.Close();
        sw.Dispose();
    }
}
