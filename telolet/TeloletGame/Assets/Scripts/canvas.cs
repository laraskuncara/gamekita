using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class canvas : MonoBehaviour {

	Text scoreText;
	static bool needUpdateScoreTex;
	static float scorePoint;

	static float maxHealth = 100;
	static float curHealth = 75;
	float healthBarLength;

	public Texture2D bgImage; 
	public Texture2D fgImage; 

	// Use this for initialization
	void Start () {
		scoreText = GameObject.Find("score").GetComponent<Text> ();
		scoreText.text = "0";
		needUpdateScoreTex = true;

		healthBarLength = Screen.width / 2;
	}

	public void SetScore(float newScore)
	{
		scorePoint = scorePoint + newScore;
		needUpdateScoreTex = true;
	}


	public float GetHealthBar()
	{
		// should be deleted later
		return curHealth;
	}
		
	public void SetHealthBar(float newHealth)
	{
		curHealth = curHealth - newHealth;

		if (curHealth < 0.0f) {
			curHealth = 0.0f;
		}

		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}
		
		healthBarLength = healthBarLength * (curHealth / (float)maxHealth);
	}

	void OnGUI () {
		// http://answers.unity3d.com/questions/306447/c-health-bar.html
		// Create one Group to contain both images
		// Adjust the first 2 coordinates to place it somewhere else on-screen
		GUI.BeginGroup (new Rect (0,0, healthBarLength,32));

		// Draw the background image
		GUI.Box (new Rect (0,0, healthBarLength,32), bgImage);

		// Create a second Group which will be clipped
		// We want to clip the image and not scale it, which is why we need the second Group
		GUI.BeginGroup (new Rect (0,0, curHealth / maxHealth * healthBarLength, 32));

		// Draw the foreground image
		GUI.Box (new Rect (0,0,curHealth / maxHealth * healthBarLength,32), fgImage);

		// End both Groups
		GUI.EndGroup ();

		GUI.EndGroup ();
	}

	// Update is called once per frame
	void Update () {
		if (needUpdateScoreTex) {
//			print (scoreText.text);
			scoreText.text = scorePoint.ToString();
			needUpdateScoreTex = false;
		}
	}
}
