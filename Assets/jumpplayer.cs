using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f; // Сила прыжка
    [SerializeField] private LayerMask groundLayer; // Маска слоя земли
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Проверяем, нажата ли клавиша пробела и находится ли персонаж на земле
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Применяем силу прыжка
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false; // После прыжка персонаж не на земле
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, касается ли персонаж земли
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true; // Персонаж на земле
        }
    }
}