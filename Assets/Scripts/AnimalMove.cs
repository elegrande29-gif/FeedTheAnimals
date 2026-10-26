using UnityEngine;

public class AnimalMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed = 2f;
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * MoveSpeed);
    }
}