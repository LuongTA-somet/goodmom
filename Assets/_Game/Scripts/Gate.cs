using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Gate : MonoBehaviour
{
    public GameObject goodCarpet; 
    public GameObject badCarpet;  

    [SerializeField] private CharacterMove character;

    private void Update()
    {
        if (character.isGood&& character.gate==1)
        {
            goodCarpet.SetActive(true);
            character.isGood = false;
            character.gate++;
            character.finalScore += 3;
        }
        if (character.isBad && character.gate==1 )
        {
            badCarpet.SetActive(true);
           character.isBad = false;
            character.gate++;
            character.finalScore -= 4;
        }
        

    }
}
