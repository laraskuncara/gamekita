using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	canvas canvasScript;
	vehicle bus;
	bool endGame;

	// Use this for initialization
	void Start () {
		canvasScript = new canvas ();
		bus = new vehicle ();
		endGame = false;
	}

	public void CheckGameOver(){
		// will use health status from child
		if(canvasScript.GetHealthBar()<=0)
			endGame = true;
	}

	// Update is called once per frame
	void Update () {
		//never use loop, it's already looping

		if (Input.GetMouseButtonDown (1)) {
			canvasScript.SetHealthBar (2);
		}

		if (endGame != true) {
			CheckGameOver ();

			//update health and score
//			canvasScript.SetHealthBar(getHealth());
//			canvasScript.SetScore(getScore());

			//check bus and kid when touching screen
			if (Input.GetMouseButtonDown (0)) {
//				print("GetBusState "+bus.GetBusState());
				if(bus.GetBusState()){
					canvasScript.SetScore (100);
				}
			}
		} else {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("telolet.mainmenu");
		}
	}
}
