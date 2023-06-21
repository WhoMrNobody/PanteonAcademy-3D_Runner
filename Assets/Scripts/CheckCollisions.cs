using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class CheckCollisions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] int _score;
    [SerializeField] float _speedIncreaseValue;
    [SerializeField] GameObject _speedBoosterIcon;

    Vector3 _startPos;
    PlayerController _playerController;
    InGameRanking _rankingSystem;

    void Start()
    {
        _startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _speedBoosterIcon.SetActive(false);
        _playerController = GetComponent<PlayerController>();
        _rankingSystem = FindObjectOfType<InGameRanking>();
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Coin"))
        {
            AddScore(coll);

        }else if (coll.CompareTag("FinishLine"))
        {
            PlayerFinished();

            if (_rankingSystem.NamesList[4].text == "Player")
            {
                Debug.Log("Congrats");

            }
            else
            {
                Debug.Log("Lose");
            }

        }

        if (coll.CompareTag("SpeedBoost"))
        {   
            if(coll.GetComponent<NavMeshAgent>() != null)
            {
                coll.gameObject.GetComponent<NavMeshAgent>().speed += _speedIncreaseValue;
            }
            else
            {
                _playerController.RunningSpeed += _speedIncreaseValue;
                _speedBoosterIcon.SetActive(true);

                StartCoroutine(SlowDownAfterAWhile());
            }

        }

    }

    void PlayerFinished()
    {
        _playerController.RunningSpeed = 0f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Yenildin!!!");
            transform.position = _startPos;
        }
    }
    public void AddScore(Collider coin)
    {
        _score++;
        _scoreText.text = gameObject.name + " : " + _score.ToString();
        coin.gameObject.SetActive(false);
    }

    IEnumerator SlowDownAfterAWhile()
    {
        yield return new WaitForSeconds(2.0f);
        _playerController.RunningSpeed = _playerController.RunningSpeed - 3f;
        _speedBoosterIcon.SetActive(false);
    }

}
