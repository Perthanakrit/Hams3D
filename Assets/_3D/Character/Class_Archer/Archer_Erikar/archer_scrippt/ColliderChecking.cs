using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderChecking : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject myCollider;
    public bool IsActive;
    private Animator anim;
    private AnimationClip[] clips;
    private float clipLenght;
    void Start()
    {
        anim = GetComponent<Animator>();
        clips = anim.runtimeAnimatorController.animationClips;

        myCollider.SetActive(false);
        IsActive = false;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !IsActive)
        {
            myCollider.SetActive(true);
            IsActive = true;
        }
        else if(IsActive)
        {
            StartCoroutine(stopActive());
        }
    }
    // Update is called once per frame

    IEnumerator stopActive()
    {
        foreach(AnimationClip clip in clips)
        {
            if(clip.name == "meleeKick")
            {
                clipLenght = clip.length;
            }
        }
        yield return  new WaitForSeconds(clipLenght);
        IsActive = false;
        myCollider.SetActive(false);

    }


    public bool ActiveCollider(bool _active)
    {
        _active = !_active;
        Debug.Log(" IsActive" + IsActive);
        return _active;
    }
    
}
