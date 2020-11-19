using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    // Start is called before the first frame update
    void Awake()
    {
        camManager();
    }

    // Update is called once per frame
    void Update()
    {
        camManager();
    }

    void camManager()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        if (
            Input.mousePosition.x <= 0 || 
            Input.mousePosition.y <= 0 || 
            Input.mousePosition.x >= Screen.width - 1 || 
            Input.mousePosition.y >= Screen.height - 1
            )
        {
            Input.mousePosition.Set(1f,1f,1f);
        }
    }
}
