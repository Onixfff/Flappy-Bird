using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForse;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _spriteSpeed;

    private PlayerController _playerController;
    private GameManager gameManager;
    private Rigidbody2D _player;
    private SpriteRenderer _spriteRenderer;
    //private float minRotation = 20;
    //private float maxRotation = -20;
    //private float _lastY;

    private void Awake()
    {
        //_lastY = transform.position.y;
        _player = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        _playerController = new PlayerController();
        _playerController.Player.Jump.performed += ctx => OnJump();
    }

    private void OnEnable()
    {
        _playerController.Enable();
    }

    private void OnDisable()
    {
        _playerController.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstruction")
        {
            gameManager.GameOver();
        }
        else if(collision.gameObject.tag == "Bonus")
        {
            gameManager.IncreaseScore();
        }
    }

    private void OnJump()
    {
        _player.AddForce(Vector2.up * _jumpForse * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
}