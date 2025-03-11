using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class JhonMovement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        if (Horizontal < 0.0f)
        {
            transform.localScale = new UnityEngine.Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horizontal > 0.0f)
        {
            transform.localScale = new UnityEngine.Vector3(1.0f, 1.0f, 1.0f);
        }

        // Detección de suelo con Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, UnityEngine.Vector2.down, 0.1f);
        Grounded = hit.collider != null; // Si el rayo golpea algo, está en el suelo

        // Comprobar si se presiona la tecla de salto y está en el suelo
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        // Depuración para verificar si está detectando el suelo
        Debug.Log("Grounded: " + Grounded);
    }

    private void Jump()
    {
        // Aplicar fuerza hacia arriba multiplicada por JumpForce
        Rigidbody2D.AddForce(UnityEngine.Vector2.up * JumpForce, ForceMode2D.Impulse);
    }
    private void Shoot()
    {
        UnityEngine.Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = UnityEngine.Vector2.right;
        else direction = UnityEngine.Vector2.left;



       GameObject bullet = Instantiate(BulletPrefab, transform.position + direction  * 0.1f, UnityEngine.Quaternion.identity);
       bullet.GetComponent<BulletScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        // Movimiento horizontal
        Rigidbody2D.linearVelocity = new UnityEngine.Vector2(Horizontal * Speed, Rigidbody2D.linearVelocity.y);
}
}

