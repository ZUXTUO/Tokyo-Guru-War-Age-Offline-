using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCol : MonoBehaviour
{
    public static Animator Player;
    public AnimatorStateInfo Anim;
    public int count = 0;
    public float ActSpeedAnim = 0.9f;
    public Transform[] ActFx,TiShi;
    public static bool ActOn;
    public Transform Skill_1_Fx, Skill_2_Fx, Skill_3_Fx;
    public float[] ActTime;
    public Image[] ActImage;
    public GameObject Camera;
    public static Camera Cam;
    public GameObject PlayerN;
    public ETCJoystick PlayerJyOn;
    public GameObject ActUI;
    public static bool On = false;
    public void Start()
    {
        PlayerJyOn.tmSpeed = 5;
        Cam = Camera.GetComponent<Camera>();
        Camera.GetComponent<ShakeCamera>().enabled = false;
        Player = GetComponent<Animator>();
        Anim = Player.GetCurrentAnimatorStateInfo(0);
    }
    public void Idle()
    {
        Player.SetBool("Run", false);
        Player.SetBool("Skill_1", false);
        Player.SetBool("Skill_2", false);
        Player.SetBool("Skill_3", false);
    }
    public void Move()
    {
        Player.SetBool("Run", true);
        Player.SetBool("Skill_1", false);
        Player.SetBool("Skill_2", false);
        Player.SetBool("Skill_3", false);
    }
    public void Skill_1()
    {
        //
        Transform m = Instantiate(TiShi[0], PlayerN.gameObject.transform);
        m.transform.localPosition = new Vector3(0f, 0.00024f, 0.03699f);
        m.transform.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        m.transform.localScale = new Vector3(0.007136401f, 0.007136401f, 0.007136401f);
        Destroy(m.gameObject, 0.18f);
        ActImage[0].gameObject.SetActive(true); ActImage[3].GetComponent<Button>().enabled = false;
        StartCoroutine(Skill_1_End());
    }
    public IEnumerator Skill_1_End()
    {
        PlayerJyOn.tmSpeed = 0;
        Player.SetBool("Skill_1", true);
        Player.SetBool("Skill_2", false);
        Player.SetBool("Skill_3", false);
        ActUI.SetActive(false);
        yield return new WaitForSeconds(0.12f);
        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<PlayerActOnTigger>().enabled = true;
        //
        Transform n = Instantiate(Skill_1_Fx, this.gameObject.transform);
        n.transform.localPosition = new Vector3(0f, 0.00861f, 0.00878f);
        n.transform.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 90f));
        n.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
        Destroy(n.gameObject, 2f);
        Camera.GetComponent<ShakeCamera>().enabled = true;
        HP(10);
        yield return new WaitForSeconds(0.06f);
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<PlayerActOnTigger>().enabled = false;
        PlayerJyOn.tmSpeed = 5;
        ActUI.SetActive(true);
        Player.SetBool("Skill_1", false);
        Player.SetBool("Skill_2", false);
        Player.SetBool("Skill_3", false);
    }
    public void Skill_2()
    {
        //
        Transform m = Instantiate(TiShi[1], PlayerN.gameObject.transform);
        m.transform.localPosition = new Vector3(0f, 0.00024f, 0.0238f);
        m.transform.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
        m.transform.localScale = new Vector3(0.0013792f, 0.004f, 0.004f);
        Destroy(m.gameObject, 0.25f);
        ActImage[1].gameObject.SetActive(true); ActImage[4].GetComponent<Button>().enabled = false;
        StartCoroutine(Skill_2_End());
    }

    public IEnumerator Skill_2_End()
    {
        PlayerJyOn.tmSpeed = 0;
        Player.SetBool("Skill_1", false);
        Player.SetBool("Skill_2", true);
        Player.SetBool("Skill_3", false);
        ActUI.SetActive(false);
        yield return new WaitForSeconds(0.20f);
        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<PlayerActOnTigger>().enabled = true;
        //
        Transform n = Instantiate(Skill_2_Fx, this.gameObject.transform);
        n.transform.localPosition = new Vector3(0f, 0.00861f, 0.00878f);
        n.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        n.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        Destroy(n.gameObject, 2f);
        Camera.GetComponent<ShakeCamera>().enabled = true;
        HP(20);
        yield return new WaitForSeconds(0.05f);
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<PlayerActOnTigger>().enabled = false;
        PlayerJyOn.tmSpeed = 5;
        ActUI.SetActive(true);
        Player.SetBool("Skill_1", false);
        Player.SetBool("Skill_2", false);
        Player.SetBool("Skill_3", false);
    }
    public void Skill_3()
    {
        //
        Transform m = Instantiate(TiShi[2], PlayerN.gameObject.transform);
        m.transform.localPosition = new Vector3(0f, 0.00024f, 0.0507f);
        m.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
        m.transform.localScale = new Vector3(0.0081276f, 0.0081276f, 0.0081276f);
        Destroy(m.gameObject, 1.14f);
        ActImage[2].gameObject.SetActive(true); ActImage[5].gameObject.GetComponent<Button>().enabled = false;
        StartCoroutine(Skill_3_End());
    }
    public IEnumerator Skill_3_End()
    {
        PlayerJyOn.tmSpeed = 0;
        Player.SetBool("Skill_1", false);
        Player.SetBool("Skill_2", false);
        Player.SetBool("Skill_3", true);
        ActUI.SetActive(false);
        yield return new WaitForSeconds(0.85f);
        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<PlayerActOnTigger>().enabled = true;
        //
        Transform n = Instantiate(Skill_3_Fx, this.gameObject.transform);
        n.transform.localPosition = new Vector3(-0.0033f, 0.0024f, 0.0559f);
        n.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        n.transform.localScale = new Vector3(0.03f, 0.03f, 0.03f);
        Destroy(n.gameObject, 3.8f);
        Camera.GetComponent<ShakeCamera>().enabled = true;
        HP(40);
        yield return new WaitForSeconds(0.29f);
        this.GetComponent<BoxCollider>().enabled = false;
        this.GetComponent<PlayerActOnTigger>().enabled = false;
        PlayerJyOn.tmSpeed = 5;
        ActUI.SetActive(true);
        Player.SetBool("Skill_1", false);
        Player.SetBool("Skill_2", false);
        Player.SetBool("Skill_3", false);
    }
    public void FixedUpdate()
    {
        Application.targetFrameRate = 60;
        Cold();
        StartCoroutine(Act_End());
    }
    public void Cold()
    {
        if (ActImage[3].gameObject.GetComponent<Button>().enabled == false)
        {
            if (ActTime[0] < ActTime[3])
            {
                ActTime[0] += Time.deltaTime;
                ActImage[0].fillAmount = 1 - ActTime[0] / ActTime[3];
                if (ActImage[0].fillAmount <= 0) { ActImage[3].gameObject.GetComponent<Button>().enabled = true; ActImage[0].gameObject.SetActive(false); ActTime[0] = 0; }
            }
        }
        if (ActImage[4].gameObject.GetComponent<Button>().enabled == false)
        {
            if (ActTime[1] < ActTime[4])
            {
                ActTime[1] += Time.deltaTime;
                ActImage[1].fillAmount = 1 - ActTime[1] / ActTime[4];
                if (ActImage[1].fillAmount <= 0) { ActImage[4].gameObject.gameObject.GetComponent<Button>().enabled = true; ActImage[1].gameObject.SetActive(false); ActTime[1] = 0; }
            }
        }
        if (ActImage[5].gameObject.GetComponent<Button>().enabled == false)
        {
            if (ActTime[2] < ActTime[5])
            {
                ActTime[2] += Time.deltaTime;
                ActImage[2].fillAmount = 1 - ActTime[2] / ActTime[5];
                if (ActImage[2].fillAmount <= 0) { ActImage[5].gameObject.gameObject.GetComponent<Button>().enabled = true; ActImage[2].gameObject.SetActive(false); ActTime[2] = 0; }
            }
        }
    }
    public IEnumerator Act_End()
    {
        while (ActOn == true)
        {
            PlayerJyOn.tmSpeed = 0;
            ActOn = false;
            if (Anim.IsName("attack01") || Anim.IsName("attack02") || Anim.IsName("attack03") || Anim.IsName("attack04") || Anim.IsName("attack05"))
            {
                yield return new WaitForSeconds(0.4f);
            }
            Player.SetTrigger("isAttack"); 
            //
            Transform m = Instantiate(TiShi[2], PlayerN.gameObject.transform);
            m.transform.localPosition = new Vector3(0f, 0.00024f, 0f);
            m.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            m.transform.localScale = new Vector3(0.004f, 0.004f, 0.004f);
            Destroy(m.gameObject, 0.2f);
            yield return new WaitForSeconds(0.2f);
            Transform n = Instantiate(ActFx[count], this.gameObject.transform);
            n.transform.localPosition = new Vector3(0f, 0.00861f, 0.00878f);
            n.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
            n.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            Destroy(n.gameObject, 2f);
            count++;
            if (count >= 5) { count = 0; }
            HP(5);
            yield return new WaitForSeconds(0.4f);
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<PlayerActOnTigger>().enabled = false;
            PlayerJyOn.tmSpeed = 5;
        }
    }
    public void HP(int HP)
    {
        On = true;
        PlayerActOnTigger.HP_C = HP;
        this.GetComponent<BoxCollider>().enabled = true;
        this.GetComponent<PlayerActOnTigger>().enabled = true;
        StartCoroutine(OF());
    }
    public IEnumerator OF()
    {
        yield return new WaitForSeconds(0.5f);
        On = false;
    }
}

