using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] int _score;
    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Coin"))
        {
            AddScore(coll);
        }

    }

    public void AddScore(Collider coin)
    {
        _score++;
        _scoreText.text = "Score : " + _score.ToString();
        coin.gameObject.SetActive(false);
    }

}
