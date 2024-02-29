using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0;

    // �C���X�^���X��ێ����邽�߂̐ÓI�ϐ�
    private static ScoreManager instance;

    // �O������A�N�Z�X�\�ȃX�R�A
    public static int Score => instance.score;

    void Awake()
    {
        // �C���X�^���X��ݒ肷��
        instance = this;
    }

    // �X�R�A�����Z���郁�\�b�h
    public static void AddScore(int points)
    {
        instance.score += points;
    }
}
