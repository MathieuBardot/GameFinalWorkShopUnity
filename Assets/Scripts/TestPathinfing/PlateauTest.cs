using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateauTest : MonoBehaviour
{
    private Grid grid;
    public Vector3 mouseInWorld = new Vector3();

    // Start is called before the first frame update
    private void Start()
    {
        Grid grid = new Grid(10, 10, 10f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(GetMouseWorldPositon(), 55);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(grid.GetValue(GetMouseWorldPositon()));
        }
    }

    public Vector3 GetMouseWorldPositon()
    {
        Vector3 mouseInScreen = Input.mousePosition;
        mouseInScreen.z = 0;
        mouseInWorld = Camera.main.ScreenToWorldPoint(mouseInScreen);
        return mouseInWorld;
    }

    /*public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        //vec.z = 0;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }*/
}
