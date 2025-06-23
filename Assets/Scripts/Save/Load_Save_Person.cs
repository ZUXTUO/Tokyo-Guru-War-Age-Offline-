using UnityEngine;
using System.Reflection;

public class Load_Save_Person : MonoBehaviour
{
    public GameObject[] Person;

    public void OnEnable()
    {
        UpdatePersonStates();
    }

    private void UpdatePersonStates()
    {
        if (Save_All.StaticSaveList == null) return;

        FieldInfo[] fields = typeof(All_SaveList).GetFields();
        for (int i = 0; i < Person.Length && i < fields.Length; i++)
        {
            if (fields[i].Name.StartsWith("X000") && fields[i].FieldType == typeof(bool))
            {
                bool value = (bool)fields[i].GetValue(Save_All.StaticSaveList);
                Person[i].SetActive(value);
            }
        }
    }

    public void OutToSave()
    {
        Save_All.Write();
    }
}
