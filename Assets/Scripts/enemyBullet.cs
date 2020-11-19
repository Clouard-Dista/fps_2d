using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public int damage;

    public float bulletSpeed = 2f;

    public Rigidbody rb;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 pose = PlayerController.instance.transform.position;
        pose.z -= 0.3f;
        direction = pose - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = direction * bulletSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            PlayerController.instance.takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
