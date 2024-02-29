using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    public Text scoreText;
    private float elapsedTime = 0f;
    private int score = 0;

    void Start()
    {
        // ���̏ꏊ�œ����|�C���g���X�R�A�ɉ��Z�����
        int pointsFromOtherSource = 100;
        AddScore(pointsFromOtherSource);
    }

    void Update()
    {
        // �o�ߎ��Ԃ��X�V����
        elapsedTime += Time.deltaTime;

        // �X�R�A���X�V����
        score = Mathf.FloorToInt(elapsedTime);

        // �o�ߎ��Ԃ��e�L�X�g�ɕ\������
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        scoreText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    // ���̏ꏊ�œ����|�C���g�����Z���郁�\�b�h
    public void AddScore(int points)
    {
        score += points;
    }
}
