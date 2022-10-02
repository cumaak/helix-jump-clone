using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _jumpForce;

    [SerializeField] private GameObject _cylinder1, _cylinder2;
    [SerializeField] private GameObject _restartButton;

    private float _cylinderPositionY = -24f;

    private bool isPassed = false;

    public bool IsPassed
    {
        get { return isPassed; }
        set { isPassed = value; }
    }


    [SerializeField] private TextMeshProUGUI _scoreTxt;
    private int _score = 0;

    [SerializeField] private AudioClip _bounceSound;
    [SerializeField] private AudioClip _gameOverSound;

    void Update()
    {
        _scoreTxt.text = "" + (int)_score;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "SafePiece")
        {
            _rigidbody.velocity = Vector3.up * _jumpForce;
            GetComponent<AudioSource>().PlayOneShot(_bounceSound);
        }

        if(collision.gameObject.tag == "UnsafePiece")
        {
            GetComponent<AudioSource>().PlayOneShot(_gameOverSound);
            Time.timeScale = 0f;
            _restartButton.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Cylinder1")
        {
            _cylinder2.transform.position = new Vector3(0f, _cylinderPositionY, 0f);
            _cylinderPositionY -= 24f;
        }
        if (other.name == "Cylinder2")
        {
            _cylinder1.transform.position = new Vector3(0f, _cylinderPositionY, 0f);
            _cylinderPositionY -= 24f;
        }
        if (other.name == "Ring1")
        {
            isPassed = true;
            _score++;
        }
        if (other.name == "Ring2")
        {
            isPassed = true;
            _score++;
        }
        if (other.name == "Ring3")
        {
            isPassed = true;
            _score++;
        }
        if (other.name == "Ring4")
        {
            isPassed = true;
            _score++;
        }
        if (other.name == "Ring5")
        {
            isPassed = true;
            _score++;
        }
    }
}
