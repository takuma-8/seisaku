using UnityEngine;
using System.Collections;

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
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // ゲームオーバーの処理
            GameOver();
        }

        

            
        if (collision.gameObject.CompareTag("Item"))
           
        {
                // Item01にぶつかったときの処理
             
            Debug.Log("Item01にぶつかりました！");

            
            
           // アイテム取得の影響を与え、クールダウンを開始する
           StartCoroutine(ItemCooldown());

                // アイテムと障害物を破壊
             
            Destroy(collision.gameObject);

                // 障害物も破壊する
                DestroyObstacles();
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

        // 任意のゲームオーバー処理を実装する（例: ゲームオーバー画面の表示、ゲームの一時停止など）
    }
}
