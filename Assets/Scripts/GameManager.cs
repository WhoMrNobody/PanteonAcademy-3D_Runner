using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    InGameRanking _inGameRanking;

    GameObject[] _runners;
    List<RankingSystem> _sortArray = new List<RankingSystem>();

    void Awake()
    {
        Instance = this;
        _runners = GameObject.FindGameObjectsWithTag("Runner");
        _inGameRanking = FindObjectOfType<InGameRanking>();
    }
    void Start()
    {
        for (int i = 0; i < _runners.Length; i++)
        {
            _sortArray.Add(_runners[i].GetComponent<RankingSystem>());
        }
    }


    void Update()
    {
        CalculateRanking();
    }

    void CalculateRanking()
    {
        _sortArray = _sortArray.OrderBy(x => x.Distance).ToList();

        _sortArray[0].Rank = 1;
        _sortArray[1].Rank = 2;
        _sortArray[2].Rank = 3;
        _sortArray[3].Rank = 4;
        _sortArray[4].Rank = 5;

        _inGameRanking.A = _sortArray[4].name;
        _inGameRanking.B = _sortArray[3].name;
        _inGameRanking.C = _sortArray[2].name;
        _inGameRanking.D = _sortArray[1].name;
        _inGameRanking.E = _sortArray[0].name;
        
    }
}
