using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] float _gizmosRadius = 0.33f;

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _gizmosRadius);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
