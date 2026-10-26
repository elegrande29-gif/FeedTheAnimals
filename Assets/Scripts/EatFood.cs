using UnityEngine;

public class EatFood : MonoBehaviour
{
    public enum HungerState
    {
        Hungry,
        NotHungry
    }

    [Header("Food Configuration")]
    [Tooltip("Drag a Food Prefab into this field")]
    [SerializeField] protected GameObject FoodItEats;

    private bool IsHungry = true;

    // Handles physical non-trigger Colliders
    private void OnCollisionEnter(Collision collision)
    {
        if (!IsHungry || FoodItEats == null) return;

        // Check if the names match or contain each other

        if (collision.gameObject.name.Contains(FoodItEats.name))
        {


            // Update UI
            if (UIManager.Instance != null)
            {
                UIManager.Instance.ScoreUpdate(10);
                UIManager.Instance.AnimalsRemainingUpdate();
            }

            // Transition state to Not Hungry
            IsHungry = false;
        }
        // Destroy the eaten food
        Destroy(collision.gameObject);
    }
}