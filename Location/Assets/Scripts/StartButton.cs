using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        Input.location.Stop();

        SceneManager.LoadScene(sceneName);
    }
}


 