using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VehicleBehaviour;

public class SpeedOMeterManager : MonoBehaviour
{
    
    public GameObject SpeedLabel;
    public GameObject BoostLabel;
    public GameObject Car;
    
    // Update is called once per frame
    void Update()
    {
    
      SpeedLabel.GetComponent<Text>().text = "" + (uint) Car.GetComponent<WheelVehicle>().Speed + " km/h";// WheelVehicle.Speed.get;
      BoostLabel.GetComponent<Text>().text = "" + (int) Car.GetComponent<WheelVehicle>().Boost;// WheelVehicle.Speed.get;
    }
}
