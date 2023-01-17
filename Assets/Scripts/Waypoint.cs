using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] float _gizmosRadius = 0.33f;
    int rdm;
    float duration = 2f;
    float time = 0f;
    Vector3 scaleToUse;


    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, _gizmosRadius);
    }    private void OnTriggerEnter(Collider other)
    {
        rdm = Random.Range(1, 3);
        StartCoroutine(MorphCube(rdm, other.gameObject));
    }
    IEnumerator MorphCube(int type, GameObject other)
    {
        var cubeScale = other.transform.localScale;
        var doubleCubeScale = cubeScale * 2;
        var halfCubeScale = cubeScale / 2;
        if(type == 1) scaleToUse = doubleCubeScale;
        else scaleToUse =halfCubeScale;
        
        while (time < duration)
        {
            time += Time.deltaTime;
            other.transform.localScale = Vector3.Lerp(cubeScale, scaleToUse, time / duration);
            yield return null;
        }
    }
}
