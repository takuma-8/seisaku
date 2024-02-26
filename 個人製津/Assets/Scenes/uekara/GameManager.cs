using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public float scoreIncreaseInterval = 1f; // ƒXƒRƒA‚ª‘‚¦‚éŠÔŠu

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= scoreIncreaseInterval)
        {
            IncreaseScore();
            timer = 0f;
        }
    }

    void IncreaseScore()
    {
        score++;
        UpdateScoreUI();
    }

    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
