using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowGPS : MonoBehaviour {

    public GameObject myGPSGetter;
    public Text myLatTxt; 
    public Text myLongTxt; 

 

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        myLatTxt.text = myGPSGetter.GetComponent<GPSGetter>().myLat.ToString("#.00000");
        myLongTxt.text = myGPSGetter.GetComponent<GPSGetter>().myLong.ToString("#.00000");
		
	}
}
