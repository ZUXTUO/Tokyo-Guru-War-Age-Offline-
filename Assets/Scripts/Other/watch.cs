using UnityEngine;

public class watch : MonoBehaviour
{
    public GameObject handtishi;
    void Start()
    {
        handtishi = GameObject.FindWithTag("handmain5");
        handtishi.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        handtishi.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        handtishi.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    { 
        handtishi.SetActive(false);
    }
}
