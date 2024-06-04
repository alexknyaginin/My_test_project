using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject loose;

    public void ShowGame()
    {
        game.SetActive(true);
        win.SetActive(false);
        loose.SetActive(false);
    }
    public void ShowWin()
    {
        game.SetActive(false);
        win.SetActive(true);
        loose.SetActive(false);
    }
    public void ShowLoose()
    {
        game.SetActive(false);
        win.SetActive(false);
        loose.SetActive(true);
    }
    private void Start()
    {
        ShowGame();
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
