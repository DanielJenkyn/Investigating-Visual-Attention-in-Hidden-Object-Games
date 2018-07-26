using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrLevelManager : MonoBehaviour {

	public void loadLevel(string name) {
		if(!SceneManager.GetSceneByName(name).IsValid()) {
			StartCoroutine(WaitAndLoadScene("Main Screen/Main"));
		}
		StartCoroutine(WaitAndLoadScene(name));
	}

	public void loadNextLevel() {
		StartCoroutine(WaitAndLoadScene());
	}

	public void quitGame() {
		scrDataManager.writeCSV();
		Debug.Log("Quit requested");
		Application.Quit();
	}

	IEnumerator WaitAndLoadScene() {
		yield return new WaitForSeconds(0.5f);

		if((SceneManager.GetActiveScene().buildIndex + 1) < SceneManager.sceneCountInBuildSettings) {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		} else {
			StartCoroutine(WaitAndLoadScene("Main Screen/Main"));
		}
	}

	IEnumerator WaitAndLoadScene(string name) {
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(name);
	}
}