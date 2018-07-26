using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrClickControl : MonoBehaviour {

	public GameObject uiObject;
	public GameObject uiObjectTxt;
	public GameObject flickerPrefab;
	private GameObject flicker;

	public static int itemsFound;
	public int itemsNeeded = 3;
	private int mouseClicksLevel;

	private scrLevelManager levelManager;
	private scrTimer timer;

	void Start() {
		itemsFound = 0;
		mouseClicksLevel = 0;
		uiObject.GetComponent<Animator>().enabled = false;

		levelManager = GameObject.FindObjectOfType<scrLevelManager>();
		timer = GameObject.FindObjectOfType<scrTimer>();

		flicker = Instantiate(flickerPrefab, this.transform.position, Quaternion.identity);
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			mouseClicksLevel++;
			foundObject();
		}

		if(itemsFound == itemsNeeded) {
			levelManager.loadNextLevel();
		}
	}

	public void foundObject() {
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		
		if(hit.collider != null) { 
			if(hit.collider.gameObject==gameObject) {

				scrDataManager.saveData(SceneManager.GetActiveScene().name, gameObject.name, timer.CurrentTime, mouseClicksLevel);
				Destroy(gameObject); 
				itemsFound++;

				uiObject.GetComponent<Animator>().enabled = true;

				Destroy(uiObject, 0.3f);
				Destroy(uiObjectTxt);
				Destroy(flicker);
			} 
		}
	}

	public int MouseClicksLevel {
		get {
			return mouseClicksLevel;
		}
	}
}