using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRayCast : MonoBehaviour

{
    [SerializeField] Camera cam;

    [SerializeField] GameObject desination;

    Vector3 hoveredPostion;
    Vector3 mousePosition;
    Vector3 touchPosition;


    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hoveredPostion, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition.z = 10f;
        mousePosition = cam.ScreenToWorldPoint(mousePosition);
        Debug.DrawRay(transform.position, mousePosition - transform.position, Color.black);

        Ray ray  = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,100))
        {
            hoveredPostion = hit.point;
            desination.transform.position = hoveredPostion;
        }
    }
}
