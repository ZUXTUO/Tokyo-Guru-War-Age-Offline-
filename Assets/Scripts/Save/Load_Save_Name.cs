using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Load_Save_Name : MonoBehaviour
{
    private Text UserName;
    public InputField[] ChangeNameText;
    private void OnEnable()
    {
        UserName = this.gameObject.GetComponent<Text>();
        UserName.text = Save_All.StaticSaveList.UserName;
    }
    public void ResetName()
    {
        Save_All.StaticSaveList.UserName = ChangeNameText[0].text;
        UserName.text = Save_All.StaticSaveList.UserName;
        Save_All.Write();
    }
}
