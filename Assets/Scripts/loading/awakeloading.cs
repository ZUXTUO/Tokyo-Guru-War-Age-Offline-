using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class awakeloading : MonoBehaviour
{
    public float times = 15.5f;
    void Update()
    {
        times -= Time.deltaTime;  //减时间
        if (times < 0)  //倒计时
        {
            SceneManager.LoadScene("start");
        }
    }
}
