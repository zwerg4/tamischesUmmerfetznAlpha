using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
  public GameObject MusicSource;

  public void MuteFkt()
  {
    MusicSource.GetComponent<AudioSource>().mute = !MusicSource.GetComponent<AudioSource>().mute;
  }
}
