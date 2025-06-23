using System;
using UnityEngine;

public class QianDao : MonoBehaviour
{
    public const string SignNumPrefs = "SignNum";
    public const string SignDataPrefs = "SignData";
    public int signNum; // 签到次数
    public DateTime today; // 今日日期
    public DateTime signData; // 上次签到日期

    void Start()
    {
        // 直接获取本地时间
        today = DateTime.Now;

        // 从 PlayerPrefs 读取签到数据，如果不存在则使用默认值
        signNum = PlayerPrefs.GetInt(SignNumPrefs, 0);

        // 尝试解析上次签到日期，如果字符串为空或无效，则使用 DateTime.MinValue
        string lastSignDateStr = PlayerPrefs.GetString(SignDataPrefs, DateTime.MinValue.ToString());
        if (DateTime.TryParse(lastSignDateStr, out DateTime parsedSignData))
        {
            signData = parsedSignData;
        }
        else
        {
            signData = DateTime.MinValue; // 解析失败，设置为最小值
        }

        RefreshView(); // 刷新签到面板
    }

    // 签到领取奖励
    public void OnSignClick(int index)
    {
        // 确保签到索引匹配且符合签到条件
        if (IsOneDay() && signNum == index)
        {
            signNum++;
            signData = today; // 更新签到日期为今天

            Debug.Log("执行了"); // Debug message for execution

            // 保存新的签到次数和签到日期
            PlayerPrefs.SetString(SignDataPrefs, today.ToString());
            PlayerPrefs.SetInt(SignNumPrefs, signNum);

            RefreshView(); // 刷新签到面板
            UserGift(); // 给用户奖励

            // 如果签到次数达到或超过7天，重置签到记录
            if (signNum >= 7)
            {
                PlayerPrefs.DeleteKey(SignNumPrefs);
                PlayerPrefs.DeleteKey(SignDataPrefs); // 也删除签到日期，确保下次重新开始
                signNum = 0; // 重置签到次数
                signData = DateTime.MinValue; // 重置签到日期
            }
        }
        else
        {
            // 签到日期未到或索引不匹配
            Debug.Log("签到条件不满足。当前签到次数: " + signNum + ", 期望索引: " + index + ", 是否已签到: " + !IsOneDay());
        }
    }

    // 视图刷新方法 (需要根据实际UI进行实现)
    void RefreshView()
    {
        // 这里是刷新UI的逻辑，例如更新签到按钮的状态、显示奖励等
        // 通常会遍历签到天数对应的UI元素，根据 signNum 来设置其状态
        Debug.Log("刷新签到面板。当前签到次数: " + signNum + ", 上次签到日期: " + signData.ToShortDateString());
    }

    // 判断是否可以签到
    private bool IsOneDay()
    {
        // 如果上次签到日期是今天，则不能再次签到（返回false）
        if (signData.Year == today.Year && signData.Month == today.Month && signData.Day == today.Day)
        {
            return false;
        }
        // 如果上次签到日期早于今天，则可以签到（返回true）
        // 这里使用日期比较，忽略时间部分
        if (DateTime.Compare(signData.Date, today.Date) < 0)
        {
            return true;
        }
        return false; // 其他情况（例如signData在today之后，虽然理论上不应发生）
    }

    // 签到奖励 (需要根据实际奖励逻辑进行实现)
    void UserGift()
    {
        // 这里是发放签到奖励的逻辑
        Debug.Log("发放签到奖励。当前签到次数: " + signNum);
        // 例如：Save_All.StaticSaveList.GoldCoin += 100; Save_All.Write();
    }
}
