using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class movement : MonoBehaviour
{
    public  Rigidbody2D rb;
    public int speed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(1,0) * speed *Time.fixedDeltaTime);
        
        if (gameObject.transform.position.x < -13)
        {
            Destroy(gameObject);
        }
    }
}
