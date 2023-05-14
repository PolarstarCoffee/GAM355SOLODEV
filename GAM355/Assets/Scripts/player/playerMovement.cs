using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    float movespeed = 0.25f;
    [SerializeField]
    float rotationSpeed = 500f;
    [SerializeField]
    float rayLength;
    [SerializeField]
    Transform playerbase;
    [SerializeField]
    LayerMask encounter;
    [SerializeField]
    LayerMask Collision;
    Vector3 targetPosition; //Inital targetposition we want to move to once we're done moving, which is 1f
    Vector3 startPosition; //Start position
    Vector3 targetRotation; //Rotation endpoint
    bool moving; //Checks if player is in motion
  
    public static playerMovement instance;
    private void Awake()
    {
      if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
      else if (instance != this)
        {
            Destroy(gameObject);
        }
     

    }
    private void Start()
    {
      

        
        //DontDestroyOnLoad(playerPos);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "dungeon1")
        {
            
            movePlayer();
        }
        
            //IF THE SCENE IS CURRENTLY THE FIRST DUNGEON, THE PLAYER CAN MOVE MIGHT NEED TO MAKE THIS OBJECT PERSIST BETWEEN SCENES TOO. SINCE TRANSFORMS TECHNICALLY CANT BE SAVED
        
        
    }
 

    public void movePlayer() //Player movement controller
    {
        if (moving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 1f)
            {
                transform.position = targetPosition;
                moving = false;
                CheckforEncounters();
                return;
            }
            transform.position += (targetPosition - startPosition) * movespeed * Time.deltaTime;
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Moves in respect to gameObject's current facing direction
            if (!Physics.Raycast(transform.position, transform.forward, rayLength, Collision))
            {
                targetPosition = transform.position + transform.rotation * Vector3.forward;
                startPosition = transform.position;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {

            if (!Physics.Raycast(transform.position, -transform.forward, rayLength, Collision))
            {
                targetPosition = transform.position + transform.rotation * Vector3.back;
                startPosition = transform.position;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {

            if (!Physics.Raycast(transform.position, -transform.right, rayLength, Collision))
            {
                targetPosition = transform.position + transform.rotation * Vector3.left;
                startPosition = transform.position;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            if (!Physics.Raycast(transform.position, transform.right, rayLength, Collision))
            {
                targetPosition = transform.position + transform.rotation * Vector3.right;
                startPosition = transform.position;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q)) //Rotate left
        {
            transform.rotation *= Quaternion.Euler(0f, -90, 0);//Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed);

        }
        else if (Input.GetKeyDown(KeyCode.E)) //Rotate Right
        {
            transform.rotation *= Quaternion.Euler(0f, 90, 0);

        }
    } 

    public void CheckforEncounters() //Random encounter method
    {
        int random = Random.Range(1, 101);
        if (random <= 10)
        {
            Debug.Log("Entity Encountered");
            
            ScenesManager.instance.LoadNextScene();
            
        }
    }

  
}
