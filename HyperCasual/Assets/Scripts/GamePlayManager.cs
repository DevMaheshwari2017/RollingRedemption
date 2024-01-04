using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private List<int> levelSpeed, levelMax;


    private bool hasGameFinished;
    private float score;
    private float scoreSpeed;
    private int currentLevel;

    //Getter
    public bool GetHasGameFinished()
    {
        return hasGameFinished;
    }

    private void Awake()
    {
        GameManager.Instance.IsIntialized = true;

        hasGameFinished = false;
        score = 0;
        currentLevel = 0;
        scoreText.text = ((int)score).ToString();

        scoreSpeed = levelSpeed[currentLevel];
    }

    private void Update()
    {
        if (hasGameFinished)
            return;

        score += scoreSpeed * Time.deltaTime;
        scoreText.text = ((int)score).ToString();

        if (score > levelMax[Mathf.Clamp(currentLevel,0,levelSpeed.Count-1)])
        {
            currentLevel = Mathf.Clamp(currentLevel+1,0,levelSpeed.Count-1);
            scoreSpeed = levelSpeed[currentLevel];
        }

    }

    public void GameEnded()
    {
        hasGameFinished = true;
        GameManager.Instance.CurrentScore = (int)score;
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.GoToMainMenu();
    }
}
