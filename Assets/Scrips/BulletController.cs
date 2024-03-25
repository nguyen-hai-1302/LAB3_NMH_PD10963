using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;  
    // Start is called before the first frame update
    void Start()
    {        
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D (Collider2D col)
    {
       if (col.gameObject.tag.Equals("Circle"))
       {
            Destroy(col.gameObject);
            Destroy(gameObject);
       }
    }
}
