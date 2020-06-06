using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
  public GameObject StartTrigg;
  public GameObject EndTrigg;
  
  void onTriggerEnter()
  {
  	EndTrigg.SetActive(true);
  	StartTrigg.SetActive(false);
  }
}
