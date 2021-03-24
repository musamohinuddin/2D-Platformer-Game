using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
	private void Awake()
	{
		Debug.Log("Player controller awake");
	}
	
	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//	Debug.Log("Collision: " + collision.gameObject.name);
	//}
		
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float speed =Input.GetAxisRaw("Horizontal");
		animator.SetFloat("Speed", Mathf.Abs(speed));
		Vector3 Scale = transform.localScale;
		if(speed < 0)
		{
			Scale.x = -1f * Mathf.Abs(Scale.x);
		} else if(speed > 0)
		{
			Scale.x = Mathf.Abs(Scale.x);
		}
		transform.localScale=Scale;
			
			
    }
}
