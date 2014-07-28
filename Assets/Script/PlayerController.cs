using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float Speed;
	public float xMin,xMax,zMin,zMax;
	public float titl;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private float nextFire;

	void Update(){
		if(Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot , shotSpawn.position ,shotSpawn.rotation);
			audio.Play();
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * Speed;

		rigidbody.position = new Vector3 (
			Mathf.Clamp(rigidbody.position.x,xMin,xMax),
			0.0f,
			Mathf.Clamp(rigidbody.position.z,zMin,zMax)
		);
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * titl);
	}
}
