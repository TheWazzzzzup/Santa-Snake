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
    [Space]

    [SerializeField] PlayerInput playerInput;

    private List<GameObject> bodyParts = new List<GameObject>();
    private List<Vector3> positionsHistory = new List<Vector3>();

    uint currentBodyLength = 0;

    GameObject body;

    float rotationDirection;

    float currentRotationAngle;
    Vector3 playerEruler;

    Vector2 touchRotation;
    float joystickAngle;

    bool isAngleOffsetBiggerThanOneEighty;

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


        currentRotationAngle = transform.rotation.eulerAngles.y;



        ForwordMovement();
        JoystickAngleToEurler();
        DetermineRotationDirection();
        RotationMovement();
        BodyMovement();
    }

    private void DetermineRotationDirection()
    {
        isAngleOffsetBiggerThanOneEighty = (Mathf.Abs(currentRotationAngle - joystickAngle)) > 180;

        if (joystickAngle - 0.5 > currentRotationAngle)
        {
            if (!isAngleOffsetBiggerThanOneEighty) rotationDirection = 1;
            else rotationDirection = -1;
        }
        else if (joystickAngle + 0.5 < currentRotationAngle)
        {
            if (!isAngleOffsetBiggerThanOneEighty) rotationDirection = -1;
            else rotationDirection = 1;
        }
        else
        {
            Debug.Log("onpath");
            rotationDirection = 0;
        }
    }

    private void JoystickAngleToEurler()
    {
        touchRotation = playerInput.actions["Steer"].ReadValue<Vector2>();
        joystickAngle = Vector2.SignedAngle(Vector2.down, touchRotation);
        
        if (joystickAngle < 0)
        {
            joystickAngle = joystickAngle * -1;
        }
        else
        {
            joystickAngle = (180 - joystickAngle) + 180;
        }
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