/*

Component: PlayerAction

Attached to: Player GameObject

Purpose: Handles player throwing action by selecting food prefabs, instantiating them, playing audio, and applying force.
*/

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
[SerializeField] protected GameObject[] foodItems;
private AudioSource audioSource;

private void Start()
{
    audioSource = GetComponent<AudioSource>();
}

private void Update()
{
}

// Called by: Player Input / Animator
public void OnThrowInput(InputAction.CallbackContext ctx)
{
    if (ctx.performed)
    {
        int foodIndex = 0;
        string controlName = ctx.control.name;
        Debug.Log($"Control name {controlName}");

        if (controlName == "1" || controlName == "buttonSouth")
        {
            foodIndex = 0;
        }
        else if (controlName == "2" || controlName == "buttonEast")
        {
            foodIndex = 1;
        }
        else if (controlName == "3" || controlName == "buttonNorth")
        {
            foodIndex = 2;
        }

        ThrowFood(foodIndex);
    }
}

private void ThrowFood(int foodIndex)
{
    if (foodItems != null && foodIndex >= 0 && foodIndex < foodItems.Length && foodItems[foodIndex] != null)
    {
        GameObject thrownFood = Instantiate(foodItems[foodIndex], transform.position, transform.rotation);

        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        Rigidbody foodRb = thrownFood.GetComponent<Rigidbody>();
        if (foodRb != null)
        {
            foodRb.AddForce(transform.forward * 10f, ForceMode.Impulse);
        }
    }
}
}