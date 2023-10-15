using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyButton : MonoBehaviour
{
    public string sceneName;

    private void OnMouseDown()
    {
        transform.position += Vector3.down;
    }

    private void OnMouseUp()
    {
        transform.position += Vector3.up;

        if(sceneName != "")
        {
        SceneManager.LoadScene(sceneName);
        }
    }
}
