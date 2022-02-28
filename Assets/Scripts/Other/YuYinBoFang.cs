using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuYinBoFang : MonoBehaviour
{
    public bool On = false;
    public AudioClip[] clips;
    public AudioSource audioSource;
    void Update()
    {
        if (On == true)
        {
            if (audioSource.isPlaying)
            {
            }
            else
            {
                int i = Random.Range(0, 4);
                audioSource.PlayOneShot(clips[i]);
                On = false;
                this.GetComponent<YuYinBoFang>().enabled = false;
            }
        }
        else
        {
            this.GetComponent<YuYinBoFang>().enabled = false;
        }
    }
    public void OnClick()
    {
        On = true;
        this.GetComponent<YuYinBoFang>().enabled = true;
    }
}
