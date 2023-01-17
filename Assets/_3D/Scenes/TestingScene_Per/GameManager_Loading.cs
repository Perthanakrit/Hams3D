using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Loading : MonoBehaviour
{
    [SerializeField] private int numClass;
    [SerializeField] private CharacterList [] characters;
    [SerializeField] private Transform point;
    [HideInInspector] public Sprite currentImage;
    void Awake()
    {
        if (numClass == 1) Instantiate(characters[0]._character, point.position, Quaternion.identity);
        else if (numClass == 2) Instantiate(characters[1]._character, point.position, Quaternion.identity);

        
    }

    public void ImageChange()
    {
        for (int i = 0; i < characters[numClass].AbilitiesSkill.images.Length; i++)
        {
            return;
        }
    }
}
