using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private IEnumerator ForButt1()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }
    private IEnumerator ForButt2()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }
    private IEnumerator ForButt3()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }
    private IEnumerator ForButt4()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(1);
    }

    public void TestPlay()
    {
        StartCoroutine(ForButt1());
    }

    public void TestPlay2()
    {
        StartCoroutine(ForButt2());
    }

    public void TestPlay3()
    {
        StartCoroutine(ForButt3());
    }

    public void TestPlay4()
    {
        StartCoroutine(ForButt4());
    }
}
