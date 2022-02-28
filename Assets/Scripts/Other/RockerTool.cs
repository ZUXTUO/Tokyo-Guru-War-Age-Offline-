using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockerTool : MonoBehaviour
{
    public float W;
    public Image rocker;
    private Vector3 beginPos;
    private PlayerController controller;
    private Animator Anim;
    public int HitCount = 0;
    public AnimatorStateInfo _animatorInfo;
    public bool On = false;
    public bool SkillOn = false;
    public bool Skill_1 = false;
    public bool Skill_2 = false;
    public bool Skill_3 = false;
    public bool Skill_IDLE = false;
    public bool Skill_WALK = false;
    public Image Skill_black_1;
    public Image Skill_black_2;
    public Image Skill_black_3;
    public GameObject Skill_1_obj;
    public GameObject Skill_2_obj;
    public GameObject Skill_3_obj;
    public GameObject Skill_1_obj_black;
    public GameObject Skill_2_obj_black;
    public GameObject Skill_3_obj_black;
    public float Skill_1_time = 3f;
    public float Skill_2_time = 5f;
    public float Skill_3_time = 10f;
    public float timer_one = 0f;
    public float timer_two = 0f;
    public float timer_three = 0f;
    public bool IsSkill_1;
    public bool IsSkill_2;
    public bool IsSkill_3;
    void Start()
    {
        IsSkill_1 = false;
        IsSkill_2 = false;
        IsSkill_3 = false;
        W = Screen.width;
        rocker.transform.parent.gameObject.SetActive(false);
        controller = FindObjectOfType<PlayerController>();
        Anim = GetComponent<Animator>();
        //Skill_black_1 = transform.Find("FillImage").GetComponent<Image>();
        //Skill_black_2 = transform.Find("FillImage").GetComponent<Image>();
        //Skill_black_3 = transform.Find("FillImage").GetComponent<Image>();
    }

    private void Update()
    {
        Rocker();
        if (Skill_IDLE) { Skill_End_Idle(); }
        Skill_ColdTime();
    }
    public void Skill_ColdTime()
    {
        if (IsSkill_1)
        {
            timer_one += Time.deltaTime;
            Skill_black_1.fillAmount = (Skill_1_time - timer_one) / Skill_1_time;//按照时间比例显示图片，刚开始点击时，timer小，应该显示的背景图大
            if (timer_one >= Skill_1_time)//判断是否达到冷却时间
            {
                Skill_black_1.fillAmount = 0;//冷却图不显示
                timer_one = 0;//重置计时器
                IsSkill_1 = false;//结束计时
                Skill_1_obj.SetActive(true);
                Skill_1_obj_black.SetActive(false);
            }
        }
        if (IsSkill_2)
        {
            timer_two += Time.deltaTime;
            Skill_black_2.fillAmount = (Skill_2_time - timer_two) / Skill_2_time;//按照时间比例显示图片，刚开始点击时，timer小，应该显示的背景图大
            if (timer_two >= Skill_2_time)//判断是否达到冷却时间
            {
                Skill_black_2.fillAmount = 0;//冷却图不显示
                timer_two = 0;//重置计时器
                IsSkill_2 = false;//结束计时
                Skill_2_obj.SetActive(true);
                Skill_2_obj_black.SetActive(false);
            }
        }
        if (IsSkill_3)
        {
            timer_three += Time.deltaTime;
            Skill_black_3.fillAmount = (Skill_3_time - timer_three) / Skill_3_time;//按照时间比例显示图片，刚开始点击时，timer小，应该显示的背景图大
            if (timer_three >= Skill_3_time)//判断是否达到冷却时间
            {
                Skill_black_3.fillAmount = 0;//冷却图不显示
                timer_three = 0;//重置计时器
                IsSkill_3 = false;//结束计时
                Skill_3_obj.SetActive(true);
                Skill_3_obj_black.SetActive(false);
            }
        }
    }
    public void Skill_End_Idle()
    {
        if (Skill_1)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("skill01") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                Skill_On_Idle();
            }
        }
        if (Skill_2)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("skill02") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                Skill_On_Idle();
            }
        }
        if (Skill_3)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("skill01") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                Skill_On_Idle();
            }
        }
        On = false;
    }
    public void Skill_End_Walk()
    {
        if (Skill_1)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("skill01") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                Skill_On_Walk();
            }
        }
        if (Skill_2)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("skill02") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 00.8f)
            {
                Skill_On_Walk();
            }
        }
        if (Skill_3)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("skill01") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                Skill_On_Walk();
            }
        }
        On = false;
    }
    public void Rocker()
    {
        if (Input.mousePosition.x < W / 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Anim.SetBool("ACT_1", false);
                Anim.SetBool("ACT_2", false);
                Anim.SetBool("ACT_3", false);
                Anim.SetBool("ACT_4", false);
                Anim.SetBool("ACT_5", false);
                Anim.SetBool("IDLE", false);
                Anim.SetBool("WALK", true);
                Anim.SetBool("SKILL_1", false);
                Anim.SetBool("SKILL_2", false);
                Anim.SetBool("SKILL_3", false);
                HitCount = 0;
                rocker.transform.parent.gameObject.SetActive(true);
                beginPos = Input.mousePosition;
                rocker.transform.parent.transform.position = beginPos;
            }
            else if (Input.GetMouseButton(0))
            {
                Anim.SetBool("ACT_1", false);
                Anim.SetBool("ACT_2", false);
                Anim.SetBool("ACT_3", false);
                Anim.SetBool("ACT_4", false);
                Anim.SetBool("ACT_5", false);
                Anim.SetBool("IDLE", false);
                Anim.SetBool("WALK", true);
                Anim.SetBool("SKILL_1", false);
                Anim.SetBool("SKILL_2", false);
                Anim.SetBool("SKILL_3", false);
                Vector3 vector = Input.mousePosition - beginPos;
                vector = vector.normalized;
                rocker.transform.localPosition = Mathf.Clamp(Vector3.Distance(beginPos, Input.mousePosition), 0, 120f) * vector;
                controller.Move(new Vector3(Mathf.Cos(-45) * vector.x + Mathf.Sin(-45) * vector.y, 0, Mathf.Sin(45) * vector.x + Mathf.Cos(45) * vector.y));
            }
            else if (Input.GetMouseButtonUp(0))
            {
                Anim.SetBool("ACT_1", false);
                Anim.SetBool("ACT_2", false);
                Anim.SetBool("ACT_3", false);
                Anim.SetBool("ACT_4", false);
                Anim.SetBool("ACT_5", false);
                Anim.SetBool("IDLE", true);
                Anim.SetBool("WALK", false);
                beginPos = Vector3.zero;
                rocker.transform.localPosition = Vector3.zero;
                rocker.transform.parent.gameObject.SetActive(false);
            }
        }
        if (SkillOn)
        {
            if (Anim.GetCurrentAnimatorStateInfo(0).IsName("attack01") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f && HitCount == 1)
            {
                Anim.SetBool("ACT_1", false);
                Anim.SetBool("ACT_2", true);
                Anim.SetBool("ACT_3", false);
                Anim.SetBool("ACT_4", false);
                Anim.SetBool("ACT_5", false);
                Anim.SetBool("IDLE", false);
                Anim.SetBool("WALK", false);
                HitCount = 2;
            }
            else if (Anim.GetCurrentAnimatorStateInfo(0).IsName("attack02") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f && HitCount == 2)
            {
                Anim.SetBool("ACT_1", false);
                Anim.SetBool("ACT_2", false);
                Anim.SetBool("ACT_3", true);
                Anim.SetBool("ACT_4", false);
                Anim.SetBool("ACT_5", false);
                Anim.SetBool("IDLE", false);
                Anim.SetBool("WALK", false);
                HitCount = 3;
            }
            else if (Anim.GetCurrentAnimatorStateInfo(0).IsName("attack03") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f && HitCount == 3)
            {
                Anim.SetBool("ACT_1", false);
                Anim.SetBool("ACT_2", false);
                Anim.SetBool("ACT_3", false);
                Anim.SetBool("ACT_4", true);
                Anim.SetBool("ACT_5", false);
                Anim.SetBool("IDLE", false);
                Anim.SetBool("WALK", false);
                HitCount = 4;
            }
            else if (Anim.GetCurrentAnimatorStateInfo(0).IsName("attack04") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f && HitCount == 4)
            {
                Anim.SetBool("ACT_1", false);
                Anim.SetBool("ACT_2", false);
                Anim.SetBool("ACT_3", false);
                Anim.SetBool("ACT_4", false);
                Anim.SetBool("ACT_5", true);
                Anim.SetBool("IDLE", false);
                Anim.SetBool("WALK", false);
                HitCount = 5;
            }
            else if (Anim.GetCurrentAnimatorStateInfo(0).IsName("attack05") && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f && HitCount == 5)
            {
                Anim.SetBool("ACT_1", true);
                Anim.SetBool("ACT_2", false);
                Anim.SetBool("ACT_3", false);
                Anim.SetBool("ACT_4", false);
                Anim.SetBool("ACT_5", false);
                Anim.SetBool("IDLE", false);
                Anim.SetBool("WALK", false);
                HitCount = 0;
                Anim.Play("attack01", 0, 0f);
            }
            else
            {
                if ((Anim.GetCurrentAnimatorStateInfo(0).IsName("attack01") || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack02") || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack03") || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack04") || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack05")) && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
                {
                    Anim.SetBool("ACT_1", false);
                    Anim.SetBool("ACT_2", false);
                    Anim.SetBool("ACT_3", false);
                    Anim.SetBool("ACT_4", false);
                    Anim.SetBool("ACT_5", false);
                    Anim.SetBool("IDLE", true);
                    Anim.SetBool("WALK", false);
                    HitCount = 0;
                    On = false;
                }
            }
        }
        else if ((Anim.GetCurrentAnimatorStateInfo(0).IsName("attack01")
            || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack02")
            || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack03")
            || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack04")
            || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack05")
            || Anim.GetCurrentAnimatorStateInfo(0).IsName("skill01")
            || Anim.GetCurrentAnimatorStateInfo(0).IsName("skill02")
            || Anim.GetCurrentAnimatorStateInfo(0).IsName("skill03")) && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            Anim.SetBool("ACT_1", false);
            Anim.SetBool("ACT_2", false);
            Anim.SetBool("ACT_3", false);
            Anim.SetBool("ACT_4", false);
            Anim.SetBool("ACT_5", false);
            Anim.SetBool("SKILL_1", false);
            Anim.SetBool("SKILL_2", false);
            Anim.SetBool("SKILL_3", false);
            Anim.SetBool("IDLE", true);
            Anim.SetBool("WALK", false);
            HitCount = 0;
            On = false;
        }
    }
    public void OnClick()
    {
        if (On)
        {
            if ((Anim.GetCurrentAnimatorStateInfo(0).IsName("attack01") || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack02") || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack03") || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack04") || Anim.GetCurrentAnimatorStateInfo(0).IsName("attack05")) && Anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.8f)
            {
                HitCountOn();
                On = false;
                SkillOn = true;
            }
        }
        else
        {
            HitCountOn();
            SkillOn = false;
            Skill_1 = false;
            Skill_2 = false;
            Skill_3 = false;
            Skill_IDLE = false;
            Skill_WALK = false;
        }
    }
    public void HitCountOn()
    {
        On = true;
        if ((Anim.GetCurrentAnimatorStateInfo(0).IsName("stand") || Anim.GetCurrentAnimatorStateInfo(0).IsName("walk")) && HitCount == 0)
        {
            Anim.Play("attack01", 0, 0f);
            Anim.SetBool("ACT_1", true);
            Anim.SetBool("ACT_2", false);
            Anim.SetBool("ACT_3", false);
            Anim.SetBool("ACT_4", false);
            Anim.SetBool("ACT_5", false);
            Anim.SetBool("IDLE", false);
            Anim.SetBool("WALK", false);
            HitCount = 1;
            SkillOn = true;
        }
    }
    public void SKILL_1()
    {
        IsSkill_1 = true;
        Skill_IDLE = true;
        Skill_1 = true;
        Skill_2 = false;
        Skill_3 = false;
        Anim.SetBool("ACT_1", false);
        Anim.SetBool("ACT_2", false);
        Anim.SetBool("ACT_3", false);
        Anim.SetBool("ACT_4", false);
        Anim.SetBool("ACT_5", false);
        Anim.SetBool("IDLE", false);
        Anim.SetBool("WALK", false);
        Anim.SetBool("SKILL_1", true);
        Anim.SetBool("SKILL_2", false);
        Anim.SetBool("SKILL_3", false);
        On = false;
        SkillOn = false;
        HitCount = 0;
    }
    public void SKILL_2()
    {
        IsSkill_2 = true;
        Skill_IDLE = true;
        Skill_1 = false;
        Skill_2 = true;
        Skill_3 = false;
        Anim.SetBool("ACT_1", false);
        Anim.SetBool("ACT_2", false);
        Anim.SetBool("ACT_3", false);
        Anim.SetBool("ACT_4", false);
        Anim.SetBool("ACT_5", false);
        Anim.SetBool("IDLE", false);
        Anim.SetBool("WALK", false);
        Anim.SetBool("SKILL_1", false);
        Anim.SetBool("SKILL_2", true);
        Anim.SetBool("SKILL_3", false);
        On = false;
        SkillOn = false;
        HitCount = 0;
    }
    public void SKILL_3()
    {
        IsSkill_3 = true;
        Skill_IDLE = true;
        Skill_1 = false;
        Skill_2 = false;
        Skill_3 = true;
        Anim.SetBool("ACT_1", false);
        Anim.SetBool("ACT_2", false);
        Anim.SetBool("ACT_3", false);
        Anim.SetBool("ACT_4", false);
        Anim.SetBool("ACT_5", false);
        Anim.SetBool("IDLE", false);
        Anim.SetBool("WALK", false);
        Anim.SetBool("SKILL_1", false);
        Anim.SetBool("SKILL_2", false);
        Anim.SetBool("SKILL_3", true);
        On = false;
        SkillOn = false;
        HitCount = 0;
    }
    public void Skill_On_Idle()
    {
        Anim.SetBool("IDLE", true);
        Anim.SetBool("WALK", false);
        Anim.SetBool("SKILL_1", false);
        Anim.SetBool("SKILL_2", false);
        Anim.SetBool("SKILL_3", false);
        Skill_IDLE = false;
    }
    public void Skill_On_Walk()
    {
        Anim.SetBool("IDLE", false);
        Anim.SetBool("WALK", true);
        Anim.SetBool("SKILL_1", false);
        Anim.SetBool("SKILL_2", false);
        Anim.SetBool("SKILL_3", false);
        Skill_WALK = false;
    }
}