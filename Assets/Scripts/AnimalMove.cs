using UnityEngine;

public class AnimalMove : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        if (IsHungry)
        {
            // Check if the collided object matches the assigned FoodItEats prefab name
            if (FoodItEats != null && collision.gameObject.name.Contains(FoodItEats.name))
            {
                Destroy(collision.gameObject);

                if (UIManager.Instance != null)
                {
                    UIManager.Instance.ScoreUpdate(10);
                    UIManager.Instance.AnimalsRemainingUpdate();
                }

                IsHungry = false;
            }
        }
    }
}