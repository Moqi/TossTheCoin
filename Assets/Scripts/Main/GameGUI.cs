using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour 
{
	public Coin coin;
	private int betValue = 1;
	public GUIText betText;
	public int bankAccount = 100;
	public GUIText bankAccountText;
	public GUIText choiseText;
	public GUIText winText;
	private string choise;
	private bool canRestart;
	public GUIText restartText;
	public GUIText gameOverText;
	private int isTossing;
	private bool firstTime;
	private bool isGameOver;
	
	// Use this for initialization
	void Start () 
	{
		betText.text = "Bet value: $ " + betValue;
		choise = "HEAD";
		choiseText.text = "CHOISE:" + choise;
		winText.enabled = false;
		canRestart = false;
		
		gameOverText.enabled = false;
		restartText.enabled = false;	
		bankAccountText.text = "Bank account: $" + bankAccount;
		isTossing = -1;
		firstTime = false;
		isGameOver = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (canRestart)
		{
			if (Input.GetKey (KeyCode.R))
			{
				Application.LoadLevel(2);
			}
		}
	}
	
	void OnGUI () 
	{
		// Make a background box for bank account
		GUI.Box(new Rect(10,10,200,80),"");
		
		// Make a background box for bet amount
		GUI.Box(new Rect(Screen.width - 130,10,120,80),"");
								
		if (GUI.Button(new Rect(Screen.width - 70, 60, 50, 20),"+"))
		{
			if (betValue < bankAccount)
			{
				if(betValue < 10)
				{
					betValue++;
					betText.text = "Bet value: $ " + betValue;
					
					PayTable();
				}
			}
		}
		
		if (GUI.Button(new Rect(Screen.width - 120, 60, 50, 20),"-"))
		{
			if(betValue > 1)
			{
				betValue--;
				betText.text = "Bet value: $ " + betValue;		
				
				PayTable();		
			}
		}
		
		// Make a background box for the bet choises
		GUI.Box (new Rect(10, 100, 200, 80), "");
		
		if (GUI.Button(new Rect(20, 150, 50, 20),"HEAD"))
		{
			choise = "HEAD";
			choiseText.text = "CHOISE:" + choise;
		}
		
		if (GUI.Button(new Rect(80, 150, 50, 20),"TAIL"))
		{
			choise = "TAIL";
			choiseText.text = "CHOISE:" + choise;
		}
		
		if (GUI.Button(new Rect(140, 150, 50, 20),"SIDE"))
		{
			choise = "SIDE";
			choiseText.text = "CHOISE:" + choise;
		}		
					
		PayTable();
		
		// wait/toss text box
		GUI.Box (new Rect(Screen.width / 2 - 50, 10 , 100, 50),"");
		
		Debug.Log("firstTime: " + firstTime);
		// win/lose text
		if(firstTime)
		{
			if (isTossing == 0)
				GUI.Box (new Rect(Screen.width / 2 - 175, Screen.height / 2 - 50 , 350, 100),"");
			Debug.Log("firstTime1: " + firstTime);
			
			if (isGameOver)
			{
				GUI.Box (new Rect(Screen.width / 2 - 175, Screen.height / 2 + 55 , 350, 100),"");
				GUI.Box (new Rect(Screen.width / 2 - 175, Screen.height / 2 + 160 , 350, 100),"");
			}			
		}
		
	}	
	
	private void PayTable()
	{
		GUI.Box (new Rect(Screen.width - 130, 100, 120, 130),"PAYTABLE");
		
		GUI.Label(new Rect(Screen.width - 120,130, 130, 20),"                    ");
		GUI.Label(new Rect(Screen.width - 120,160, 130, 20),"                    ");
		GUI.Label(new Rect(Screen.width - 120,190, 130, 20),"                    ");		
		
		GUI.Label(new Rect(Screen.width - 120,130, 130, 20),"HEAD:  $" + (2 * betValue));
		GUI.Label(new Rect(Screen.width - 120,160, 130, 20),"TAIL :   $" + (2 * betValue));
		GUI.Label(new Rect(Screen.width - 120,190, 130, 20),"SIDE:   $" + (200 * betValue));	
	}
	
	public void AnalizeResult(string result)
	{
		Debug.Log ("ANALIZE RESULT");
	
		firstTime = true;
		//isTossing = false;
		
		// if you win
		if (choise == result)
		{
			winText.enabled = true;
			winText.text = "YOU WIN!";
			switch(result)
			{
				case "HEAD":
				case "TAIL":
					bankAccount += betValue * 2;
				break;
				
				case "SIDE":
					bankAccount += betValue * 200;
				break;
			}
		}
		else
		{
			// you lose
			winText.enabled = true;
			winText.text = "YOU LOSE!";						
			bankAccount-= betValue;
		}		
		
		bankAccountText.text = "Bank account: $" + bankAccount;
				
		//DelayWinResult();
	}
	
	public void Tossing(int toss)
	{
		isTossing = toss;
	}
	/*
	private IEnumerator DelayWinResult () 
	{
		yield return new WaitForSeconds(2);
		winText.enabled = false;
	}	
	*/
	public bool CheckBankAccount()
	{
		// if you don't have enough money...
		if (bankAccount < betValue)
		{
			// restart the game...
			canRestart = true;
			
			gameOverText.enabled = true;
			restartText.enabled = true;
			
			isGameOver = true;
			
			return false;
		}
		else
		{
			return true;
		}
	}	
}
