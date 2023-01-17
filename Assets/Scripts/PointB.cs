using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointB : MonoBehaviour
{
    [SerializeField] List<Transform> _waypoints;
    [SerializeField] GameObject _cube;
    GameObject spawnedCube;
    int count;
    float elapsedTime;
    private void OnMouseDown()
    {
        count = 0;
        spawnedCube = Instantiate(_cube, transform.position, Quaternion.identity);
        StartCoroutine("MoveCube");
    }
    IEnumerator MoveCube()
    {
        if (count < _waypoints.Count)
        {
            elapsedTime = 0;
            while(elapsedTime<2f)
            {
            spawnedCube.transform.position = Vector3.Lerp(spawnedCube.transform.position,_waypoints[count].position, elapsedTime / 2f);
            elapsedTime += Time.deltaTime;
            yield return null;
            }
            
            count++;
            //Debug.Log("subsequent coroutines" + count);
            StartCoroutine("MoveCube");
        }
        else
        {
            yield return new WaitForSeconds(2f);
            spawnedCube.SetActive(false);
            StopCoroutine("MoveCube");
        }
    }
}
