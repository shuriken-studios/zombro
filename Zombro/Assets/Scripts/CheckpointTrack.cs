using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckpointTrack : MonoBehaviour{

    public static int currentCheckpoint = 0;
    public GameObject CheckpointCounter;

    // Use this for initialization
    void Start()
    {
       CheckpointCounter.GetComponent<Text>().text = "Checkpoint " + currentCheckpoint + "/25";
    }
}
