using UnityEngine;

public class SomeOtherScript : MonoBehaviour
{
    public GameManager gameManager;

    // �Ⴆ�΁A�����̏������������ꂽ�Ƃ��ɃX�R�A���X�V����
    void SomeConditionMet()
    {
        gameManager.score++; // �X�R�A�𒼐ڑ��₷
        gameManager.UpdateScoreUI(); // UI���X�V����
    }
}
