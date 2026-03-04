using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody characterRB;
    Vector3 movementInput;
    public Vector3 movementVector;
    [SerializeField] float movementSpeed = 200f;
    AudioSource audioSource;
    

    
    void Start()
    {
        characterRB = GetComponent<Rigidbody>();
    }

    private void OnMovement(InputValue input)
    {
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
        audioSource.clip = SoundBank.instance.stepAudio;
        //transform.Translate(movementInput * movementSpeed * Time.deltaTime);
    }

    private void MovementStop()
    {
        movementVector = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (movementInput != null)
        {
            movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
            movementVector.y = 0;
            characterRB.velocity = movementVector * Time.deltaTime * movementSpeed;
        }
        else MovementStop();
        audioSource.Play();
        
    }
}
