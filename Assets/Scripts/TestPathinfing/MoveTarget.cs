using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public LayerMask hitLayers;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetMouseButtonDown(0)) //SI le joueur fait un click gauche
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
            {
                this.transform.position = hit.point;
            }
        }
    }
}
