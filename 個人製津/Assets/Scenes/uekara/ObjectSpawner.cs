using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    private int currentObjectCount = 0;

    public float fallSpeed = 2f; // 落下速度

    void Start()
    {
        // 一定時間ごとにオブジェクトを生成
        InvokeRepeating("SpawnObject", 1f, 2f);
    }

    void SpawnObject()
    {
        int maxVisibleObjects = 200; // 画面に表示可能な最大物数
        int remainingObjects = 100; // 生成可能な残りのオブジェクト数
        int maxObjects = Mathf.Min(Random.Range(1, 6), remainingObjects); // ランダムな生成数（1～5）と残り物数の最小値

        

        // 画面に表示可能な最大数に達していない場合のみオブジェクトを生成
        if (maxVisibleObjects > 0)
        {Mathf.Min(Random.Range(1, 6), remainingObjects); // ランダムな生成数（1～5）と残り物数の最小値

            for (int i = 0; i < maxObjects; i++)
            {
                float randomX = Random.Range(-10.27f, 10.28f); // X座標をランダムに
                float randomY = Random.Range(6f, 10f); // Y座標をランダムに
                float fallSpeed = Random.Range(1f, 5f); // 落下スピードをランダムに

                Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
                GameObject newObject = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);

                // オブジェクトを手動で落下させる
                StartCoroutine(FallObject(newObject, fallSpeed));

                currentObjectCount++;
            }
        } else
        {
            maxVisibleObjects++;
        }

        // 次の生成までの待機
        float nextSpawnInterval = Random.Range(1f, 3f); // 次の生成までのランダムな待機時間
        Invoke("SpawnObject", nextSpawnInterval);
    }

    // オブジェクトを手動で落下させるコルーチン
    IEnumerator FallObject(GameObject obj, float fallSpeed)
    {
        while (obj != null && obj.transform.position.y > -5f)
        {
            obj.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
            yield return null;
        }

        // 地面に達したらオブジェクトを破棄
        if (obj != null)
        {
            Destroy(obj);
            currentObjectCount--;
        }
    }




}
