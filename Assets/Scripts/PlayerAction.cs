using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    // Enum representing the state machine states specified in the design doc
    public enum ThrowState
    {
        NotThrowingFood,
        ThrowingFood
    }

    [Header("Food Configuration")]
    [SerializeField] protected GameObject[] foodItems; // Up to 3 food types available
    [SerializeField] private float throwForce = 15.0f;

    private AudioSource audioSource;
    private ThrowState currentState = ThrowState.NotThrowingFood;
    private int selectedFoodIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Input Action Callback (Transition Out: IF commanded by Player Input)
    public void OnFeedInput(InputAction.CallbackContext ctx)
    {
        // Only trigger when input action is performed and currently NOT THROWING FOOD
        if (ctx.performed && currentState == ThrowState.NotThrowingFood)
        {
            // Transition to THROWING FOOD state
            currentState = ThrowState.ThrowingFood;

            // Execute Actions (Execute Once on Enter)
            SelectFood(ctx.control.name);
            ThrowFood(selectedFoodIndex);

            // Transition Out: At conclusion of Action -> Transition back to NOT THROWING FOOD
            currentState = ThrowState.NotThrowingFood;
        }
    }

    private void SelectFood(string keyName)
    {
        // Select food based on input key name (up to 3 key buttons)
        switch (keyName.ToLower())
        {
            case "e":
                selectedFoodIndex = 0;
                break;
            case "r":
                if (foodItems != null && foodItems.Length > 1) selectedFoodIndex = 1;
                break;
            case "w":
                if (foodItems != null && foodItems.Length > 2) selectedFoodIndex = 2;
                break;
            default:
                selectedFoodIndex = 0;
                break;
        }
    }

    private void ThrowFood(int index)
    {
        if (foodItems == null || foodItems.Length == 0) return;

        int safeIndex = Mathf.Clamp(index, 0, foodItems.Length - 1);

        // Architectural Constraint: Spawn position at player center
        Vector3 spawnPosition = transform.position + Vector3.up;

        // Instantiate a food prefab at player center
        GameObject instantiatedFood = Instantiate(foodItems[safeIndex], spawnPosition, transform.rotation);

        // Play a throwing clip
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }

        // Add a forward force (throw) to the food instantiated
        Rigidbody rb = instantiatedFood.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }
    }
}