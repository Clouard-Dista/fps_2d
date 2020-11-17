using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D theRB;

    public float speed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSentitivity = 1f;

    public Camera viewCamera;

    public GameObject bulletImpact;

    public int armo;

    public Animator gunAnimation;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;

        Vector3 moveVertical = transform.right * moveInput.y;

        theRB.velocity = (moveHorizontal + moveVertical) * speed;

        //Camera
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSentitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z- mouseInput.x);

        //up down, camera
        viewCamera.transform.localRotation = Quaternion.Euler(viewCamera.transform.localRotation.eulerAngles + new Vector3(0f , mouseInput.y , 0f));

        //shoot
        if (Input.GetMouseButtonDown(0))
        {
            if (armo > 0)
            {

                Ray ray = viewCamera.ViewportPointToRay(new Vector3(.5f, .5f, 0f));

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletImpact, hit.point, transform.rotation);

                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyController>().takeDamage();
                    }
                }
                else
                {
                    Debug.Log("look nothing");
                }

                armo--;
                gunAnimation.SetTrigger("shoot");
            }
        }
    }
}
