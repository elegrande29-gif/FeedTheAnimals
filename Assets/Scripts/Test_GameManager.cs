
using UnityEngine;

public class Test_GameManager : MonoBehaviour
{
    // Calls RunTest after 2 seconds, then every 1.5 seconds.
    void Start()
    {
        InvokeRepeating("RunTest", 2, 1.5f);
    }

    // Updates the remaining animals and adds 10 points.
    void RunTest()
    {
        UIManager.Instance.AnimalsRemainingUpdate();
        UIManager.Instance.ScoreUpdate(10);
    }
}