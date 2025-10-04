using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpHeight = 2.0f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float gravity = 9.81f;
    public float moveHorizontal = 0;
    public float moveVertical = 0;
    public int side = 2;

    public Rotate RView;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            if (RView.Value == 1 && Input.GetAxis("Horizontal") <= 0.1f && Input.GetAxis("Vertical") <= 0.1f)
            {
                side = 1;
            }
            else if (RView.Value == 2 && Input.GetAxis("Horizontal") <= 0.1f && Input.GetAxis("Vertical") <= 0.1f)
            {
                side = 2;
            }
            else if (RView.Value == 3 && Input.GetAxis("Horizontal") <= 0.1f && Input.GetAxis("Vertical") <= 0.1f)
            {
                side = 3;
            }
            else if (RView.Value == 4 && Input.GetAxis("Horizontal") <= 0.1f && Input.GetAxis("Vertical") <= 0.1f)
            {
                side = 4;
            }

            if (side == 1)
            {
                moveHorizontal = Input.GetAxis("Vertical") * (-1);
                moveVertical = Input.GetAxis("Horizontal");
            }
            else if (side == 2)
            {
                moveHorizontal = Input.GetAxis("Horizontal");
                moveVertical = Input.GetAxis("Vertical");
            }
            else if (side == 3)
            {
                moveHorizontal = Input.GetAxis("Vertical");
                moveVertical = Input.GetAxis("Horizontal") * (-1);
            }
            else if (side == 4)
            {
                moveHorizontal = Input.GetAxis("Horizontal") * (-1);
                moveVertical = Input.GetAxis("Vertical") * (-1);
            }

            moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(jumpHeight * 2.0f * gravity);
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}