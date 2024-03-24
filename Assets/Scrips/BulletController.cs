using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    //Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
       if (other.gameObject.tag.Equals("Circle"))
       {
            Destroy(other.gameObject);
            Destroy(gameObject);
       }
    }
}
