using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject obstaclePrefab; // 障害物のプレハブを指定
    private bool isGenerating = false;

    void Start()
    {
        // ゲーム開始時にはアイテムを生成しないようにする
        isGenerating = false;
    }

    void Update()
    {
        // プレイヤーが触れていない場合かつアイテムがまだ生成されていない場合
        if (!isGenerating)
        {
            // 出現座標の範囲
            float randomX = Random.Range(-8f, 8f);
            float randomY = Random.Range(-0.6f, -3f);

            // 新しいオブジェクトを生成
            GameObject newObject = Instantiate(obstaclePrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);

            // アイテムが生成されたので待機フラグを立てる
            isGenerating = true;

            // 生成されたアイテムが再び生成されるまでの待機時間
            float generateCooldown = Random.Range(10f, 15f); // 10から11秒のランダムな時間
            Invoke("ResetGeneratingFlag", generateCooldown);
        }
    }

    void ResetGeneratingFlag()
    {
        // アイテムの再生成待機フラグを解除
        isGenerating = false;
    }
}
