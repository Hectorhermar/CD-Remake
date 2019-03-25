using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Contador_Monedas : MonoBehaviour
{

    public static float scoreValue = 202f;
    private Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreValue;
    }
}
