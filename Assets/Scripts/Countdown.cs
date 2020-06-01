using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public GameObject Countdown_;
    public AudioSource getReady;
    public AudioSource goAudio;
    public GameObject LapTimer;
    public GameObject CarControls;
    
    
    // Start is called before the first frame update
    void Start()
    {
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
    	LapTimer.SetActive(true);
    }
    
}
