using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScreen_Buttons : MonoBehaviour {

	public Button Spanish_B;
	public Button French_B;
	public Button Japanese_B;
	public Button English_B;
	public Button Italian_B;
	public Button Music_B;
	public Button Sounds_B;
	public Button Facebook_B;
	public Button Twitter_B;

	public GameObject Spanish_G;
	public GameObject French_G;
	public GameObject Japanese_G;
	public GameObject English_G;
	public GameObject Italian_G;
	public GameObject Music_G;
	public GameObject Sounds_G;
	public GameObject Facebook_G;
	public GameObject Twitter_G;

	//------Music Buttons--------------
	public Sprite Music_ON;
	public Sprite Music_OFF;

	//------Sounds Buttons--------------
	public Sprite Sounds_ON;
	public Sprite Sounds_OFF;


	public Image Settings_Title;

	//Loading Scene--------------------
	public Image FondoBlanco;
	float timer;
	//-----------------------------------

	//Bools------------------------------
	bool ReturnIsPressed = false;
	bool MusicIsPressed = true;
	bool SoundsIsPressed = true;
	//---------------------------------


	//Movimiento del Fondo--------------------
	public RawImage Fondo;
	float scrollSpeed = 0.07f;
	//---------------------------------------




	void Start () {
		FondoBlanco.CrossFadeAlpha(0,0.2f, false);
	}

	void Update () {


		//Movimiento del Fondo------------------------------------------------------------------------------------------------
		float offset = Time.time * scrollSpeed;
		Fondo.GetComponent<RawImage> ().uvRect = new Rect ((new Vector2 (0.0f, offset)), new Vector2 (1.0f, 1.4f));
		//-------------------------------------------------------------------------------------------------------------------




		//---------------Load Scene de Start Menu----------------------
		if(ReturnIsPressed == true){
			timer += Time.deltaTime;
			FondoBlanco.CrossFadeAlpha(1,0.1f, false);
			if (timer > 0.2f) {
				timer = 0.0f;
				SceneManager.LoadScene("StartMenu");
			}
		}
		//------------------------------------------------------


	}
	public void Spanish(){
	}
	public void French(){
	}
	public void Japanese(){
	}
	public void English(){
	}
	public void Italian(){
	}

	public void Music(){
		if (MusicIsPressed == false) {
			Music_B.image.overrideSprite = Music_ON;
			MusicIsPressed = true;
		} else {
			Music_B.image.overrideSprite = Music_OFF;
			MusicIsPressed = false;
		}
	}

	public void Sounds(){
		if (SoundsIsPressed == false) {
			Sounds_B.image.overrideSprite = Sounds_ON;
			SoundsIsPressed = true;
		} else {
			Sounds_B.image.overrideSprite = Sounds_OFF;
			SoundsIsPressed = false;
		}
	}

	public void Facebook(){
	}

	public void Twitter(){
	}

	public void Return(){
		ReturnIsPressed = true;
	}
}
