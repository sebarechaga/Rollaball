using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public float speed = 0; 
    public TextMeshProUGUI countText;
    public TextMeshProUGUI moveText;

    private Rigidbody rb;
    private int count;
    private int moveFrames;

    private float movementX;
    private float movementY;
    public GameObject winTextObject;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
        count = 0;
        SetCountText();
        SetMoveText();
        winTextObject.SetActive(false);
    }
    private void FixedUpdate() 
   {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 

        if (movement.magnitude > 0f) { //Counts number of frames when movement key is pressed down
            moveFrames++;
            SetMoveText();
        }
   }
   void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
   }
    void OnMove (InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }
    void SetCountText() 
   {
    countText.text =  "Count: " + count.ToString();
    if (count >= 8)
       {
           winTextObject.SetActive(true);
       }
   }
   void SetMoveText() {
        moveText.text = "Move Frames: " + moveFrames.ToString();
   }
    
}
