using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    private int currentObjectCount = 0;

    public float fallSpeed = 2f; // �������x

    void Start()
    {
        // ��莞�Ԃ��ƂɃI�u�W�F�N�g�𐶐�
        InvokeRepeating("SpawnObject", 1f, 2f);
    }

    void SpawnObject()
    {
        int maxVisibleObjects = 200; // ��ʂɕ\���\�ȍő啨��
        int remainingObjects = 100; // �����\�Ȏc��̃I�u�W�F�N�g��
        int maxObjects = Mathf.Min(Random.Range(1, 6), remainingObjects); // �����_���Ȑ������i1�`5�j�Ǝc�蕨���̍ŏ��l

        

        // ��ʂɕ\���\�ȍő吔�ɒB���Ă��Ȃ��ꍇ�̂݃I�u�W�F�N�g�𐶐�
        if (maxVisibleObjects > 0)
        {Mathf.Min(Random.Range(1, 6), remainingObjects); // �����_���Ȑ������i1�`5�j�Ǝc�蕨���̍ŏ��l

            for (int i = 0; i < maxObjects; i++)
            {
                float randomX = Random.Range(-10.27f, 10.28f); // X���W�������_����
                float randomY = Random.Range(6f, 10f); // Y���W�������_����
                float fallSpeed = Random.Range(1f, 5f); // �����X�s�[�h�������_����

                Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
                GameObject newObject = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);

                // �I�u�W�F�N�g���蓮�ŗ���������
                StartCoroutine(FallObject(newObject, fallSpeed));

                currentObjectCount++;
            }
        } else
        {
            maxVisibleObjects++;
        }

        // ���̐����܂ł̑ҋ@
        float nextSpawnInterval = Random.Range(1f, 3f); // ���̐����܂ł̃����_���ȑҋ@����
        Invoke("SpawnObject", nextSpawnInterval);
    }

    // �I�u�W�F�N�g���蓮�ŗ���������R���[�`��
    IEnumerator FallObject(GameObject obj, float fallSpeed)
    {
        while (obj != null && obj.transform.position.y > -5f)
        {
            obj.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            yield return null;
        }

        // �n�ʂɒB������I�u�W�F�N�g��j��
        if (obj != null)
        {
            Destroy(obj);
            currentObjectCount--;
        }
    }




}
