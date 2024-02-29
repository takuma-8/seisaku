using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    public Text scoreText;
    private float elapsedTime = 0f;
    private int score = 0;

    void Start()
    {
        // 他の場所で得たポイントをスコアに加算する例
        int pointsFromOtherSource = 100;
        AddScore(pointsFromOtherSource);
    }

    void Update()
    {
        // 経過時間を更新する
        elapsedTime += Time.deltaTime;

        // スコアを更新する
        score = Mathf.FloorToInt(elapsedTime);

        // 経過時間をテキストに表示する
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        scoreText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    // 他の場所で得たポイントを加算するメソッド
    public void AddScore(int points)
    {
        score += points;
    }
}
