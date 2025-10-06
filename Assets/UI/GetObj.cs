using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObj : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject player;
    private bool isPlayerNear = false;
    private bool isPickUped = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isPickUped)
        {
            if (isPlayerNear)
            {
                targetObject.SetActive(false);
                isPlayerNear = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.G) && isPickUped)
        {
            targetObject.SetActive(true);
            Vector3 place = player.transform.position;
            place += player.transform.forward * 2;
            targetObject.transform.position = place;
            isPlayerNear = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок подошел");
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок отошел");
            isPlayerNear = false;
        }
    }
}