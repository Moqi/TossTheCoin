using UnityEngine;
using System.Collections;

public class IntroCoin : MonoBehaviour 
{
	// Use this for initialization
	private void Start () 
	{
		//Physics.gravity = new Vector3(0, -50f, 0);
		//rigidbody.maxAngularVelocity = 100;	
	
		Toss ();
	}
		
	private void OnCollisionEnter(Collision collider)
	{	
		if (collider.collider.tag == "IntroFloor")
		{
			Debug.Log ("collision");
			Toss ();
		}
	}
	
	private void Toss()
	{
		int force = Random.Range(5000, 9000);
		rigidbody.AddForce (Vector3.up * force);
		
		int torque = Random.Range(900, 9000);
		rigidbody.AddTorque(Vector3.right * torque);	
	}
	
	private void Update()
	{
		if (transform.position.y <= -20)
			Destroy(this.gameObject);
	}
}
