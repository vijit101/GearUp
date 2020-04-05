using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.GetCollectableTransform(transform);
            gameObject.SetActive(false);
            Destroy(gameObject,2);
        }
    }
}
