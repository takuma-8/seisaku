using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameObject Item01; // Item01�ւ̎Q�Ƃ�����
    private bool isGrounded;
    private Rigidbody2D rb;
    private bool gameOver = false;
    private float itemCooldown = 10f; // �A�C�e���擾��̃N�[���_�E������

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
            // �Q�[���I�[�o�[�̏���
            GameOver();
        }

        

            
        if (collision.gameObject.CompareTag("Item"))
           
        {
                // Item01�ɂԂ������Ƃ��̏���
             
            Debug.Log("Item01�ɂԂ���܂����I");

            
            
           // �A�C�e���擾�̉e����^���A�N�[���_�E�����J�n����
           StartCoroutine(ItemCooldown());

                // �A�C�e���Ə�Q����j��
             
            Destroy(collision.gameObject);

                // ��Q�����j�󂷂�
                DestroyObstacles();
            }
     
        void DestroyObstacles()
        {
            // ���͂̏�Q����j��
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

        // �N�[���_�E���I����ɃA�C�e���擾�̉e��������
        
    }

    void GameOver()
    {
        // �Q�[���I�[�o�[�̏����������ɒǉ�
        Debug.Log("Game Over");

        // �C�ӂ̃Q�[���I�[�o�[��������������i��: �Q�[���I�[�o�[��ʂ̕\���A�Q�[���̈ꎞ��~�Ȃǁj
    }
}
