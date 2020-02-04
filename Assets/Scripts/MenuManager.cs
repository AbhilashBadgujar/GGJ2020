using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    GameObject Main, GameInfo, SymobolInfo, Credits;

    AudioSource click;

    private void Awake()
    {
        //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(564, 960, false);
        Screen.fullScreen = false;
#endif
    }

    private void Start()
    {
        click = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        Main.SetActive(false);
        GameInfo.SetActive(false);
        SymobolInfo.SetActive(true);
        Credits.SetActive(false);
        click.Play();
    }

    public void OnCredits()
    {
        Main.SetActive(false);
        GameInfo.SetActive(false);
        SymobolInfo.SetActive(false);
        Credits.SetActive(true);
        click.Play();
    }

    public void OnInfo()
    {
        Main.SetActive(false);
        GameInfo.SetActive(false);
        SymobolInfo.SetActive(true);
        Credits.SetActive(false);
        click.Play();
    }

    public void OnInfoBack()
    {
        Main.SetActive(true);
        GameInfo.SetActive(false);
        SymobolInfo.SetActive(false);
        Credits.SetActive(false);
        click.Play();
    }


    public void OnCreditsBack()
    {
        Main.SetActive(true);
        GameInfo.SetActive(false);
        SymobolInfo.SetActive(false);
        Credits.SetActive(false);
        click.Play();
    }

    public void OnInfoFWD()
    {
        Main.SetActive(false);
        GameInfo.SetActive(true);
        SymobolInfo.SetActive(false);
        Credits.SetActive(false);
        click.Play();
    }

    public void StartLevel()
    {
        click.Play();
        SceneManager.LoadScene(1);
        
    }

    public void Quit()
    {
        click.Play();
        Application.Quit();
    }




}
