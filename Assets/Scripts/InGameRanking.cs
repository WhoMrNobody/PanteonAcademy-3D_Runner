using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameRanking : MonoBehaviour
{
    public TMP_Text[] NamesList;
    public string A, B, C, D, E;

    private void Update()
    {
        NamesList[0].text = A;
        NamesList[1].text = B;
        NamesList[2].text = C;
        NamesList[3].text = D;
        NamesList[4].text = E;
    }
}
