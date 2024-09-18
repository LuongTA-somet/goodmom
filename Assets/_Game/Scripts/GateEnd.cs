using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateEnd : MonoBehaviour
{
    [SerializeField] private GameObject goodStage;
    [SerializeField] private GameObject badStage;
    [SerializeField] private GameObject curStage;
    [SerializeField] private CharacterMove character;
    public Gate gate;
    private void Update()
    {
        if (character.isGood && character.gate==2 )
        {
            goodStage.SetActive(true);
           
            character.isGood = false;
            character.finalScore += 2;
        }
        if (character.isBad && character.gate==2)
        {
            badStage.SetActive(true);
           
            character.gate++;
            character.finalScore -= 3;
        }
      

    }
}
