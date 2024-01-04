using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text currentScoreText;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text newBestText;
    [SerializeField]
    private TMP_Text highScoreText;
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private float animTime;
    [SerializeField]
    private AnimationCurve speedCurve;

    private void Awake()
    {
        if (GameManager.Instance.IsIntialized)
        {
            StartCoroutine(ShowScore());
        }
        else
        {
            currentScoreText.gameObject.SetActive(false);
            scoreText.gameObject.SetActive(false);
            newBestText.gameObject.SetActive(false);
            highScoreText.text = GameManager.Instance.HighScore.ToString();
        }
    }

    //Have ref on button 
    public void ClickedPlayButton()
    {
        SoundManager.Instance.PlaySound(audioClip);
        GameManager.Instance.GoToGameplay();
    }

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        scoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.CurrentScore;
        int highScore = GameManager.Instance.HighScore;

        if (highScore < currentScore)
        {
            newBestText.gameObject.SetActive(true);
            currentScoreText.gameObject.SetActive(false);
            GameManager.Instance.HighScore = currentScore;
        }
        else 
        {
            newBestText.gameObject.SetActive(false);
            currentScoreText.gameObject.SetActive(true);
        }

        highScoreText.text = GameManager.Instance.HighScore.ToString();

        float speed = 1 / animTime;
        float timeElasped = 0f;

        while(timeElasped < 1f)
        {
            timeElasped += speed * Time.deltaTime;
            tempScore = (int)(speedCurve.Evaluate(timeElasped) * currentScore);
            scoreText.text = tempScore.ToString();
            yield return null;
        }

        tempScore = currentScore;
        scoreText.text = tempScore.ToString();
    }
}
