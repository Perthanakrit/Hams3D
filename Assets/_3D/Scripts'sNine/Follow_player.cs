using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Follow_player : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    public Color dieColor;
    public Image dieImage;
    private CinemachineVirtualCamera isomatic;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = this.transform.position - player.transform.position;
        isomatic = GetComponent<CinemachineVirtualCamera>();
        isomatic.Follow = player;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            dieImage.color = dieColor;
            return;
        }
        this.transform.position = player.transform.position + offset;
    }
}
