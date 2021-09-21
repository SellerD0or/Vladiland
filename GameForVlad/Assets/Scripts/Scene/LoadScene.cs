using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int _numberOfScene;
  private void Update() {
      if (Input.GetKeyDown(KeyCode.R))
      {
          SceneManager.LoadScene(_numberOfScene);
      }
  }
  public void Play(int _numberOfLevel)
  {
      SceneManager.LoadScene(_numberOfLevel);
  }
  public void Exit()
  {
      Application.Quit(); 
  }
  public void SetChanges()
  {
      PlayerPrefs.DeleteAll();
      PlayerPrefs.DeleteKey("Damage");
      PlayerPrefs.DeleteKey("FireRate");
      PlayerPrefs.DeleteKey("OrderOfItem");
  }
}
