using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMethods : MonoBehaviour
{
    public YokoMove Yoko;
    public Animator animator;
    public void StartGame()
    {
        Yoko = FindObjectOfType<YokoMove>();
        //Si le bouton est appuyé, je met "isGameStarted" appartenant à la class YokoMove à "true"
        Yoko.isGameStarted = true;
        animator.SetBool("isClicked", true);
    }

    public void Play()
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Level1()
    {
        SceneManager.LoadScene("level_1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("level_2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("level_3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("level_4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("level_5");
    }
    public void Level6()
    {
        SceneManager.LoadScene("level_6");
    }
    public void Level7()
    {
        SceneManager.LoadScene("level_7");
    }
    public void Level8()
    {
        SceneManager.LoadScene("level_8");
    }
    public void Level9()
    {
        SceneManager.LoadScene("level_9");
    }
    public void Level10()
    {
        SceneManager.LoadScene("level_10");
    }
    public void Update()
    {
        bool Enter = Input.GetButtonDown("Start");
        if (Enter)
        {
            Yoko.isGameStarted = true;
            animator.SetBool("isClicked", true);
        }
    }
}
