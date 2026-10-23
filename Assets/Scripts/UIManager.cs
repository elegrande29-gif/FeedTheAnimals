using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] protected UIDocument uiDocument;
    private Label animalsRemainingUI;
    private Label scoreUI;
    private int animalsRemaining;

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

    }

    public void ScoreUpdate(int scoreUpdate)
    {

    }

    public void AnimalsRemainingUpdate()
    {

    }
}