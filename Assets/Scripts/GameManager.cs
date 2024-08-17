using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private const string GameScene = "Game";

    [SerializeField] private TextMeshProUGUI timerText;
    private float remainingTime = 90;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime >0)
        {
            remainingTime -= Time.deltaTime;

           
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timerText.color = Color.red;
            // todo add delay
            SceneManager.LoadScene(GameScene);
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void RestartButtonPressed()
    {
        SceneManager.LoadScene(GameScene);
    }
}
