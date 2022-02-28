using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class loadingwate : MonoBehaviour
{
    public float timeswate = 3f;
    public Slider _Slider;
    public GameObject TextInf;
    void Update()
    {
        timeswate -= Time.deltaTime;
        _Slider.value = 0 - timeswate / 3;
        if (_Slider.value >= 0)
        {
            TextInf.SetActive(false);
            this.GetComponent<loadingwate>().enabled = false;
            this.GetComponent<Loading>().enabled = true;
        }
    }
}
