using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleControllerHorizontal : MonoBehaviour
{
    private int direction = 1;
    private int moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(direction, 0f, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        if (transform.position.x > 2.7f || transform.position.x < -6.4f)
        {
            direction *= -1;
        }
    }
}
