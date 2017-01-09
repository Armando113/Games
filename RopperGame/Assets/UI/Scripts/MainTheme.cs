using UnityEngine;
using System.Collections;

public class MainTheme : MonoBehaviour {

	public AudioSource MainThemeMusic;

	bool IsPressed = false;

	public static MainTheme i;

	void Awake(){
		if (i == null) {
			i = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
	}

	public void StopMusic(){
		if (IsPressed) {
			MainThemeMusic.Stop ();
			IsPressed = false;
		} else {
			MainThemeMusic.Play ();
			IsPressed = true;
		}
	}
}
