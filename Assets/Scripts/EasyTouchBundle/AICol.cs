using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICol : MonoBehaviour
{
    public GameObject EGJ; // ����GameObject
    public Animator Enemy; // ���˶�����
    public GameObject Target; // Ŀ�꣨ͨ������ң�GameObject
    public float dis; // ������Ŀ��֮��ľ���
    public float moveSpeed = 3f; // �����ƶ��ٶ�
    public float attackRange = 3f; // ���˹�����Χ
    public static float Timer = 10; // �������ռ�ʱ��

    void Update()
    {
        // �������HPС�ڵ���0����������/�����߼�
        if (Main.EnemyHP <= 0)
        {
            Timer -= Time.deltaTime; // ������ʱ
            if (Timer <= 0)
            {
                // �����߼�
                Main.Enemy_Die++; // ����������������
                EGJ.transform.position = new Vector3(59.55064f, -0.559f, 73.68414f); // ����λ��
                Main.EnemyHP = 200; // ����HP
                // ���ö���״̬
                Enemy.SetBool("Run", true);
                Enemy.SetBool("Skill_1", false);
                Enemy.SetBool("Skill_2", false);
                Enemy.SetBool("Skill_3", false);
                Enemy.SetBool("Die", false);
                Enemy.SetBool("Act", false);
                // ȷ��NavMeshAgent���ã���Ϊ�����ֶ������ƶ�
                NavMeshAgent agent = EGJ.GetComponent<NavMeshAgent>();
                if (agent != null && agent.enabled)
                {
                    agent.enabled = false;
                }
            }
            else
            {
                // ���������߼�
                Enemy.gameObject.GetComponent<AudioSource>().enabled = false; // ������Ƶ
                // ������������״̬
                Enemy.SetBool("Run", false);
                Enemy.SetBool("Skill_1", false);
                Enemy.SetBool("Skill_2", false);
                Enemy.SetBool("Skill_3", false);
                Enemy.SetBool("Die", true);
                Enemy.SetBool("Act", false);
                // ȷ��NavMeshAgent����
                NavMeshAgent agent = EGJ.GetComponent<NavMeshAgent>();
                if (agent != null && agent.enabled)
                {
                    agent.enabled = false;
                }
            }
        }
        else // ���˴��״̬
        {
            Timer = 10; // ����������ʱ��

            // ����PlayerCol.On״̬����"Act"����
            if (PlayerCol.On)
            {
                Enemy.SetBool("Act", true);
            }
            else
            {
                Enemy.SetBool("Act", false);
            }

            // ���������Ŀ��֮��ľ���
            dis = Vector3.Distance(Target.transform.position, EGJ.transform.position);

            // ���������ڹ�����Χ�������ƶ�
            if (dis > attackRange)
            {
                Enemy.gameObject.GetComponent<AudioSource>().enabled = true; // ������Ƶ

                // �����ƶ�����
                Vector3 direction = (Target.transform.position - EGJ.transform.position).normalized;
                // �����µ�λ��
                Vector3 newPosition = EGJ.transform.position + direction * moveSpeed * Time.deltaTime;
                // �ƶ�����
                EGJ.transform.position = newPosition;

                // ��������Ŀ��
                EGJ.transform.LookAt(Target.transform.position);

                // �����ܲ�����
                Enemy.SetBool("Run", true);
                Enemy.SetBool("Skill_1", false);
                Enemy.SetBool("Skill_2", false);
                Enemy.SetBool("Skill_3", false);
                Enemy.SetBool("Die", false);
                Enemy.SetBool("Act", false);

                // ȷ��NavMeshAgent����
                NavMeshAgent agent = EGJ.GetComponent<NavMeshAgent>();
                if (agent != null && agent.enabled)
                {
                    agent.enabled = false;
                }
            }
            else // ��������ڹ�����Χ�ڣ�����ֹͣ�ƶ���׼������
            {
                Enemy.gameObject.GetComponent<AudioSource>().enabled = false; // ������Ƶ

                // ����ֹͣ�ܲ�����
                Enemy.SetBool("Run", false);
                // ������Ҫ������������������ֻ��ʾ������������Ҫ�����ӵ��߼�������ʹ���ĸ����ܣ�
                // Enemy.SetBool("Skill_1", true); 
                // ȷ��NavMeshAgent����
                NavMeshAgent agent = EGJ.GetComponent<NavMeshAgent>();
                if (agent != null && agent.enabled)
                {
                    agent.enabled = false;
                }
            }
        }
    }
}
