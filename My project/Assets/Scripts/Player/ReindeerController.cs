using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReindeerController : MonoBehaviour
{
    [Header("Variables")] 
    [SerializeField] float sledSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] int bodyPartsGap;
    [Space]

    [Header("GameObjects")]
    [SerializeField] GameObject fisrtBodyPart;
    [SerializeField] GameObject secondBodyPart;
    [SerializeField] GameObject thirdBodyPart;
    [SerializeField] GameObject santaBodyPart;
    [SerializeField] GameObject bodyPart;

    [SerializeField] PlayerInput playerInput;

    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionsHistory = new List<Vector3>();

    uint currentBodyLength = 0;

    GameObject body;

    float rotationDirection;

    Vector3 playerEruler;

    Vector2 touchRotation;

    bool isPlayerInControll = false;

    int index = 0;

    // Create new here
    Vector3 point;
    Vector3 moveDirection;

    private void Start()
    {
        AddBodyPart();
        AddBodyPart();
        AddBodyPart();
        AddBodyPart();
    }

    public void ToggelIsPlayerInControl()
    {
        if (isPlayerInControll)
        {
            isPlayerInControll = false;
        }
        else
        {
            isPlayerInControll = true;
        }
    }


    void Update()
    {
        if (!isPlayerInControll) return;

        // Expirement Zone
        playerEruler = transform.rotation.eulerAngles;

        rotationDirection = playerInput.actions["Steer"].ReadValue<Vector2>().x;
        touchRotation = playerInput.actions["Steer"].ReadValue<Vector2>();
        //Debug.Log(playerInput.actions["Steer"].ReadValue<Vector2>());
        Debug.Log(Vector2.SignedAngle(Vector2.down, touchRotation));
        //


        ForwordMovement();
        RotationMovement();
        BodyMovement();
    }

    private void RotationMovement()
    {
        transform.Rotate(Vector3.up * rotationDirection * rotationSpeed * Time.deltaTime);
    }

    private void BodyMovement()
    {
        positionsHistory.Insert(0, transform.position);
        index = 0;
        foreach (var body in bodyParts)
        {
            point = positionsHistory[Mathf.Clamp(index * bodyPartsGap, 0, positionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * (sledSpeed * 2) * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }

    public void AddBodyPart()
    {
        Debug.Log(currentBodyLength);
        switch (currentBodyLength)
        {
            case 0:
                body = Instantiate(fisrtBodyPart);
                bodyParts.Add(body);

                break;
            case 1:
                body = Instantiate(secondBodyPart);
                bodyParts.Add(body);

                break;
            case 2:
                body = Instantiate(thirdBodyPart);
                bodyParts.Add(body);

                break;
            case 3:
                body = Instantiate(santaBodyPart);
                bodyParts.Add(body);

                break;
            default:
                body = Instantiate(bodyPart);
                bodyParts.Add(body);

                break;
        }
        currentBodyLength++;
    }

    private void ForwordMovement()
    {
        transform.position += transform.forward * sledSpeed * Time.deltaTime;
    }
}


#region * * * Delete Me - Old Script * * *

//    private void RotationMovement()
//{
//    rotationDirection = Input.GetAxis("Horizontal");
//    transform.Rotate(Vector3.up * rotationDirection * rotationSpeed * Time.deltaTime);
//}

#endregion