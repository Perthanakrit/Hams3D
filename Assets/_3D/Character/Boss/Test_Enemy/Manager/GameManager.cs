using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> waypoints;
    private SstateController[] _controllers;

    private void Awake()
    {
        _controllers = FindObjectsOfType<SstateController>();
        foreach (var controller in _controllers)
        {
            controller.InitializeAI(true, waypoints);
        }
    }
}
