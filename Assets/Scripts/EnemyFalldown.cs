using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFalldown : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform groundDetection;
    public GameObject enemy;
    float delay = 2;  
    

    void Start()
    {
        

    }   

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);        
        if (groundInfo.collider == false)
        {
            StartCoroutine(EnemyDelay(delay));             
        }            

    }  

    private IEnumerator EnemyDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        this.transform.position = new Vector3(21.77f, 3.64f, -0.08f);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
    }
}
