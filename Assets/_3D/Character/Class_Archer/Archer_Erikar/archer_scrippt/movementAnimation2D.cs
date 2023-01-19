using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementAnimation2D : MonoBehaviour
{
    // speedrotation
    [SerializeField] private Character character;
    private float horizontal; // horizontal 
    private float vertical;//vertical


    void Start()
    {
        horizontal = character.playerVelocity.x;
        vertical = character.playerVelocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(horizontal+" "+ vertical);
    }

    void SetupAnimator()
    {

    }
}
