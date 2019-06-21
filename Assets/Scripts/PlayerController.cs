using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float acceleration;
    public float maxSpeed;
    float moveHorizontal;
    float moveVertical;
    Vector3 movement;
    bool canJump;
    bool isOnPlateform;

    private Rigidbody rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }

    void FixedUpdate ()
    {
        isOnPlateform = this.gameObject.GetComponentInChildren<TriggerSurface>().IsOnPlateform;
        if (SystemInfo.supportsGyroscope)
        {
            moveHorizontal = Input.acceleration.x;
            moveVertical = Input.acceleration.y;
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if ((Input.GetTouch(i).phase == TouchPhase.Began) && canJump)
                {
                    isOnPlateform = false;
                    rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
                    canJump = false;
                    StartCoroutine(WaitForIt(1));
                }
            }
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                isOnPlateform = false;
                rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
                canJump = false;
                StartCoroutine(WaitForIt(1));
            }
        }

        movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        //gameObject.transform.position += movement * speed;
       rb.AddForce (movement * acceleration);

        if ((isOnPlateform == true) && (canJump == true))
            if (rb.velocity.magnitude > maxSpeed)
                rb.velocity = rb.velocity.normalized * maxSpeed;
    }
    public IEnumerator WaitForIt(int time)
    {
        yield return new WaitForSeconds(time);
        canJump = true;
    }
}
