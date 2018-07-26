using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCameraControl : MonoBehaviour {

	public float panSpeed = 8f;
	public float panBorderThickness = 10f;
	public Vector2 panLimit;
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		//Up
		if(Input.mousePosition.y >= Screen.height - panBorderThickness) {
			pos.y += panSpeed * Time.deltaTime;
		}

		//Down
		if(Input.mousePosition.y <= panBorderThickness) {
			pos.y -= panSpeed * Time.deltaTime;
		}

		//Right
		if(Input.mousePosition.x >= Screen.width - panBorderThickness) {
			pos.x += panSpeed * Time.deltaTime;
		}

		//Left
		if(Input.mousePosition.x <= panBorderThickness) {
			pos.x -= panSpeed * Time.deltaTime;
		}

		pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x); 
		pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y); 

		transform.position = pos;
	}
}
