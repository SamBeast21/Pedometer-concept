using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameItself : MonoBehaviour {


    private int stage;

    private float range;

    public Text myMessage;
    public Text myDistance;


// Pavillion
    private float target1Lat = 51.58952f;
    private float target1Long = -0.229889f;

     


	// Use this for initialization
	void Start () {
        stage = 0;
        range = 3.0f;
        myMessage.text = "Starting..!";
	}
	
	// Update is called once per frame
	void Update () {
        checkPosition();
        checkStage();

		
	}

    void checkStage(){

        if (stage == 0)
        {
            myMessage.text = "Go To the Pavillion!";
                
        }

        if (stage == 1)
        {
            myMessage.text = "Made it!";
            
            stage = 2;
        }


    }

    void checkPosition(){
        float currentLat =  this.GetComponent<GPSGetter>().myLat;
        float currentLong = this.GetComponent<GPSGetter>().myLong;

        float dist = Haversine(currentLat, target1Lat,currentLong,target1Long);
       
        if (range>=dist){
            stage = 1;
        }
        myDistance.text = dist.ToString();
    }

    private  float Haversine(float lat1, float lat2, float lon1, float lon2)
    {
         float r = 6371.0f; // meters
        float dlat = (lat2 - lat1) / 2;
        float dlon = (lon2 - lon1) / 2;

        float q = Mathf.Pow(Mathf.Sin(dlat), 2) + Mathf.Cos(lat1) * Mathf.Cos(lat2) * Mathf.Pow(Mathf.Sin(dlon), 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(q), Mathf.Sqrt(1 - q));

        float d = r * c;
        return d*10; //1000
    }

}
