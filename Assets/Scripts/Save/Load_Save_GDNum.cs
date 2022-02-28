using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Load_Save_GDNum : MonoBehaviour
{
    private Text NumText;
    public bool IsGoldCoin;
    public void OnEnable()
    {
        NumText = this.gameObject.GetComponent<Text>();
        if (IsGoldCoin == true) { NumText.text = (Save_All.StaticSaveList.GoldCoin).ToString(); }
        else { NumText.text = (Save_All.StaticSaveList.Diamond).ToString(); }
    }
    public void QD_ADD()
    {
        if (IsGoldCoin == true) { Save_All.StaticSaveList.GoldCoin = Save_All.StaticSaveList.GoldCoin + 1000; NumText.text = (Save_All.StaticSaveList.GoldCoin).ToString(); }
        else { Save_All.StaticSaveList.Diamond = Save_All.StaticSaveList.Diamond + 1000; NumText.text = (Save_All.StaticSaveList.Diamond).ToString(); }
        Save_All.Write();
    }
}
