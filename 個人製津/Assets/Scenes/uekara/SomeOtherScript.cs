using UnityEngine;

public class SomeOtherScript : MonoBehaviour
{
    public GameManager gameManager;

    // 例えば、何かの条件が満たされたときにスコアを更新する
    void SomeConditionMet()
    {
        gameManager.score++; // スコアを直接増やす
        gameManager.UpdateScoreUI(); // UIを更新する
    }
}
