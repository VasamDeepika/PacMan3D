using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;
    public CharacterController characterController;
    Vector3 moveInput;

    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

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
            FindObjectOfType<AudioManager>().PlayAudio("Coin");
            ScoreManager.instance.IncrementScore();
            other.gameObject.SetActive(false);
            Pool.instance.AddCoin(other.gameObject);
            Pool.instance.CoinSpawning();
        }
    }
}
