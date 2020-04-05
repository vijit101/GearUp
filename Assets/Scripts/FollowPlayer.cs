using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public PlayerController player;
    private Vector3 offset;
    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position - offset;
    }
    public void DisableFollowScript()
    {
        this.enabled = false;
    }
    public void EnableFollowScript()
    {
        this.enabled = true;
    }
}
