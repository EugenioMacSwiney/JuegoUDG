using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip bala;
    public float Speed;
    private Vector2 Direction;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(bala);
    }


  private void FixedUpdate()
    {
    Rigidbody2D.linearVelocity= Direction * Speed;
    } 
    public void SetDirection(Vector2 direction)
    {
       Direction = direction;   
    }  
  public void DestroyBullet()
    {
        Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            JhonMovement john = collision.GetComponent<JhonMovement>();
            GruntScript grunt = collision.GetComponent<GruntScript>();
            if (john != null)
            {
                john.Hit();
                DestroyBullet();
            }
            if (grunt != null)
            {
                grunt.Hit();
                DestroyBullet();
            }
        }
    }
