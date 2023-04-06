using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playButtom;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private Player _player;
    [SerializeField] private Text _scoreText;
    
    private Vector3 _startPositionPlayer;
    private int _score = 0;

    private void Awake()
    {
        _startPositionPlayer = _player.GetComponent<Transform>().position;
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        Debug.Log("Play");
        _score = 0;
        _scoreText.text = _score.ToString();

        _playButtom.SetActive(false);
        _gameOver.SetActive(false);

        Time.timeScale = 1f;
        _player.GetComponent<Transform>().position = _startPositionPlayer;
        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        _player.enabled = true;

        MoveEnemy[] moveEnemy = FindObjectsOfType<MoveEnemy>();

        for(int i = 0; i < moveEnemy.Length; i++)
        {
            Destroy(moveEnemy[i].gameObject);
        }
    }

    public void Pause()
    {
        _player.enabled = false;
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        _gameOver.SetActive(true);
        _playButtom.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
