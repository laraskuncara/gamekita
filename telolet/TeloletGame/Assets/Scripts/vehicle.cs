using UnityEngine;
using System.Collections;

public class vehicle : MonoBehaviour {

	public float speed;
	Vector3 newpos;

	bool vehicleState;

	// Use this for initialization
	void Start () {
		speed = 0.01f;
		vehicleState = false;
	}

	public bool GetBusState ()
	{
		return vehicleState;
	}

	void BacktoStartPoint()
	{
		newpos = new Vector3(0, 1, 0);
		transform.position = newpos;
	}

	// Update is called once per frame
	void Update () {
		newpos = transform.position;
		newpos.y -= speed;
		transform.position = newpos;
//		print (transform.position);

		//first position bus can be touched
		if (transform.position.y <= -3.0)
			vehicleState = true;
		
		if (transform.position.y <= -13.0)
			vehicleState = false;
		
		if (transform.position.y <= -17.0)
			BacktoStartPoint ();
	
	}
}
