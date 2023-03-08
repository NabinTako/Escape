using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string[] sceneNames;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];

            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
