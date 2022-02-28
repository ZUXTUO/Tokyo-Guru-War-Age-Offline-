using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QianDao : MonoBehaviour
{
    public const string SignNumPrefs = "SignNum";
    public const string SignDataPrefs = "SignData";
    public int signNum;//签到次数
    public DateTime today;//今日日期
    public DateTime signData;//上次签到日期
    IEnumerator Start()
    {
        WWW www = new WWW("http://www.hko.gov.hk/cgi-bin/gts/time5a.pr?a=1");
        while (!www.isDone)
        {
            //防止加载失败
            yield return www;
        }
        if (www.text == "" || www.text.Trim() == "")//如果获取网络时间失败,改为获取系统时间
        {
            today = DateTime.Now;
        }
        else//成功获取网络时间
        {
            string timeStr = www.text.Substring(2);
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            //time = startTime.AddMilliseconds(Convert.ToDouble(timeStr));
            timeStr = time.ToString();
            today = DateTime.Parse(timeStr);
        }
        signNum = PlayerPrefs.GetInt(SignNumPrefs, 0);
        signData = DateTime.Parse(PlayerPrefs.GetString(SignDataPrefs, DateTime.MinValue.ToString()));
        RefreshView();//刷新签到面板
    }
    //签到领取奖励
    public void OnSignClick(int index)
    {
        if (IsOneDay() && signNum == index)
        {
            signNum++;
            signData = today;
            Debug.Log("执行了");
            PlayerPrefs.SetString(SignDataPrefs, today.ToString());
            PlayerPrefs.SetInt(SignNumPrefs, signNum);
            RefreshView();
            UserGift(); //给用户奖励
            if (signNum >= 7)//重新计算签到
            {
                PlayerPrefs.DeleteKey(SignNumPrefs);
            }
        }
        else
        {
            //签到日期未到
        }
    }
    //视图刷新方法
    void RefreshView()
    {

    }
    //判断是否可以签到
    private bool IsOneDay()
    {
        if (signData.Year == today.Year && signData.Month == today.Month && signData.Day == today.Day)
        {
            return false;
        }
        if (DateTime.Compare(signData, today) < 0)
        {
            return true;
        }
        return false;
    }
    //签到奖励
    void UserGift()
    {

    }

}