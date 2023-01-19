using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rotation();
    }

    public void Rotation()
    {
        this.transform.Rotate(0, -90f, 0.0f);
    }
}
