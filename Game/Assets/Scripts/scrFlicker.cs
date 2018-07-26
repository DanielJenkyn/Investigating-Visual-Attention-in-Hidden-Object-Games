using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFlicker : MonoBehaviour {
	private SpriteRenderer sRen;
	private int flickerLength,flickerDelay;

	// Hz, the number of cycles
	private float cycleHz = 30, dtime = 0, toggletime;

	void Start () {
		sRen = gameObject.GetComponent<SpriteRenderer>();

		Color alpha = sRen.color;
		alpha.a = 0.35f;
		sRen.color = alpha;

		flickerLength = Random.Range(1, 3);
		flickerDelay = Random.Range(5, 10);
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		toggletime += Time.deltaTime;

		// Flicker will occur from 1-3 seconds
		if(toggletime < flickerLength) { 
			startFlicker();
		} else if (toggletime > flickerDelay) {
			// Reset timer after 5-10 seconds have passed
			// Nothing will occur between 2-4 seconds
			toggletime = 0; 
		}
	}

	void startFlicker() {
		// Update frequency time-step
		dtime += Time.deltaTime;

		// Sample the wave at a specific time.
		double wave = Mathf.Sin((dtime * 2.0f * Mathf.PI) * cycleHz);

		// Cycle between enabling based on the wave
		if(wave > 0.0f) {
			GetComponent<SpriteRenderer>().enabled = true;
		} else {
			GetComponent<SpriteRenderer>().enabled = false;
		}

		// Prevents dtime from climbing to infinity
		if (wave == 0.0f) {
			dtime = 0.0f;
		}
	}
}