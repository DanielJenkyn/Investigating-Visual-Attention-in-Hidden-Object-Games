using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scrFade : MonoBehaviour {

	public Image whiteScreen;

	// Use this for initialization
	void Start () {
		whiteScreen.canvasRenderer.SetAlpha (0.0f);
		FadeIn();
	}

	// Update is called once per frame
	void Update () {
	}

	public void FadeIn() {
		whiteScreen.CrossFadeAlpha (1.0f, 3.0f, true);
	}

	public void FadeOut() {
		whiteScreen.CrossFadeAlpha (0.0f, 3.0f, true);
	}
}
