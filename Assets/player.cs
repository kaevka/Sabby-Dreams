using UnityEngine;

public class player : MonoBehaviour
{
    public float moveSpeed = 5f; // скорость, с которой персонаж двигается
    public float jumpForce = 10f; // сила прыжка
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // получаем направление движения по горизонтали
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y); // задаем скорость движения по горизонтали

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // если нажата клавиша пробел и персонаж на земле
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // применяем силу прыжка
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // если персонаж коснулся земли
        {
            isGrounded = true;
        }
    }
}