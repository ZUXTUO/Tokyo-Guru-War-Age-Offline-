using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_ALL : MonoBehaviour
{
    public Slider SilderHP, EnemyHP, PlayerHP_UI, EnemyHP_UI;
    public GameObject PlayerTarget, EnemyTarget;
    public GameObject Die_P, Die_E;
    public Text Die_P_Text, Die_E_Text, P_D, E_D;
    public void FixedUpdate()
    {
        P_D.text = Main.Player_Die.ToString(); E_D.text = Main.Enemy_Die.ToString();
        SilderHP.transform.position = PlayerCol.Cam.WorldToScreenPoint(PlayerTarget.transform.position);
        SilderHP.value = Main.PlayerHP; PlayerHP_UI.value = Main.PlayerHP;
        EnemyHP.transform.position = PlayerCol.Cam.WorldToScreenPoint(EnemyTarget.transform.position);
        EnemyHP.value = Main.EnemyHP; EnemyHP_UI.value = Main.EnemyHP;
        if (Main.PlayerHP <= 0) { SilderHP.gameObject.SetActive(false); Die_P.SetActive(true); } else { SilderHP.gameObject.SetActive(true); Die_P.SetActive(false); }
        if (Main.EnemyHP <= 0) { EnemyHP.gameObject.SetActive(false); Die_E.SetActive(true); Die_E_Text.text = AICol.Timer.ToString("f0");} else { EnemyHP.gameObject.SetActive(true); Die_E.SetActive(false); }
    }
}
