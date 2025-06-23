using UnityEngine;
using System.IO;
using LitJson;
using System.Reflection;
using System.Collections; // Required for IDictionary

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
        DontDestroyOnLoad(gameObject);
        Read();
    }

    private static string GetSaveFilePath()
    {
#if UNITY_EDITOR
        return Path.Combine(Application.dataPath, "Save.json");
#elif UNITY_ANDROID
        return Path.Combine(Application.persistentDataPath, "Save.json");
#else
        return Path.Combine(Application.persistentDataPath, "Save.json");
#endif
    }

    public static void Read()
    {
        string filePath = GetSaveFilePath();

        if (!File.Exists(filePath))
        {
            InitializeDefaultSaveList();
        }
        else
        {
            LoadSaveData(filePath);
        }
        ApplyQualitySettings();
        Write(); // Write after read to ensure consistency or write defaults if file didn't exist
    }

    public static void Write()
    {
        string filePath = GetSaveFilePath();
        try
        {
            string json = JsonMapper.ToJson(StaticSaveList);
            // Use File.WriteAllText which automatically creates/overwrites the file
            // and handles closing the stream, preventing file in use errors.
            File.WriteAllText(filePath, "[" + json + "]");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to write save file: " + e.Message);
        }
    }

    private static void InitializeDefaultSaveList()
    {
        StaticSaveList.UserName = "À×±©A";
        StaticSaveList.GoldCoin = 1000;
        StaticSaveList.Diamond = 1000;
        StaticSaveList.Quality = 2;
        StaticSaveList.Kuang1 = 0;
        StaticSaveList.Kuang2 = 0;

        FieldInfo[] fields = typeof(All_SaveList).GetFields();
        foreach (FieldInfo field in fields)
        {
            if (field.Name.StartsWith("X000") && field.FieldType == typeof(bool))
            {
                field.SetValue(StaticSaveList, false);
            }
        }
        StaticSaveList.X00001 = true;
    }

    private static void LoadSaveData(string filePath)
    {
        try
        {
            // Use 'using' to ensure the StreamReader is properly disposed,
            // releasing the file handle immediately after reading.
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string str = streamReader.ReadToEnd();
                JsonData data = JsonMapper.ToObject(str);
                if (data != null && data.IsArray && data.Count > 0)
                {
                    JsonData newsJson = data[0];

                    StaticSaveList.UserName = (string)newsJson["UserName"];
                    StaticSaveList.GoldCoin = (int)newsJson["GoldCoin"];
                    StaticSaveList.Diamond = (int)newsJson["Diamond"];
                    StaticSaveList.Quality = (int)newsJson["Quality"];
                    StaticSaveList.Kuang1 = (int)newsJson["Kuang1"];
                    StaticSaveList.Kuang2 = (int)newsJson["Kuang2"];

                    FieldInfo[] fields = typeof(All_SaveList).GetFields();
                    if (newsJson.IsObject)
                    {
                        var jsonObjectAsDict = (IDictionary)newsJson;
                        foreach (FieldInfo field in fields)
                        {
                            if (field.Name.StartsWith("X000") && field.FieldType == typeof(bool) && jsonObjectAsDict.Contains(field.Name))
                            {
                                field.SetValue(StaticSaveList, (bool)newsJson[field.Name]);
                            }
                        }
                    }
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to read save file: " + e.Message);
            InitializeDefaultSaveList();
        }
    }

    private static void ApplyQualitySettings()
    {
        QualitySettings.SetQualityLevel(StaticSaveList.Quality, true);
        GameObject saveObject = GameObject.Find("Save");
        if (saveObject != null)
        {
            saveObject.layer = (StaticSaveList.Quality == 2) ? 8 : 0;
        }
    }
}
