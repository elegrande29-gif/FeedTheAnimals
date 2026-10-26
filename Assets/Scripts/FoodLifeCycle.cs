using UnityEngine;

public class FoodLifeCycle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("DestroyObject", 2f);
    }

    // Update is called once per frame
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
