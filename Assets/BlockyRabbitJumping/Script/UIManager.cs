using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text textScoreUI;
    public GameObject homeUI;
    public GameObject gamePlayUI;
    public GameObject gameoverUI;
	public GameObject loadingUI;
    public GameObject pauseUI;
	public TextureRenderConvert effectScreen;
	public Animator animUI;
    public GameObject tutorialUI;
  
    public Text currentScoreText;
    public Text bestScoreText, menuBestScore;

    private GameController gameController;

    void Awake()
    {
        gameController = GetComponent<GameController>();
    }

    public void ChangeScoreText(int score)
    {
        textScoreUI.text = score.ToString();
    }

    public void CallGameStart()
    {
        animUI.SetTrigger("gameplay");
        StartCoroutine(StartGame());

        /*if (gameController.firstPlay)
            tutorialUI.SetActive(true);*/
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.0f);
        gameController.ChangeStateGame(StateGame.GamePlay);
        homeUI.SetActive(false);
        gamePlayUI.SetActive(true);
        
    }

    public void CallGameOVer()
    {
        if (pauseUI.active)
        {
            pauseUI.SetActive(false);
        }
        gameoverUI.SetActive(true);

        currentScoreText.text = gameController.currentScore.ToString();
        bestScoreText.text = gameController.highestScore.ToString();

        gamePlayUI.SetActive(false);
    }

    public void CallGameRestart()
    {
        gamePlayUI.SetActive(true);
        if (pauseUI.active)
        {
            pauseUI.SetActive(false);
            gameController.stateGame = StateGame.GameOver;
            gameController.stateGame = StateGame.GamePlay;
            /*gameController.player.ResetSprite();*/

        }
        else
            gameoverUI.SetActive(false);

        gameController.RestartGame();
        Time.timeScale = 1.0f;

    }

    public void CallHome() {
		effectScreen.SaveTexture ();
        menuBestScore.text = gameController.highestScore.ToString();
    }

    public void CallMenu()
    {
        gameController.RestartGame();
        menuBestScore.text = gameController.highestScore.ToString();
        gameController.stateGame = StateGame.Home;
        gamePlayUI.SetActive(false);
        Time.timeScale = 1;
        homeUI.SetActive(true);
        if (pauseUI.active)
        {
            pauseUI.SetActive(false);
        }
        else
            gameoverUI.SetActive(false);
    }

    // Call pause button
    public void CallPause()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }

    // Call resume
    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    // Call tutorial
    public void CallTutorial()
    {
        gameController.firstPlay = false;

        if(!tutorialUI.active)
            tutorialUI.gameObject.SetActive(true);
        else
            tutorialUI.gameObject.SetActive(false);
    }

	// Call rate
	public void CallRate(){
		Application.OpenURL ("https://doc-hosting.flycricket.io/swamp-football-privacy-policy/86025a01-1556-4b3e-a2a3-7a1cf4d62a29/privacy");	
	}

}
