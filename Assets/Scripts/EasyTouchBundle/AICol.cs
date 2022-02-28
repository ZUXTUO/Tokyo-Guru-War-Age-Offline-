using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICol : MonoBehaviour
{
    public GameObject EGJ;
    public Animator Enemy;
    public AnimatorStateInfo Anim;
    public GameObject Target;
    public NavMeshAgent Agent;
    public float dis;
    public Vector3 Enemy_V;
    public static float Timer = 10;
    public void Update()
    {
        if (Main.EnemyHP <= 0)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Main.Enemy_Die++;
                //¸´ËÕ
                EGJ.gameObject.transform.position = new Vector3(59.55064f, -0.559f, 73.68414f);
                Main.EnemyHP = 200;
                Enemy.SetBool("Run", true); Enemy.SetBool("Skill_1", false); Enemy.SetBool("Skill_2", false); Enemy.SetBool("Skill_3", false); Enemy.SetBool("Die", false); Enemy.SetBool("Act", false);
            }
            else
            {
                //ËÀÍö¶¯»­
                Enemy.gameObject.GetComponent<AudioSource>().enabled = false;
                Enemy.SetBool("Run", false); Enemy.SetBool("Skill_1", false); Enemy.SetBool("Skill_2", false); Enemy.SetBool("Skill_3", false); Enemy.SetBool("Die", true); Enemy.SetBool("Act", false);
            }
        }
        else
        {
            Timer = 10;
            if (PlayerCol.On == true) { Enemy.SetBool("Act", true); } else { Enemy.SetBool("Act", false); }
            dis = Vector3.Distance(Target.transform.localPosition, EGJ.transform.position);
            if (dis > 3)
            {
                Enemy.gameObject.GetComponent<AudioSource>().enabled = true;
                Enemy_V = EGJ.transform.position;
                Enemy.SetBool("Run", true); Enemy.SetBool("Skill_1", false); Enemy.SetBool("Skill_2", false); Enemy.SetBool("Skill_3", false); Enemy.SetBool("Die", false); Enemy.SetBool("Act", false);
                Agent.destination = Target.transform.localPosition;
                EGJ.GetComponent<NavMeshAgent>().enabled = true;
            }
            else
            {
                Enemy.gameObject.GetComponent<AudioSource>().enabled = false;
                EGJ.transform.position = Enemy_V;
                Enemy.SetBool("Run", false);
                EGJ.GetComponent<NavMeshAgent>().enabled = false;
            }
        }
    }
}