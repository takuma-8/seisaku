using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // ゲームオーバーシーンでスコアを表示する
        int score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Score: " + score.ToString();
    }
}
