using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject Item01; // Item01への参照を持つ
    private bool isGrounded;
    private Rigidbody2D rb;
    private bool gameOver = false;
    private float itemCooldown = 10f; // アイテム取得後のクールダウン時間

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!gameOver)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            rb.velocity = movement;

            if (isGrounded && Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        { 
           
            // Item01にぶつかったときの処理
            Debug.Log("Item01にぶつかりました！");

            // デバッグログを追加して、collision.gameObjectが何であるか確認する
            if (collision.gameObject == null)
            {
                Debug.LogError("collision.gameObject is null!");
            }

            // アイテム取得の影響を与え、クールダウンを開始する
            StartCoroutine(ItemCooldown());

            // アイテムと障害物を破壊
            Destroy(collision.gameObject);
           

            // 障害物も破壊する
            DestroyObstacles();
        }

        if (!gameOver && collision.gameObject.CompareTag("Obstacle"))
        {
            // 障害物に当たった場合の処理
            GameOver();
        }
    }


    void DestroyObstacles()
    {
        // 周囲の障害物を破壊
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
        {
            Destroy(obstacle);
        }
    }

    IEnumerator ItemCooldown()
    {
        yield return new WaitForSeconds(itemCooldown);

        // クールダウン終了後にアイテム取得の影響を解除
    }

    void GameOver()
    {
        // ゲームオーバーの処理をここに追加
        Debug.Log("Game Over");

        SceneManager.LoadScene("GameOverScene");

    }
}
