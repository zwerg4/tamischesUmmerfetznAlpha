using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;


public class EndTrigger : MonoBehaviour
{
    public GameObject StartTrigg;
    public GameObject EndTrigg;
    
    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;
    
    public GameObject LapTimeBox;
    
    public GameObject WRInput;
    public GameObject WRSubmit;
    public GameObject newWRLabel;
    
    private int newWRmin;
    private int newWRsec;
    private float newWRmilli;
    
    void OnTriggerEnter()
    {
    	Debug.Log("End Trigger passed with: " + LapTimeManager.MinuteCount + ":" + LapTimeManager.SecondCount + "." + LapTimeManager.MilliCount);
    	EndTrigg.SetActive(false);
    	
    	if(LapTimeManager.MinuteCount < Countdown.WR.min)
    	{
    		//WR
	        newWRmin = LapTimeManager.MinuteCount;
	     	newWRsec = LapTimeManager.SecondCount;
	     	newWRmilli = LapTimeManager.MilliCount;
	     	Debug.Log("New WR1 vars: " + newWRmin +  ":" +  newWRsec + "." + newWRmilli);
    		newWR();
    	}
    	else if(LapTimeManager.MinuteCount == Countdown.WR.min)
    	{
    	    if(LapTimeManager.SecondCount < Countdown.WR.sec)
    	    {
    	    	// WR
	        newWRmin = LapTimeManager.MinuteCount;
	     	newWRsec = LapTimeManager.SecondCount;
	     	newWRmilli = LapTimeManager.MilliCount;
	     	Debug.Log("New WR2 vars: " + newWRmin +  ":" +  newWRsec + "." + newWRmilli);
    	    	newWR();
    	    }
    	    else if(LapTimeManager.SecondCount == Countdown.WR.sec)
    	    {
    	    	if((float)LapTimeManager.MilliCount < Countdown.WR.milli)
	    	{
	    		//WR
    		        newWRmin = LapTimeManager.MinuteCount;
		     	newWRsec = LapTimeManager.SecondCount;
		     	newWRmilli = LapTimeManager.MilliCount;
		     	Debug.Log("New WR3 vars: " + newWRmin +  ":" +  newWRsec + "." + newWRmilli);
	    		newWR();
	    	}
	    	else
	    	{
	    	  //NIX
          	  newWRLabel.GetComponent<Text>().text = LapTimeManager.MinuteCount + ":" + LapTimeManager.SecondCount + "." + (int) LapTimeManager.MilliCount + "\nToo slow, press Restart";
	    	  newWRLabel.SetActive(true);
    	      	  LapTimeManager.MinuteCount = 0;
    		  LapTimeManager.SecondCount = 0;
    		  LapTimeManager.MilliCount = 0;
	    	  return;
	    	}
	    	
    	    }
    	    else
    	    {
    	    	//NIX
          	newWRLabel.GetComponent<Text>().text = LapTimeManager.MinuteCount + ":" + LapTimeManager.SecondCount + "." + (int) LapTimeManager.MilliCount + "\nToo slow, press Restart";
	        newWRLabel.SetActive(true);
    	    	LapTimeManager.MinuteCount = 0;
    		LapTimeManager.SecondCount = 0;
    		LapTimeManager.MilliCount = 0;
    	    	return;
    	    }
    	}
    	else
    	{
    		//NIX
          	newWRLabel.GetComponent<Text>().text = LapTimeManager.MinuteCount + ":" + LapTimeManager.SecondCount + "." + (int) LapTimeManager.MilliCount + "\nToo slow, press Restart";
	    	newWRLabel.SetActive(true);
    		LapTimeManager.MinuteCount = 0;
    		LapTimeManager.SecondCount = 0;
    		LapTimeManager.MilliCount = 0;
    		return;
    	}
    	
      	StartTrigg.SetActive(true);
    	EndTrigg.SetActive(false);
    }
    
    
    void newWR()
    {
     	
     	WRInput.SetActive(true);
     	WRSubmit.SetActive(true); 
     	newWRLabel.SetActive(true); 
     	
	//Debug.Log("New WR vars: " + newWRmin +  ":" +  newWRsec + "." + newWRmilli);
    		     		
        WorldRecord newWR = new WorldRecord("user", newWRmin, newWRsec, newWRmilli);
	Countdown.WR = newWR;
     	//Debug.Log("New WR obj: " + newWR.username + "  " + newWR.min +  ":" +  newWR.sec + "." + newWR.milli);
    
    }
    
    
    public void button_pressed()
    {
    	//Debug.Log("BUTTON PRESSED");
    	
    	Countdown.WR.username = WRInput.GetComponent<Text>().text;
     	//Debug.Log("New WR obj: " + Countdown.WR.username + "  " + Countdown.WR.min +  ":" +  Countdown.WR.sec + "." + Countdown.WR.milli);
        RestClient.Put("https://tamischesummerfetzn.firebaseio.com/.json", Countdown.WR);
        
     	WRInput.SetActive(false);
     	WRSubmit.SetActive(false); 
    }
}
