using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void aMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void aPieza() 
    {
        SceneManager.LoadScene(1);
    }

    public void aUniversidad()
    {
        SceneManager.LoadScene(2);
    }
}
