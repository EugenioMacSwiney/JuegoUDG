using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        Rigidbody2D.linearVelocity = Vector2.right * Speed;
    }
}
