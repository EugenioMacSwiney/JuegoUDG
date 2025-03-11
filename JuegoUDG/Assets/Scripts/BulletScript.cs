using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float Speed;
    private Vector2 Direction;
    private Rigidbody2D Rigidbody2D;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
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
    }