using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
 private ScoreKeeper _scoreKeeper;

 private void Awake()
 {
  _scoreKeeper = FindObjectOfType<ScoreKeeper>();
 }

 public void LoadGame()
 {
  _scoreKeeper.ResetScore();
  StartCoroutine(WaitAndLoad("Game", 2));
  //SceneManager.LoadScene("Game");
 }
 
 public void LoadMainMenu()
 { 
  StartCoroutine(WaitAndLoad("MainMenu", 2));
  //SceneManager.LoadScene("MainMenu");
 }
 
 public void LoadGameOver()
 {
  StartCoroutine(WaitAndLoad("GameOver", 2));
  //SceneManager.LoadScene("GameOver");
 }

 public void QuitGame()
 {
  Debug.Log("Quitting the Game");
  Application.Quit();
 }

 IEnumerator WaitAndLoad(string sceneName, float delay)
 {
  yield return new WaitForSeconds(delay);
  SceneManager.LoadScene(sceneName);
 }
}
