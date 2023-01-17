using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointA : MonoBehaviour
{
    [SerializeField] List<Transform> _waypoints;
    [SerializeField] GameObject _cube;
    GameObject spawnedCube;
    int count;
    bool CR_running;

    private void OnMouseDown()
    {
        if (!CR_running)
        {
            count = 0;
            StartCoroutine("TeleportCube");
        }
    }

    private IEnumerator TeleportCube()
    {
        CR_running = true;
        if (count == 0)
        {
            spawnedCube = Instantiate(_cube, _waypoints[count].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            count++;
            //Debug.Log("first coroutine " +count);
            StartCoroutine("TeleportCube");
        }
        else if (count < _waypoints.Count)
        {
            spawnedCube.transform.position = _waypoints[count].position;
            count++;
            //Debug.Log("subsequent coroutines" + count);
            yield return new WaitForSeconds(2f);
            StartCoroutine("TeleportCube");
        }
        else
        {
            spawnedCube.SetActive(false);
            StopCoroutine("TeleportCube");
            CR_running = false;
        }

    }

}
