using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        // �Q�[���I�[�o�[�V�[���ŃX�R�A��\������
        int score = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Score: " + score.ToString();
    }
}
