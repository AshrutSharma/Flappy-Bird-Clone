using System.Collections;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject pipes;
    bool stopSpawn = false;
    int count;
    private GameObject[] getCount;

    void FixedUpdate()
    {
        getCount = GameObject.FindGameObjectsWithTag("Pipe");
        count = getCount.Length;

        if (count <= 10 && !stopSpawn )
        {
            StartCoroutine(Delay());
        }    
    }

    public void Stop()
    {
        StopAllCoroutines();
    }
    
    IEnumerator Delay()
    {
        stopSpawn = true;
        float location = Random.Range(3.0f, 6.0f);
        yield return new WaitForSeconds(3.5f);
        
        Instantiate(pipes, new Vector3(13, location, 0), Quaternion.Euler(180f, 0f, 0f));
        Instantiate(pipes, new Vector3(13, location - 7.25f, 0),Quaternion.identity );
        
        stopSpawn = false;
        
    }

}
