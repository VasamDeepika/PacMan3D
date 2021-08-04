using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;
    public CharacterController characterController;
    Vector3 moveInput;

    // Update is called once per frame
    void Update()
    {
            moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            characterController.Move(moveInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            ScoreManager.instance.IncrementScore();
            other.gameObject.SetActive(false);
        }
    }
}
