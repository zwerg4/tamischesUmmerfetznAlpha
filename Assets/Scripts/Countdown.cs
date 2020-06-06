using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


public class Countdown : MonoBehaviour
{

    public GameObject Countdown_;
    public AudioSource getReady;
    public AudioSource goAudio;
    public AudioSource inGameMusic;
    public GameObject LapTimer;
    public GameObject CarControls;
    public GameObject Schranke;
    public GameObject WRUserLabel;
    public GameObject WRmin;
    public GameObject WRsec;
    public GameObject WRmilli;
    
    
    public GameObject WRInput;
    public GameObject WRSubmit;
    public GameObject newWRLabel;
    
    public static WorldRecord WR = new WorldRecord("no Internet Connection", 00,00,0);
    
    
    // Start is called before the first frame update
    void Start()
    {
    	//RestClient.Put("https://tamischesummerfetzn.firebaseio.com/.json", WR);
    
        WRInput.SetActive(false);
    	WRSubmit.SetActive(false);
        newWRLabel.SetActive(false);
        	
    	WRUserLabel.GetComponent<Text>().text = "" + WR.username;
    	
        if(WR.sec <= 9)
        {
             WRsec.GetComponent<Text>().text = "0" + WR.sec + ".";
        }
        else
    	{
            WRsec.GetComponent<Text>().text = "" + WR.sec + ".";
    	}

    	if(WR.min <= 9)
    	{
            WRmin.GetComponent<Text>().text = "0" + WR.min + ":";
    	}
    	else
    	{
            WRmin.GetComponent<Text>().text = "" + WR.min + ":";
   	}

    	WRmilli.GetComponent<Text>().text = "" + WR.milli;
		    
    	checkWR();    	
    	
    	StartCoroutine(CountStart());    
    }
    
    IEnumerator CountStart()
    {
    	yield return new WaitForSeconds(0.5f);
    	Countdown_.GetComponent<Text> ().text = "3";
    	getReady.Play();
    	Countdown_.SetActive(true);
    	yield return new WaitForSeconds(1);
    	Countdown_.SetActive(false);
    	Countdown_.GetComponent<Text> ().text = "2";
    	getReady.Play();
    	Countdown_.SetActive(true);
    	yield return new WaitForSeconds(1);
    	Countdown_.SetActive(false);
    	Countdown_.GetComponent<Text> ().text = "1";
    	getReady.Play();
    	Countdown_.SetActive(true);
    	yield return new WaitForSeconds(1);
    	Countdown_.SetActive(false);
    	goAudio.Play();
    	Vector3 newpos = new Vector3(-2f,5f,9.5f);
    	Schranke.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);
    	Schranke.transform.position = newpos;
    	LapTimer.SetActive(true);
    	inGameMusic.Play();

    }
    
    void checkWR()
    {
        RestClient.Get<WorldRecord>("https://tamischesummerfetzn.firebaseio.com/.json").Then(response =>
        {
            //Debug.Log("INSIDE RESTCLIENT, response: " + response.username + " / " + response.time);
        WR = response;
        WRUserLabel.GetComponent<Text>().text = "" + WR.username;
    	    
        if(WR.sec <= 9)
        {
             WRsec.GetComponent<Text>().text = "0" + WR.sec + ".";
        }
        else
    	{
            WRsec.GetComponent<Text>().text = "" + WR.sec + ".";
    	}

    	if(WR.min <= 9)
    	{
            WRmin.GetComponent<Text>().text = "0" + WR.min + ":";
    	}
    	else
    	{
            WRmin.GetComponent<Text>().text = "" + WR.min + ":";
   	}

    	WRmilli.GetComponent<Text>().text = "" + WR.milli;
    	    
        });
    }
    
}
