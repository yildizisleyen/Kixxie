using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private Sprite[] _barSprites;
    [SerializeField]
    private Image _healthbar;
    [SerializeField]
    private GameManager _gameManager;
    private void Start()
    {
        _gameOverText.gameObject.SetActive(false);
        _scoreText.text = "Score " + 0;
        _restartText.gameObject.SetActive(false);
        _gameManager = GetComponent<GameManager>();
        
    }
    public void updateBar(int currentBar)
    {
        _healthbar.sprite = _barSprites[currentBar];
        if (currentBar == 0)
        {
            _gameManager._GameOver();
            _gameOverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
        }
    }
    public void Score(int totalScore)
    {
        _scoreText.text = "Score " +totalScore.ToString();
    }
}
