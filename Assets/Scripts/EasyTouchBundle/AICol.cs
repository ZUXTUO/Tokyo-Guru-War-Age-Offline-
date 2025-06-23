using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICol : MonoBehaviour
{
    public GameObject EGJ; // 敌人GameObject
    public Animator Enemy; // 敌人动画器
    public GameObject Target; // 目标（通常是玩家）GameObject
    public float dis; // 敌人与目标之间的距离
    public float moveSpeed = 3f; // 敌人移动速度
    public float attackRange = 3f; // 敌人攻击范围
    public static float Timer = 10; // 死亡复苏计时器

    void Update()
    {
        // 如果敌人HP小于等于0，进入死亡/复苏逻辑
        if (Main.EnemyHP <= 0)
        {
            Timer -= Time.deltaTime; // 死亡计时
            if (Timer <= 0)
            {
                // 复苏逻辑
                Main.Enemy_Die++; // 敌人死亡次数增加
                EGJ.transform.position = new Vector3(59.55064f, -0.559f, 73.68414f); // 重置位置
                Main.EnemyHP = 200; // 重置HP
                // 重置动画状态
                Enemy.SetBool("Run", true);
                Enemy.SetBool("Skill_1", false);
                Enemy.SetBool("Skill_2", false);
                Enemy.SetBool("Skill_3", false);
                Enemy.SetBool("Die", false);
                Enemy.SetBool("Act", false);
                // 确保NavMeshAgent禁用，因为我们手动控制移动
                NavMeshAgent agent = EGJ.GetComponent<NavMeshAgent>();
                if (agent != null && agent.enabled)
                {
                    agent.enabled = false;
                }
            }
            else
            {
                // 死亡动画逻辑
                Enemy.gameObject.GetComponent<AudioSource>().enabled = false; // 禁用音频
                // 设置死亡动画状态
                Enemy.SetBool("Run", false);
                Enemy.SetBool("Skill_1", false);
                Enemy.SetBool("Skill_2", false);
                Enemy.SetBool("Skill_3", false);
                Enemy.SetBool("Die", true);
                Enemy.SetBool("Act", false);
                // 确保NavMeshAgent禁用
                NavMeshAgent agent = EGJ.GetComponent<NavMeshAgent>();
                if (agent != null && agent.enabled)
                {
                    agent.enabled = false;
                }
            }
        }
        else // 敌人存活状态
        {
            Timer = 10; // 重置死亡计时器

            // 根据PlayerCol.On状态设置"Act"动画
            if (PlayerCol.On)
            {
                Enemy.SetBool("Act", true);
            }
            else
            {
                Enemy.SetBool("Act", false);
            }

            // 计算敌人与目标之间的距离
            dis = Vector3.Distance(Target.transform.position, EGJ.transform.position);

            // 如果距离大于攻击范围，敌人移动
            if (dis > attackRange)
            {
                Enemy.gameObject.GetComponent<AudioSource>().enabled = true; // 启用音频

                // 计算移动方向
                Vector3 direction = (Target.transform.position - EGJ.transform.position).normalized;
                // 计算新的位置
                Vector3 newPosition = EGJ.transform.position + direction * moveSpeed * Time.deltaTime;
                // 移动敌人
                EGJ.transform.position = newPosition;

                // 敌人面向目标
                EGJ.transform.LookAt(Target.transform.position);

                // 设置跑步动画
                Enemy.SetBool("Run", true);
                Enemy.SetBool("Skill_1", false);
                Enemy.SetBool("Skill_2", false);
                Enemy.SetBool("Skill_3", false);
                Enemy.SetBool("Die", false);
                Enemy.SetBool("Act", false);

                // 确保NavMeshAgent禁用
                NavMeshAgent agent = EGJ.GetComponent<NavMeshAgent>();
                if (agent != null && agent.enabled)
                {
                    agent.enabled = false;
                }
            }
            else // 如果距离在攻击范围内，敌人停止移动并准备攻击
            {
                Enemy.gameObject.GetComponent<AudioSource>().enabled = false; // 禁用音频

                // 设置停止跑步动画
                Enemy.SetBool("Run", false);
                // 根据需要触发攻击动画（这里只是示例，您可能需要更复杂的逻辑来决定使用哪个技能）
                // Enemy.SetBool("Skill_1", true); 
                // 确保NavMeshAgent禁用
                NavMeshAgent agent = EGJ.GetComponent<NavMeshAgent>();
                if (agent != null && agent.enabled)
                {
                    agent.enabled = false;
                }
            }
        }
    }
}
