using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject loose;
<<<<<<< Updated upstream
    [SerializeField] AudioSource LoseSong;
    [SerializeField] AudioSource StopMusic;
    [SerializeField] AudioSource WinSong;

    public void TestPlay()
    {
        SceneManager.LoadScene(1);
=======
    [SerializeField] private GameObject menu;

    public void ShowMenu()
    {
        menu.SetActive(true);
        game.SetActive(false);
        win.SetActive(false);
        loose.SetActive(false);
>>>>>>> Stashed changes
    }

    public void ShowGame()
    {
        menu.SetActive(false);
        game.SetActive(true);
        win.SetActive(false);
        loose.SetActive(false);
    }

    public void ShowWin()
    {
<<<<<<< Updated upstream
        Invoke("WinMetod", 0.4f);
    }
    public void WinMetod()
    {
=======
        menu.SetActive(false);
>>>>>>> Stashed changes
        game.SetActive(false);
        StopMusic.Stop();
        win.SetActive(true);
        WinSong.Play();
        loose.SetActive(false);
    }

    public void ShowLoose()
    {
<<<<<<< Updated upstream
        Invoke("LooseMetod", 0.4f);
    }
    public void LooseMetod()
    {
=======
        menu.SetActive(false);
>>>>>>> Stashed changes
        game.SetActive(false);
        win.SetActive(false);
        StopMusic.Stop();
        loose.SetActive(true);
        LoseSong.Play();
    }

    private void Start()
    {
        ShowMenu();
        //ShowGame();
    }
    
    public void Restart()
    {
        Invoke("LoadMenu", 0.4f);
    }
<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
=======
>>>>>>> Stashed changes
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
<<<<<<< Updated upstream

=======
    public void LastChance()
    {
        ShowGame();
    }
>>>>>>> Stashed changes
>>>>>>> Stashed changes
    public void Exit()
    {
        Application.Quit();
    }
}
