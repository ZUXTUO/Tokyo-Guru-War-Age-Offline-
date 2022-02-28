using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZhaoMu : MonoBehaviour
{
    public GameObject JinMu, JinMuJueXing, JinMuWuGong, YaMen, YouMa, DongXiang_PuTong,
        ChuShi, LingWuShiZao, NaiBai, HeiNai, TMDX, CSWZ, XiWeiJin, YueShanXi, Xiao, DuYanXiao,
        NaJi, WuDaoXunDu, ShenDaiLiShi, BiHu, TaiLang, LiangZi, YingLiang, SiFang, GuJianYuanEr, MoYuan, DuBin, DuoDuoLiang;
    public int GaiLv;
    public GameObject JieSuo;
    public Text G, D;
    /// <summary>
    /// B
    /// </summary>
    public void B_ChouJiang()
    {
        Wu();
        Save_All.StaticSaveList.GoldCoin = Save_All.StaticSaveList.GoldCoin - 1000;
        G.text = Save_All.StaticSaveList.GoldCoin.ToString();
        GaiLv = Random.Range(500, 1000);
        if (GaiLv > 940 && GaiLv <= 1000)
        {
            YaMen.SetActive(true);
            Save_All.StaticSaveList.X00004 = true;
            //Save_JueSe_YaMen.YaMen = 1;
        }
        else if (GaiLv > 890 && GaiLv <= 940)
        {
            DongXiang_PuTong.SetActive(true);
            Save_All.StaticSaveList.X00006 = true;
            //Save_JueSe_DongXiang_PuTong.DongXiang = 1;
        }
        else if (GaiLv > 830 && GaiLv <= 890)
        {
            ChuShi.SetActive(true);
            Save_All.StaticSaveList.X00007 = true;
            //Save_JueSe_ChuShi.ChuShi = 1;
        }
        else if (GaiLv > 827 && GaiLv <= 830)
        {
            LingWuShiZao.SetActive(true);
            Save_All.StaticSaveList.X00008 = true;
            //Save_JueSe_ShiZao.ShiZao = 1;
        }
        else if (GaiLv > 817 && GaiLv <= 827)
        {
            NaiBai.SetActive(true);
            Save_All.StaticSaveList.X00009 = true;
            //Save_JueSe_NaiBai.NaiBai = 1;
        }
        else if (GaiLv > 807 && GaiLv <= 817)
        {
            HeiNai.SetActive(true);
            Save_All.StaticSaveList.X00010 = true;
            //Save_JueSe_HeiNai.HeiNai = 1;
        }
        else if (GaiLv > 802 && GaiLv <= 807)
        {
            CSWZ.SetActive(true);
            Save_All.StaticSaveList.X00012 = true;
            //Save_JueSe_CSWZ.CSWZ = 1;
        }
        else if (GaiLv > 742 && GaiLv <= 802)
        {
            XiWeiJin.SetActive(true);
            Save_All.StaticSaveList.X00013 = true;
            //Save_JueSe_XiWeiJin.XiWeiJin = 1;
        }
        else if (GaiLv > 702 && GaiLv <= 742)
        {
            YueShanXi.SetActive(true);
            Save_All.StaticSaveList.X00014 = true;
            //Save_JueSe_YueShanXi.YueShanXi = 1;
        }
        else if (GaiLv > 682 && GaiLv <= 702)
        {
            NaJi.SetActive(true);
            Save_All.StaticSaveList.X00017 = true;
            //Save_JueSe_NaJi.NaJi = 1;
        }
        else if (GaiLv > 672 && GaiLv <= 682)
        {
            WuDaoXunDu.SetActive(true);
            Save_All.StaticSaveList.X00018 = true;
            //Save_JueSe_XunDu.XunDu = 1;
        }
        else if (GaiLv > 602 && GaiLv <= 672)
        {
            TaiLang.SetActive(true);
            Save_All.StaticSaveList.X00021 = true;
            //Save_JueSe_TaiLang.TaiLang = 1;
        }
        else if (GaiLv > 552 && GaiLv <= 602)
        {
            LiangZi.SetActive(true);
            Save_All.StaticSaveList.X00022 = true;
            //Save_JueSe_LiangZi.LiangZi = 1;
        }
        else
        {
            Wu();
        }
    }
    /// <summary>
    /// S
    /// </summary>
    public void S_ChouJiang()
    {
        Wu();
        //JianShaoZuanShi = 1000;
        Save_All.StaticSaveList.Diamond = Save_All.StaticSaveList.Diamond - 1000;
        D.text = Save_All.StaticSaveList.Diamond.ToString();
        GaiLv = Random.Range(400, 1000);
        if (GaiLv > 970 && GaiLv <= 1000)
        {
            JieSuo.SetActive(false);
            JinMuJueXing.SetActive(true);
            //JueSeJieSuo_BFJM.SetActive(true);
            Save_All.StaticSaveList.X00002 = true;
            //Save_JueSe_BFJM.BFJM = 1;
        }
        else if (GaiLv == 970)
        {
            YouMa.SetActive(true);
            //JueSeJieSuo_YouMa.SetActive(true);
            Save_All.StaticSaveList.X00005 = true;
            //Save_JueSe_YOUMA.YouMa = 1;
        }
        else if (GaiLv == 969)
        {
            JinMuWuGong.SetActive(true);
            //JueSeJieSuo_WGJM.SetActive(true);
            Save_All.StaticSaveList.X00003 = true;
            //Save_JueSe_WGJM.WGJM = 1;
        }
        else if (GaiLv >= 919 && GaiLv < 969)
        {
            DongXiang_PuTong.SetActive(true);
            //JueSeJieSuo_DongXiang_PuTong.SetActive(true);
            Save_All.StaticSaveList.X00006 = true;
            //Save_JueSe_DongXiang_PuTong.DongXiang = 1;
        }
        else if (GaiLv >= 859 && GaiLv < 919)
        {
            YaMen.SetActive(true);
            //JueSeJieSuo_YaMen.SetActive(true);
            Save_All.StaticSaveList.X00004 = true;
            //Save_JueSe_YaMen.YaMen = 1;
        }
        else if (GaiLv >= 799 && GaiLv < 859)
        {
            ChuShi.SetActive(true);
            //JueSeJieSuo_ChuShi.SetActive(true);
            Save_All.StaticSaveList.X00007 = true;
            //Save_JueSe_ChuShi.ChuShi = 1;
        }
        else if (GaiLv >= 796 && GaiLv < 799)
        {
            LingWuShiZao.SetActive(true);
            //JueSeJieSuo_LingWuShiZao.SetActive(true);
            Save_All.StaticSaveList.X00008 = true;
            //Save_JueSe_ShiZao.ShiZao = 1;
        }
        else if (GaiLv >= 786 && GaiLv < 796)
        {
            NaiBai.SetActive(true);
            //JueSeJieSuo_NaiBai.SetActive(true);
            Save_All.StaticSaveList.X00009 = true;
            //Save_JueSe_NaiBai.NaiBai = 1;
        }
        else if (GaiLv >= 776 && GaiLv < 786)
        {
            HeiNai.SetActive(true);
            //JueSeJieSuo_HeiNai.SetActive(true);
            Save_All.StaticSaveList.X00010 = true;
            //Save_JueSe_HeiNai.HeiNai = 1;
        }
        else if (GaiLv >= 774 && GaiLv < 776)
        {
            TMDX.SetActive(true);
            //JueSeJieSuo_TMDX.SetActive(true);
            Save_All.StaticSaveList.X00011 = true;
            //Save_JueSe_TMDX.TMDX = 1;
        }
        else if (GaiLv >= 769 && GaiLv < 774)
        {
            CSWZ.SetActive(true);
            //JueSeJieSuo_CSWZ.SetActive(true);
            Save_All.StaticSaveList.X00012 = true;
            //Save_JueSe_CSWZ.CSWZ = 1;
        }
        else if (GaiLv >= 709 && GaiLv < 769)
        {
            XiWeiJin.SetActive(true);
            //JueSeJieSuo_XiWeiJin.SetActive(true);
            Save_All.StaticSaveList.X00013 = true;
            //Save_JueSe_XiWeiJin.XiWeiJin = 1;
        }
        else if (GaiLv >= 669 && GaiLv < 709)
        {
            YueShanXi.SetActive(true);
            //JueSeJieSuo_YueShanXi.SetActive(true);
            Save_All.StaticSaveList.X00014 = true;
            //Save_JueSe_YueShanXi.YueShanXi = 1;
        }
        else if (GaiLv >= 668 && GaiLv < 669)
        {
            Xiao.SetActive(true);
            //JueSeJieSuo_Xiao.SetActive(true);
            Save_All.StaticSaveList.X00015 = true;
            //Save_JueSe_Xiao.Xiao = 1;
        }
        else if (GaiLv >= 667 && GaiLv < 668)
        {
            DuYanXiao.SetActive(true);
            //JueSeJieSuo_DuYanXiao.SetActive(true);
            Save_All.StaticSaveList.X00016 = true;
            //Save_JueSe_DuYanXiao.DuYanXiao = 1;
        }
        else if (GaiLv >= 647 && GaiLv < 667)
        {
            NaJi.SetActive(true);
            //JueSeJieSuo_NaJi.SetActive(true);
            Save_All.StaticSaveList.X00017 = true;
            //Save_JueSe_NaJi.NaJi = 1;
        }
        else if (GaiLv >= 637 && GaiLv < 647)
        {
            WuDaoXunDu.SetActive(true);
            //JueSeJieSuo_WuDaoXunDu.SetActive(true);
            Save_All.StaticSaveList.X00018 = true;
            //Save_JueSe_XunDu.XunDu = 1;
        }
        else if (GaiLv >= 567 && GaiLv < 637)
        {
            TaiLang.SetActive(true);
            //JueSeJieSuo_TaiLang.SetActive(true);
            Save_All.StaticSaveList.X00021 = true;
            //Save_JueSe_TaiLang.TaiLang = 1;
        }
        else if (GaiLv >= 517 && GaiLv < 567)
        {
            LiangZi.SetActive(true);
            //JueSeJieSuo_DiKouLiangZi.SetActive(true);
            Save_All.StaticSaveList.X00022 = true;
            //Save_JueSe_LiangZi.LiangZi = 1;
        }
        else if (GaiLv >= 487 && GaiLv < 517)
        {
            YingLiang.SetActive(true);
            //JueSeJieSuo_YingLiang.SetActive(true);
            Save_All.StaticSaveList.X00023 = true;
            //Save_JueSe_YingLiang.YingLiang = 1;
        }
        else if (GaiLv >= 467 && GaiLv < 487)
        {
            SiFang.SetActive(true);
            //JueSeJieSuo_SiFang.SetActive(true);
            Save_All.StaticSaveList.X00024 = true;
            //Save_JueSe_LianShi.LianShi = 1;
        }
        else if (GaiLv >= 447 && GaiLv < 467)
        {
            GuJianYuanEr.SetActive(true);
            //JueSeJieSuo_GuJianYuanEr.SetActive(true);
            Save_All.StaticSaveList.X00027 = true;
            //Save_JueSe_GuJian.GuJian = 1;
        }
        else if (GaiLv >= 437 && GaiLv < 447)
        {
            MoYuan.SetActive(true);
            //JueSeJieSuo_MoYuan.SetActive(true);
            Save_All.StaticSaveList.X00028 = true;
            //Save_JueSe_MoYuan.MoYuan = 1;
        }
        else if (GaiLv >= 427 && GaiLv < 437)
        {
            DuBin.SetActive(true);
            //JueSeJieSuo_DuBin.SetActive(true);
            Save_All.StaticSaveList.X00030 = true;
            //Save_JueSe_HeiGou.HeiGou = 1;
        }
        else if (GaiLv >= 425 && GaiLv < 427)
        {
            DuoDuoLiang.SetActive(true);
            //JueSeJieSuo_DuoDuoLiang.SetActive(true);
            Save_All.StaticSaveList.X00032 = true;
            //Save_JueSe_Duo.Duo = 1;
        }
        else
        {
            JinMu.SetActive(true);
        }
    }
    void Wu()
    {
        JinMu.SetActive(false);
        JinMuJueXing.SetActive(false);
        JinMuWuGong.SetActive(false);
        YaMen.SetActive(false);
        YouMa.SetActive(false);
        DongXiang_PuTong.SetActive(false);
        ChuShi.SetActive(false);
        LingWuShiZao.SetActive(false);
        NaiBai.SetActive(false);
        HeiNai.SetActive(false);
        TMDX.SetActive(false);
        CSWZ.SetActive(false);
        XiWeiJin.SetActive(false);
        YueShanXi.SetActive(false);
        Xiao.SetActive(false);
        DuYanXiao.SetActive(false);
        NaJi.SetActive(false);
        WuDaoXunDu.SetActive(false);
        TaiLang.SetActive(false);
        LiangZi.SetActive(false);
        YingLiang.SetActive(false);
        SiFang.SetActive(false);
        GuJianYuanEr.SetActive(false);
        MoYuan.SetActive(false);
        DuBin.SetActive(false);
        DuoDuoLiang.SetActive(false);
    }
}
