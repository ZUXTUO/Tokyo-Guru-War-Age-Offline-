using UnityEngine;
using System.Collections;
public class ShakeCamera : MonoBehaviour
{
    private Vector3 shakePos = Vector3.zero;
    void Update()
    {
        StartCoroutine(ZhenDong());
    }
    public IEnumerator ZhenDong()
    {
        transform.localPosition -= shakePos;
        shakePos = Random.insideUnitSphere / 5.0f;
        transform.localPosition += shakePos;
        yield return new WaitForSeconds(0.5f);
        transform.localPosition = Vector3.zero;
        this.GetComponent<ShakeCamera>().enabled = false;
    }
}