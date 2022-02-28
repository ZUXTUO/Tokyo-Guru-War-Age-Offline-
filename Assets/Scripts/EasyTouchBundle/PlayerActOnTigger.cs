using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerActOnTigger : MonoBehaviour
{
    public static int HP_C = 10;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "E")
        {
            Debug.Log("È·¶¨");
            Main.EnemyHP = Main.EnemyHP - HP_C;
        }
        else
        {
            Debug.Log("Ê§°Ü");
        }
    }
}
