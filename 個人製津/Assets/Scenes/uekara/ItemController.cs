using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject obstaclePrefab; // ��Q���̃v���n�u���w��
    private bool isGenerating = false;

    void Start()
    {
        // �Q�[���J�n���ɂ̓A�C�e���𐶐����Ȃ��悤�ɂ���
        isGenerating = false;
    }

    void Update()
    {
        // �v���C���[���G��Ă��Ȃ��ꍇ���A�C�e�����܂���������Ă��Ȃ��ꍇ
        if (!isGenerating)
        {
            // �o�����W�͈̔�
            float randomX = Random.Range(-8f, 8f);
            float randomY = Random.Range(-0.6f, -3f);

            // �V�����I�u�W�F�N�g�𐶐�
            GameObject newObject = Instantiate(obstaclePrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);

            // �A�C�e�����������ꂽ�̂őҋ@�t���O�𗧂Ă�
            isGenerating = true;

            // �������ꂽ�A�C�e�����Ăѐ��������܂ł̑ҋ@����
            float generateCooldown = Random.Range(10f, 15f); // 10����11�b�̃����_���Ȏ���
            Invoke("ResetGeneratingFlag", generateCooldown);
        }
    }

    void ResetGeneratingFlag()
    {
        // �A�C�e���̍Đ����ҋ@�t���O������
        isGenerating = false;
    }
}