/*
Joy.SetActive(false);
Transform n = Instantiate(ActFx[count], this.gameObject.transform);
n.transform.localPosition = new Vector3(0f, 0.00861f, 0.00878f);
n.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
n.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
Destroy(n.gameObject, 1f);
if (Player.GetCurrentAnimatorStateInfo(1).IsName("stand") || Player.GetCurrentAnimatorStateInfo(1).IsName("run"))
{
    count = 1;
    Player.SetTrigger("isAttack");
}
else if (Player.GetCurrentAnimatorStateInfo(1).IsName("attack01") && Player.GetCurrentAnimatorStateInfo(1).normalizedTime > ActSpeedAnim && count == 1)
{
    count = 2;
    Player.SetTrigger("isAttack");
}
else if (Player.GetCurrentAnimatorStateInfo(1).IsName("attack02") && Player.GetCurrentAnimatorStateInfo(1).normalizedTime > ActSpeedAnim && count == 2)
{
    count = 3;
    Player.SetTrigger("isAttack");
}
else if (Player.GetCurrentAnimatorStateInfo(1).IsName("attack03") && Player.GetCurrentAnimatorStateInfo(1).normalizedTime > ActSpeedAnim && count == 3)
{
    count = 4;
    Player.SetTrigger("isAttack");
}
else if (Player.GetCurrentAnimatorStateInfo(1).IsName("attack04") && Player.GetCurrentAnimatorStateInfo(1).normalizedTime > ActSpeedAnim && count == 4)
{
    count = 5;
    Player.SetTrigger("isAttack");
}
else if (Player.GetCurrentAnimatorStateInfo(1).IsName("attack05") && Player.GetCurrentAnimatorStateInfo(1).normalizedTime > ActSpeedAnim && count == 5)
{
    count = 1;
    Player.SetTrigger("isAttack");
}
else
{
    Player.SetTrigger("isAttack");
    Joy.SetActive(true);
    Player.SetBool("Run", false);
    count = 0;
}*/