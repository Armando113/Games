using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System;
using System.Collections.Generic;

public class Ads : MonoBehaviour {

	DateTime currentDate;
	DateTime oldDate;

	public Text CurrentCoins;
	public GameObject GiftCanvas;


	int[] RandomTimes = new int[]{5, 15, 60, 180};

	string differenceHours;
	string differenceMinutes;
	TimeSpan differenceTime;

	public Text HoursLeft;
	public Text MinutesLeft;
	public GameObject HoursLeft_G;
	public GameObject MinutesLeft_G;


	// Use this for initialization
	void Start () {
		GiftCanvas.SetActive (false);

		//PlayerPrefs.DeleteAll ();

		//Checa si ya existe una fecha de la ultima vez que se agarró el Regalo, sino crea una en cuando empieze la app
		if (!PlayerPrefs.HasKey ("oldDate")) {
			PlayerPrefs.SetString ("oldDate", System.DateTime.Now.ToBinary ().ToString ());
			long temp = Convert.ToInt64(PlayerPrefs.GetString("oldDate"));
			DateTime oldDate = DateTime.FromBinary(temp);
		}
		if (!PlayerPrefs.HasKey ("MinutesToWait")) {
			PlayerPrefs.SetInt ("MinutesToWait", 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		//Siempre checa la hora actual
		currentDate = System.DateTime.Now;

		//Siempre está actualizando el valor de las monedas
		CurrentCoins.text = PlayerPrefs.GetInt ("Coins").ToString("D5");
	
	}

	public void Gift(){
		GiftCanvas.SetActive (true);

		//Agarra el String Global de la última hora activada (oldDate) y lo convierte en un long
		long temp = Convert.ToInt64(PlayerPrefs.GetString("oldDate"));

		//El long se convierte en fecha y se le asigna a old Date
		//Si no ha cambiado el string Global siempre se asignará el mismo string, por lo tanto es la misma fecha
		oldDate = DateTime.FromBinary(temp);


		Debug.Log (oldDate.AddMinutes (PlayerPrefs.GetInt("MinutesToWait")));
		differenceTime = oldDate.AddMinutes (PlayerPrefs.GetInt("MinutesToWait")).Subtract (currentDate).Duration();

		if (oldDate.AddMinutes (PlayerPrefs.GetInt("MinutesToWait")) < currentDate) {
			
			differenceHours = 0.ToString ("D2");
			HoursLeft_G.SetActive (false);

			differenceMinutes = 0.ToString ("D2");

			PlayerPrefs.SetString ("HoursLeft", 0.ToString ("D2"));
			PlayerPrefs.SetString ("MinutesLeft", 0.ToString ("D2"));

			HoursLeft.text = (PlayerPrefs.GetString ("HoursLeft")) + " H";
			MinutesLeft.text = (PlayerPrefs.GetString ("MinutesLeft")) + " M";
		} 
		else {
			
			if (differenceTime.Hours == 0) {
				HoursLeft_G.SetActive (false);
			} else {
				HoursLeft_G.SetActive (true);
				differenceHours = new DateTime(differenceTime.Ticks).ToString("HH");
			}
			differenceMinutes = new DateTime(differenceTime.Ticks).ToString("mm");

			PlayerPrefs.SetString ("HoursLeft", differenceHours);
			PlayerPrefs.SetString ("MinutesLeft", differenceMinutes);

			HoursLeft.text = (PlayerPrefs.GetString("HoursLeft")) + " H";
			MinutesLeft.text = (PlayerPrefs.GetString("MinutesLeft")) + " M";
		}


	}

	public void BackAds(){
		GiftCanvas.SetActive (false);
	}

	public void ShowAd()
	{
		//Agarra el String Global de la última hora activada (oldDate) y lo convierte en un long
		long temp = Convert.ToInt64(PlayerPrefs.GetString("oldDate"));

		//El long se convierte en fecha y se le asigna a old Date
		//Si no ha cambiado el string Global siempre se asignará el mismo string, por lo tanto es la misma fecha
		DateTime oldDate = DateTime.FromBinary(temp);


		//Si la ultima fecha que agarró el Regalo + un tiempo determinado es antes que la fecha actual, se activa el Regalo de nuevo
		if (oldDate.AddMinutes (PlayerPrefs.GetInt("MinutesToWait")) < currentDate) {
			

			//Se le agrega monedas al jugador
			PlayerPrefs.SetInt ("Coins", (PlayerPrefs.GetInt ("Coins") + 100));

			// Se muestra el Ad
			//if (Advertisement.IsReady ()) {
			//	Advertisement.Show ();
			//}
			//Se sobreescribe el string Global de la fecha de OldDate SOLO EL STRING, LA ASIGNACIÓN DE LA FECHA ES ARRIBA DE LA FUNCIÓN
			PlayerPrefs.SetString ("oldDate", System.DateTime.Now.ToBinary ().ToString ());

			//Agarra el String Global de la última hora activada (oldDate) y lo convierte en un long
			temp = Convert.ToInt64(PlayerPrefs.GetString("oldDate"));

			//El long se convierte en fecha y se le asigna a old Date
			//Si no ha cambiado el string Global siempre se asignará el mismo string, por lo tanto es la misma fecha
			oldDate = DateTime.FromBinary(temp);

			int RandomValue = (int)UnityEngine.Random.Range (0, RandomTimes.Length);
			PlayerPrefs.SetInt ("MinutesToWait", RandomTimes[RandomValue]);

			Debug.Log("new date: " + (oldDate.AddMinutes (PlayerPrefs.GetInt("MinutesToWait"))));

			differenceTime = oldDate.AddMinutes (PlayerPrefs.GetInt("MinutesToWait")).Subtract (currentDate).Duration();

			if (oldDate.AddMinutes (PlayerPrefs.GetInt("MinutesToWait")) < currentDate) {

				differenceHours = 0.ToString ("D2");
				HoursLeft_G.SetActive (false);

				differenceMinutes = 0.ToString ("D2");

				PlayerPrefs.SetString ("HoursLeft", 0.ToString ("D2"));
				PlayerPrefs.SetString ("MinutesLeft", 0.ToString ("D2"));

				HoursLeft.text = (PlayerPrefs.GetString ("HoursLeft")) + " H";
				MinutesLeft.text = (PlayerPrefs.GetString ("MinutesLeft")) + " M";
			} 
			else {

				if (differenceTime.Hours == 0) {
					HoursLeft_G.SetActive (false);
				} else {
					HoursLeft_G.SetActive (true);
					differenceHours = new DateTime(differenceTime.Ticks).ToString("HH");
				}
				differenceMinutes = new DateTime(differenceTime.Ticks).ToString("mm");

				PlayerPrefs.SetString ("HoursLeft", differenceHours);
				PlayerPrefs.SetString ("MinutesLeft", differenceMinutes);

				HoursLeft.text = (PlayerPrefs.GetString("HoursLeft")) + " H";
				MinutesLeft.text = (PlayerPrefs.GetString("MinutesLeft")) + " M";
			}
		
		}
	}
}
