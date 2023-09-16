using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private PlayerManager playerManager;
    [SerializeField] GameObject Enemy;
    [SerializeField] Vector3 mainCameraPosFocus;
    [SerializeField] GameObject Player;
    
    void Start()
    {
        playerManager = Player.GetComponent<PlayerManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (playerManager.isFocus == true)
        {
            transform.position = Player.transform.position + mainCameraPosFocus;
        }
        else if(playerManager.isFocus == false)
        {
            transform.position = Player.transform.position;
        }

        //Debug.Log(Player.transform.position);

    }
}
