using UnityEngine;
using System.Collections;
public class Global : MonoBehaviour
{
    private static Global instance;
    public static Global GetInstance()
    {
        if (instance == null)
        {
            instance = new Global();
        }
        return instance;
    }
    public string loadName = Loading.Sce;
}