using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mainmenu : MonoBehaviour
{
    private void Start()
    {

    }
    public void play()
    {
        SceneManager.LoadScene("level1");
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void ChoosenCharacter()
    {
        SceneManager.LoadScene("charswitch");
    }

}
