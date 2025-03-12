using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject BulletPrefab;
public GameObject John;
private float LastShoot;
private int Health = 3;

    private void Update()
    {
        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);
       
        if (distance < 1.0f && Time.time > LastShoot + 1.25f)
        {
            Shoot();
            LastShoot = Time.time;

        }}
        private void Shoot()
        {
                    UnityEngine.Vector3 direction;
        if (transform.localScale.x == 1.0f) direction = UnityEngine.Vector2.right;
        else direction = UnityEngine.Vector2.left;



       GameObject bullet = Instantiate(BulletPrefab, transform.position + direction  * 0.1f, UnityEngine.Quaternion.identity);
       bullet.GetComponent<BulletScript>().SetDirection(direction);
        }
        public void Hit()
{
Health = Health - 1;
if (Health == 0) Destroy(gameObject);
    
        
}
     }

