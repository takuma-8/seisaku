using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    // インスタンスを保持するための静的変数
    private static ScoreManager instance;

    // 外部からアクセス可能なスコア
    public static int Score => instance.score;

    void Awake()
    {
        // インスタンスを設定する
        instance = this;
    }

    // スコアを加算するメソッド
    public static void AddScore(int points)
    {
        instance.score += points;
    }
}
