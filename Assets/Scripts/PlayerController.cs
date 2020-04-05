using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    private FollowPlayer followPlayer;
    public float speed = 10,camSpeed;
    public float rotateOffset = 0 , horizontalInput , forwardInput;
    Transform moveCamToTransform =null;
    private bool isTopDown = true;

    private void Awake()
    {
        followPlayer = cam.GetComponent<FollowPlayer>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if (isTopDown)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        }      
        //transform.Translate(Vector3.right * Time.deltaTime * rotateOffset*horizontalInput);
        transform.Rotate(new Vector3(0,1,0), Time.deltaTime * rotateOffset * horizontalInput);
        if(moveCamToTransform != null)
        {
            MoveCamToPos(moveCamToTransform);
        }
        if (cam.transform.position == moveCamToTransform.position)
        {
            moveCamToTransform = null;
        }
    }
    public void GetCollectableTransform(Transform moveToTransform)
    {
        moveCamToTransform = moveToTransform;
    }
    public void MoveCamToPos(Transform toTransform)
    {
        followPlayer.DisableFollowScript();
        isTopDown = false;
        cam.transform.position = Vector3.Lerp(cam.transform.position,toTransform.position,Time.deltaTime*camSpeed);
        cam.transform.rotation = toTransform.rotation;
    }

}
