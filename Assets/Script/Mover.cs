using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float speed;
	
	void Start ()
	{
		rigidbody.velocity = transform.forward * speed;
	}

	void Update()
	{
		if(gameObject.transform.position.z > 15)
		{
			Destroy(gameObject);
		}
	}
}
