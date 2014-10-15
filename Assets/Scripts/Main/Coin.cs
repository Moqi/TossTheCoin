using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour 
{	
	private bool canToss;
	public GUIText canTossText;
	public int bet;
	public GameGUI gameGUI;
	public string result;
	public GUIText winText;
	private bool hasToss;
	public GameObject table;
	
	private void Start()
	{
		Physics.gravity = new Vector3(0, -50f, 0);
		rigidbody.maxAngularVelocity = 100;
		canToss = true;	
		hasToss = false;	
	}
	
	private void OnCollisionEnter(Collision collider)	
	{
	Debug.Log ("coin hit table");
		if (collider.collider.tag == "Table")
		{
			table.audio.Play();
		}
	}
	
	private void FixedUpdate()
	{
		if (rigidbody.velocity == new Vector3(0, 0, 0))
		{
			canToss = gameGUI.CheckBankAccount();
			
		
			//canToss = true;
			
			canTossText.text = "TOSS";
			canTossText.color = Color.white;
			
			gameGUI.Tossing(0);	
			
			float angle = Vector3.Angle(transform.up, Vector3.up);
			
			switch(Mathf.FloorToInt(angle))
			{
				case 0:
				{
					Debug.Log ("HEAD");
					result = "HEAD";
				}
				break;
				
				case 90:
				{
					Debug.Log ("SIDE");
					result = "SIDE";
				}
				break;
				
				case 180:
				{
					Debug.Log ("TAIL");
					result = "TAIL";
				}
				break;
			}
					
			//if (gameGUI)
			if (hasToss)
			{
				gameGUI.AnalizeResult(result);	
				hasToss = false;																			
			}
		}	
		
		if (canToss)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				int force = Random.Range(2000, 3000);
				rigidbody.AddForce (Vector3.up * force);
				
				int torque = Random.Range(900, 9000);
				rigidbody.AddTorque(Vector3.right * torque);
				
				audio.Play();
				
				canToss = false;
				
				canTossText.text = "WAIT";
				canTossText.color = Color.white;	
				
				hasToss = true;		
				winText.enabled = false;	
				gameGUI.Tossing(1);
			}	
		}
	}	
}
