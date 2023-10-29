using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Jump;
    Vector3 direction;
    public float turnSpeed = 0.5f;
    private Animator animator;
    [SerializeField] private AudioSource jumpSound;
    
    void Start()
    {       
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector3(0, Jump, 0);
            StartCoroutine(Flap());
         }
        
        
        if (rb.velocity.y < 0)
        {
            //transform.right = new Vector3(0, 5, 0);       Other Ways to do it 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, -50f), turnSpeed);
        }
        if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 50f), turnSpeed);
        }
   
     }

    IEnumerator Flap()
    {
        animator.SetBool("flap", true);
        jumpSound.Play();
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("flap", false);
    }
}
