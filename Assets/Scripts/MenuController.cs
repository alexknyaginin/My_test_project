using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject loose;
    [SerializeField] AudioSource LoseSong;
    [SerializeField] AudioSource StopMusic;
    [SerializeField] AudioSource WinSong;

    public void TestPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowGame()
    {
        game.SetActive(true);
        win.SetActive(false);
        loose.SetActive(false);
    }

    public void ShowWin()
    {
        Invoke("WinMetod", 0.4f);
    }
    public void WinMetod()
    {
        game.SetActive(false);
        StopMusic.Stop();
        win.SetActive(true);
        WinSong.Play();
        loose.SetActive(false);
    }

    public void ShowLoose()
    {
        Invoke("LooseMetod", 0.4f);
    }
    public void LooseMetod()
    {
        game.SetActive(false);
        win.SetActive(false);
        StopMusic.Stop();
        loose.SetActive(true);
        LoseSong.Play();
    }

    private void Start()
    {
        ShowGame();
    }
    
    public void Restart()
    {
        Invoke("LoadMenu", 0.4f);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
