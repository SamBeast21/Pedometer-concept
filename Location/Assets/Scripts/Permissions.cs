using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

// ************** ANDROID Specific script to ask for permissions ******************
public class Permissions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        
           
            
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (Input.location.isEnabledByUser)
        {
             SceneManager.LoadScene("Start");
        }
        else
        {

            
            // Ask for permission or proceed without the functionality enabled.
            Permission.RequestUserPermission(Permission.FineLocation);
        }
        
    
        
    }
}
