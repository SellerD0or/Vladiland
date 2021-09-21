using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private bool _isOnGame;
    [SerializeField] private GameObject _settings;
    private bool _isGameRun = true;

    private void Start() {
        if(_isOnGame)
        {
            ChangeActive();
        }
    
 }
 private void ChangeActive() 
 {
    
     _isGameRun =! _isGameRun;
     int _active = 0;
     _active = _isGameRun ? 0 : 1;
       Time.timeScale = _active;
 }
  private void Update() 
  {
     if (_isOnGame && Input.GetKeyDown(KeyCode.Escape))
     {
         ChangeActive();
         _settings.SetActive(_isGameRun);
     }
  }
  public void Exit()
  {
    SceneManager.LoadScene(0);
  }
}
