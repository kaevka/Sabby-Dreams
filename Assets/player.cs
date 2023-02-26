using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f; // ��������, � ������� �������� ���������
    public float jumpForce = 10f; // ���� ������
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // �������� ����������� �������� �� �����������
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y); // ������ �������� �������� �� �����������

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // ���� ������ ������� ������ � �������� �� �����
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // ��������� ���� ������
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // ���� �������� �������� �����
        {
            isGrounded = true;
        }
    }
}