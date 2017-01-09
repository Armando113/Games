using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen_Buttons : MonoBehaviour {

	public Button NoAds_B;
	public Button Store_B;
	public Button Challenges_B;
	public Button Play_B;
    public Button Home_B;
    public Image ChallengesDialog_B;

	public GameObject NoAds_G;
	public GameObject Store_G;
	public GameObject Challenges_G;
	public GameObject Play_G;
	public GameObject ChallengesDialog_G;

	public GameObject ChallengesAll;


	//Loading Scene--------------------
	public Image FondoBlanco;
	float timer;
	//---------------------------------

	//Bools------------------------------
	//bool ChallengeisPressed = false;
	bool StoreIsPressed = false;
	bool PlayIsPressed = false;
	bool SettingsIsPressed = false;
	bool CreditsIsPressed = false;
    bool HomeIsPressed = false;
	//---------------------------------

	//Movimiento del Fondo--------------------
	public RawImage FondoEdificio;
	float scrollSpeed = 0.04f;

	public RawImage FondoCielo;
	float scrollSpeed2 = 0.005f;
	//---------------------------------------


	void Start () {
		FondoBlanco.CrossFadeAlpha (0, 0.3f, false);

		ChallengesAll.SetActive (false);
	}

	void Update () {

		//---------------Load Scene de Store----------------------
		if(StoreIsPressed == true){
			timer += Time.deltaTime;
			FondoBlanco.CrossFadeAlpha(1,0.1f, false);
			if (timer > 0.2f) {
				timer = 0.0f;
				SceneManager.LoadScene("Store");
			}
		}//------------------------------------------------------	

		//---------------Load Scene de Settings----------------------
		if(SettingsIsPressed == true){
			timer += Time.deltaTime;
			FondoBlanco.CrossFadeAlpha(1,0.1f, false);
			if (timer > 0.2f) {
				timer = 0.0f;
				SceneManager.LoadScene("Settings");
			}
		}//------------------------------------------------------	

		//---------------Load Scene de Play----------------------
		if(PlayIsPressed == true){
			timer += Time.deltaTime;
			FondoBlanco.CrossFadeAlpha(1,0.1f, false);
			if (timer > 0.2f) {
				timer = 0.0f;
				SceneManager.LoadScene("Game");
			}
		}//------------------------------------------------------	

		//---------------Load Scene de Credits----------------------
		if(CreditsIsPressed == true){
			timer += Time.deltaTime;
			FondoBlanco.CrossFadeAlpha(1,0.1f, false);
			if (timer > 0.2f) {
				timer = 0.0f;
				SceneManager.LoadScene("Credits");
			}
		}//------------------------------------------------------	
        if (HomeIsPressed == true)
        {
            timer += Time.deltaTime;
            FondoBlanco.CrossFadeAlpha(1, 0.1f, false);
            if (timer > 0.2f)
            {
                timer = 0.0f;
                SceneManager.LoadScene("StartMenu");
            }
        }
        //Movimiento del Fondo------------------------------------------------------------------------------------------------
        float offset = Time.time * scrollSpeed;
		FondoEdificio.GetComponent<RawImage> ().uvRect = new Rect ((new Vector2 (0.0f, offset)), new Vector2 (1.0f, 0.3f));

		float offset2 = Time.time * scrollSpeed2;
		FondoCielo.GetComponent<RawImage> ().uvRect = new Rect ((new Vector2 (0.0f, offset2)), new Vector2 (1.0f, 0.3f));
		//-------------------------------------------------------------------------------------------------------------------


	}

	public void Play(){
		PlayIsPressed = true;
	}

	public void NoAds(){
		Destroy(NoAds_G);
		//Store_B.transform.localPosition = new Vector2 (0.0f,-112.3f);
	}

	public void Challenges(){
		ChallengesAll.SetActive (true);
			
	}

	public void Settings(){
		SettingsIsPressed = true;
	}

	public void Store(){
		StoreIsPressed = true;
	}

	public void Credits(){
		CreditsIsPressed = true;
	}

	public void BackChallenge(){
		ChallengesAll.SetActive (false);
	}
    public void Home()
    {
        HomeIsPressed = true;
    }
}
