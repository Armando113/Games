using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreScreen_Buttons : MonoBehaviour {

	public Button Characters_B;
	public Button Powerups_B;
	public Button Coins_B;
	public Button Return_B;
	public Button CharacterSelector_B;

	public GameObject Characters_G;
	public GameObject Powerups_G;
	public GameObject Coins_G;
	public GameObject Return_G;
	public GameObject CharacterSelector_G;

	//------Characters Buttons--------------
	public Sprite Characters_ON;
	public Sprite Characters_OFF;

	//------Powerups Buttons--------------
	public Sprite Powerups_ON;
	public Sprite Powerups_OFF;

	//------Coins Buttons--------------
	public Sprite Coins_ON;
	public Sprite Coins_OFF;


	public Image Characters_Title;
	public Image Powerups_Title;
	public Image Coins_Title;

	//Loading Scene--------------------
	public Image FondoBlanco;
	float timer;
	//-----------------------------------

	//Bools------------------------------
	bool ReturnIsPressed = false;
	bool CharacterIsPressed = true;
	bool PowerupsIsPressed = false;
	bool CoinsIsPressed = false;
	//---------------------------------


	//Movimiento del Fondo--------------------
	public RawImage Fondo;
	float scrollSpeed = 0.07f;
	//---------------------------------------



	//Movimiento de Canvas----------------
	public GameObject AllCanvas;
	public Transform Position1;
	public Transform Position2;
	public Transform Position3;
	float speedCanvas = 3000.0f;
	float step;
	//---------------------------------------


	//Selección de Personajes--------------------
	int Index = 0;
	string[] AnimationsArray = new string[]{"RopperSelector", "SimioBlocked", "TarzanBlocked", "PenaBlocked", "TrumpBlocked"};
	string[] AnimationsSelectedArray = new string[]{"RopperSelected", "SimioSelected", "TarzanSelected", "PenaSelected", "TrumpSelected"};
	string[] AnimationsBlockedArray = new string[]{"RopperBlocked", "SimioSelector", "TarzanSelector", "PenaSelector", "TrumpSelector"};
	string[] StatusArray = new string[]{"RopperStatus", "SimioStatus", "TarzanStatus", "PenaStatus", "TrumpStatus"};

	public Text CharacterName;
	string[] CharacterNameArray =  new string[]{"Mr. ROPPER", "SIMIO", "GEORGE", "DON ENRIQUE", "DONALD"};
	public Text CharacterDescription;
	string[] CharacterDescriptionArray = new string[]{"Hardworker and height-fearless", "The real natural climber", "Somewhat dumb, somewhat determined", "Nothing is wrong with him (yeah sure)", "You know you need the orange power"};

	int[] PriceArray = new int[]{0, 200, 600, 1800, 2500};
	public Text Price;
	public GameObject Price_G;

	int CurrentCharacter = 0;
	public GameObject NotEnoughDialog;
	public GameObject CharacterCoin;

	public Text CurrentCoins;

	//--------------------------------------------

	public GameObject PushButton1;
	public GameObject PushButton2;
	public GameObject PushButton3;



	void Start () {
		PlayerPrefs.GetString("RopperStatus" , AnimationsArray[0]);
		PlayerPrefs.GetString("SimioStatus" , AnimationsArray[1]);
		PlayerPrefs.GetString("TarzanStatus" , AnimationsArray[2]);
		PlayerPrefs.GetString("PenaStatus" , AnimationsArray[3]);
		PlayerPrefs.GetString("TrumpStatus" , AnimationsArray[4]);

		FondoBlanco.CrossFadeAlpha(0,0.2f, false);
		PlayerPrefs.SetInt ("Coins", 50000);
	}

	void Update () {
		CurrentCoins.text = PlayerPrefs.GetInt ("Coins").ToString("D5");

		//Debug.Log(PlayerPrefs.GetString("TarzanStatus"));

		//Movimiento de Canvas----------------------------------------------------------------------------------------------------
		step = speedCanvas * Time.deltaTime;

		if (CharacterIsPressed) {
			AllCanvas.transform.position = Vector3.MoveTowards (AllCanvas.transform.position, Position1.transform.position, step);
		}
		if (PowerupsIsPressed) {
			AllCanvas.transform.position = Vector3.MoveTowards (AllCanvas.transform.position, Position2.transform.position, step);
		}
		if (CoinsIsPressed) {
			AllCanvas.transform.position = Vector3.MoveTowards (AllCanvas.transform.position, Position3.transform.position, step);
		}
		//----------------------------------------------------------------------------------------------------------------------



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



		//---------------Change Character Animation and Text---------------------

		CharacterName.text = CharacterNameArray [Index];
		CharacterDescription.text = CharacterDescriptionArray [Index];

		if (CurrentCharacter == Index) {
			CharacterSelector_B.animator.Play (AnimationsSelectedArray [Index]);
		} else {
			if (PlayerPrefs.GetString (StatusArray [Index]) != AnimationsBlockedArray [Index]) {
				
				CharacterSelector_B.animator.Play (AnimationsArray [Index]);
			} else {
				CharacterSelector_B.animator.Play (PlayerPrefs.GetString (StatusArray [Index]));
				PriceArray [Index] = 0;
			}
		}

		Price.text = PriceArray [Index].ToString();
		if (PriceArray [Index] == 0) {
			Price_G.SetActive (false);
			CharacterCoin.SetActive (false);
		} else {
			CharacterCoin.SetActive (true);
			Price_G.SetActive (true);
		}
		//----------------------------------------------------------------------

		if(Input.GetKey(KeyCode.R)){
			PlayerPrefs.DeleteAll();
		}

	}


			
	//Charracter Selection--------------------------------------
	public void Right_Characters(){
		//AQUI SOLO SUMA EN EL ARREGLO DE SPRITES DE PERSONAJES
		if ((Index+1) >= AnimationsArray.Length) {
			Index = 0;
		}else {
			Index++;
		}

	}

	public void Left_Characters(){
		//AQUI SOLO SUMA EN EL ARREGLO DE SPRITES DE PERSONAJES
		if ((Index == (AnimationsArray.Length-AnimationsArray.Length))) {
			Index = AnimationsArray.Length-1;
		} else {
			Index--;
		}
	}

	public void SelectCharacter(){

		if (PlayerPrefs.GetInt("Coins") >= PriceArray[Index]) {
			CurrentCharacter = Index;
			//AnimationsArray[Index] = PlayerPrefs.SetString(StatusArray[Index], AnimationsBlockedArray[Index]);
			AnimationsArray[Index] = AnimationsBlockedArray[Index];
			PlayerPrefs.SetInt ("Coins", (PlayerPrefs.GetInt ("Coins") - PriceArray [Index]));

			PriceArray [Index] = 0;
			PushButton3.GetComponent<AudioSource> ().Play();

			PlayerPrefs.SetInt ("Character", Index);
			PlayerPrefs.SetString(StatusArray[Index], AnimationsBlockedArray[Index]);
		} 
		else{
			NotEnoughDialog.SetActive (true);
			PushButton1.GetComponent<AudioSource> ().Play();
		}
			
		//AQUI ES DONDE VA LO DE LA VARIABLE GLOBAL Y LA QUE DETERMINA QUE PERSONAJE SALDRÁ CUANDO JUEGAS
		//Puedes utilizar la variable Index para cargar diferentes personajes
		//0-MrRopper
		//1-Chimp
		//2-Tarzan
		//3-Pena
		//4-Trump
	}
		



	//Menu Navigation-----------------------------------------
	public void Characters(){
		if (CharacterIsPressed == false) {
			Characters_B.image.overrideSprite = Characters_ON;
			Powerups_B.image.overrideSprite = Powerups_OFF;
			Coins_B.image.overrideSprite = Coins_OFF;
			CharacterIsPressed = true;
			PowerupsIsPressed = false;
			CoinsIsPressed = false;
		}
	}

	public void Powerups(){
		if (PowerupsIsPressed == false) {
			//Debug.Log ("hey");
			Powerups_B.image.overrideSprite = Powerups_ON;
			Characters_B.image.overrideSprite = Characters_OFF;
			Coins_B.image.overrideSprite = Coins_OFF;
			CharacterIsPressed = false;
			PowerupsIsPressed = true;
			CoinsIsPressed = false;
		}
	}

	public void Coins(){
		if (CoinsIsPressed == false) {
			Coins_B.image.overrideSprite = Coins_ON;
			Characters_B.image.overrideSprite = Characters_OFF;
			Powerups_B.image.overrideSprite = Powerups_OFF;
			CharacterIsPressed = false;
			PowerupsIsPressed = false;
			CoinsIsPressed = true;
		}
	}
	//------------------------------------------------------------

	public void Return(){
		ReturnIsPressed = true;
	}
	public void BackNotEnough(){
		NotEnoughDialog.SetActive (false);
	}
}
