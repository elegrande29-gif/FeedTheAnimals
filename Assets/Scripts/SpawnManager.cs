using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    [SerializeField] protected GameObject[] animalPrefab;
    protected int animalsToFeed = 10;
    protected float spawnStart = 1.0f;
    protected float startFrequency = 2.0f;
    protected float spawnZPosition = 20.0f;
    protected float centerToEdge = 22.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnAnimal), spawnStart, startFrequency);
    }

    private void SpawnAnimal()
    {
        if (animalPrefab == null || animalPrefab.Length == 0) return;

        // Choose a random animal prefab
        int animalIndex = Random.Range(0, animalPrefab.Length);

        // Calculate a random X position within horizontal bounds
        float randomX = Random.Range(-centerToEdge, centerToEdge);
        Vector3 spawnPos = new Vector3(randomX, 0, spawnZPosition);

        // Spawn animal facing towards the player (rotated 180 degrees)
        Instantiate(animalPrefab[animalIndex], spawnPos, Quaternion.Euler(0, 180, 0));
    }

    private void GameOver()
    {
        CancelInvoke(nameof(SpawnAnimal));
        Debug.Log("Game Over!");
    }

    public int GetNumberOfAnimalsToFeed()
    {
        return animalsToFeed;
    }
}