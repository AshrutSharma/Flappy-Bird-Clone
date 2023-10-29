using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public movement[] Pipes;
    [SerializeField] private AudioSource DeathSound;
    public spawner Spawn;
    
    void Update()
    {
       Pipes = GameObject.FindObjectsOfType<movement>();
       Spawn = GameObject.FindObjectOfType < spawner>(); 
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        ProcessCollision(collision.gameObject);    
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        ProcessCollision(collision.gameObject);
    } 
   
    void ProcessCollision(GameObject collider)
    {
        if (collider.CompareTag("Pipe"))
        {
            DeathSound.Play();
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        gameObject.GetComponent<jump>().enabled = false;
        Spawn.Stop();
        
        foreach(movement i in Pipes)
        {
            i.enabled = false;
        }
        
        yield return new WaitForSeconds(2);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
