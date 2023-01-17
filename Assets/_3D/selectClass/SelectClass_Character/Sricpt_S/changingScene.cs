using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changingScene : MonoBehaviour
{
    // Start is called before the first frame update
    
    //[SerializeField] private CharacterList[] characters;
    [SerializeField] private GameObject[] enviroments;
    //private int numEnv = 0;
    //[SerializeField] private Light _mlight;
    public bool atScene = false;
    public void Enviroment(CharacterList character)
    {
        int idC = character.characterId - 1;
        
        /**enviroments[idC].SetActive(true);
        if(numEnv != idC)
        {
            enviroments[idC].SetActive(false);
            numEnv = idC;
        }**/
        for (int e = 0; e < enviroments.Length; e++)
        {
            if (idC == e)
            {
                enviroments[idC].SetActive(true);
                atScene = true;
            }
            else
            {
                enviroments[e].SetActive(false);
            }
        }
    }
}
