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

    private void OnCollisionEnter(Collision collision)
    {
        if (IsHungry)
        {
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