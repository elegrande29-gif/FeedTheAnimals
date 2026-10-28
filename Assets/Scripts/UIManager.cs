using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] protected UIDocument uiDocument;
    private Label animalsRemainingUI;
    private Label scoreUI;
    private int animalsRemaining;
    private int score;

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
            animalsRemainingUI = uiDocument.rootVisualElement.Q<Label>("animalsRemainingText");
            scoreUI = uiDocument.rootVisualElement.Q<Label>("scoreText");
    }

    public void ScoreUpdate(int scoreUpdate)
    {
        score += scoreUpdate;
        scoreUI.text = "Score: " + score.ToString();
        SpawnManager.Instance.GetNumberOfAnimalsToFeed();
    }

    public void AnimalsRemainingUpdate()
    
    {
        animalsRemaining--;
        animalsRemainingUI.text = "Animals Remaining: " + animalsRemaining.ToString();
        Debug.Log("Animals Remaining Updated");
    }
}