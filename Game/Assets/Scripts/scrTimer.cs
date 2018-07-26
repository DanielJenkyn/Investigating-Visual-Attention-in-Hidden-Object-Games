using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrTimer : MonoBehaviour {

	private float currentTime = 0, endTime = 180;//Three minutes

	private scrLevelManager levelManager;
	private scrClickControl clickControl;

	// Use this for initialization
	void Start() {
		levelManager = GameObject.FindObjectOfType<scrLevelManager>();
		clickControl = GameObject.FindObjectOfType<scrClickControl>();
		StartCoroutine(timer(endTime));
	}
	
	// Update is called once per frame
	void Update() {
		currentTime += Time.deltaTime;
	}

	IEnumerator timer(float delay) {
		yield return new WaitForSeconds(delay);
		scrDataManager.saveData(SceneManager.GetActiveScene().name, "", CurrentTime, clickControl.MouseClicksLevel);
     	levelManager.loadNextLevel();
 	}

	public float CurrentTime {
		get {
			return currentTime;
		}
	}
}
