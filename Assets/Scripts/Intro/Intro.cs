using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour 
{
	public GameObject coin;
	public GameObject floor;
	private GameObject[] coins = new GameObject[100];

	// Use this for initialization
	private void Start () 
	{
		StartCoroutine(SpawnItemsFromArray());
	}
	
		
	private IEnumerator SpawnItemsFromArray() //You can name this however you like
	{			
		int i;
		int len = 100;
		
		int xRnd;
		int zRnd;
		
		for (i = 0; i < len; i++)
		{
			xRnd = Random.Range(-100, 100);
			zRnd = Random.Range(-100, 100);		
			
			//coin.AddComponent<IntroCoin>();
			coins[i] = (GameObject)Instantiate(coin, new Vector3 (xRnd, 0, zRnd), Quaternion.identity);
			
			yield return new WaitForSeconds(0.5f);
		}
	}
	
	private void Update()
	{
		if(Input.anyKey)
			Application.LoadLevel("Main");
	}
}
