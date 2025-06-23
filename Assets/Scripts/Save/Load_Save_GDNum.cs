using UnityEngine;
using UnityEngine.UI;

public class Load_Save_GDNum : MonoBehaviour
{
    private Text NumText;
    public bool IsGoldCoin;

    public void OnEnable()
    {
        NumText = GetComponent<Text>();
        UpdateText();
    }

    public void QD_ADD()
    {
        if (IsGoldCoin)
        {
            Save_All.StaticSaveList.GoldCoin += 1000;
        }
        else
        {
            Save_All.StaticSaveList.Diamond += 1000;
        }
        UpdateText();
        Save_All.Write();
    }

    private void UpdateText()
    {
        NumText.text = IsGoldCoin ? Save_All.StaticSaveList.GoldCoin.ToString() : Save_All.StaticSaveList.Diamond.ToString();
    }
}