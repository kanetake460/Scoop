using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private PlayerManager playerManager;
    private Rigidbody rb;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        playerManager = Player.GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody>();
    }

    public void MovePlayer()
    {
        Vector3 moveDirection = new Vector3(0, 0, 0);
        moveDirection.x = Input.GetAxis("Horizontal");
        moveDirection.z = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed, moveDirection.z * moveSpeed);
    }

    public void MovePerspective()
    {
        Vector2 perspectiveDirection;
        perspectiveDirection.x = Input.GetAxis("Mouse X");
        perspectiveDirection.y = Input.GetAxis("Mouse Y");

        MainCamera.transform.RotateAround(MainCamera.transform.position, MainCamera.transform.up, perspectiveDirection.x);

        if (MainCamera.transform.rotation.x <= 0.5f && MainCamera.transform.rotation.x >= -0.5f)
        {
            MainCamera.transform.RotateAround(MainCamera.transform.position, Vector3.right, -perspectiveDirection.y);
        }
        //Debug.Log(MainCamera.transform.rotation);
    }

    public void PlayerAction()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (playerManager.isFocus == false)
            {
                playerManager.isFocus = true;
                Debug.Log("フォーカスします");
            }
            else if (playerManager.isFocus == true)
            {
                playerManager.isFocus = false;
                Debug.Log("フォーカス終了");
            }
        }
        if (playerManager.isFocus == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                playerManager.shutter = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerManager.isSuperConcentrated = true;
            }
        }
    }


    void Update()
    {
        PlayerAction();
        MovePlayer();
        MovePerspective();
    }
}
