using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool _isGameOver = false;
    [SerializeField]
    private string _sceneName;
    private void Start()
    {
        Scene rightscene = SceneManager.GetActiveScene();
        _sceneName = rightscene.name;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _sceneName == "OpenScene" )
        {
            SoundManager.playSound("OpenScene");
            StartCoroutine(_loadScene(2.5f));
        }
        if (Input.GetMouseButtonDown(1))
        {
            Application.Quit();
        }
        if (_isGameOver == true && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(_loadScene(1f));
        }
    }
    public void _GameOver()
    {
        Debug.Log("GameManager:GameOver() called");
        _isGameOver = true;
    }
    IEnumerator _loadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
}
