using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour 
{
	public GameObject coin;
	public float distance = 5;

	// Update is called once per frame
	private void Update () 
	{
		Vector3 camPos = new Vector3(0, distance, 0);
		this.gameObject.transform.position = coin.transform.position + camPos;
	}
}
