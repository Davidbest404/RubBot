using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    private CharacterController controller;
    [SerializeField] private Transform camTransform;
    [SerializeField] private Vector3 moveDirection = Vector3.zero;
    [SerializeField] private float gravity = 9.81f;
    public float moveHorizontal = 0;
    public float moveVertical = 0;
    public int mass;
    public GameObject Wheel;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (moveVertical != 0 || moveHorizontal != 0)
        {
            Wheel.transform.Rotate(Vector3.forward  * ((Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical) + speed)/4));
        }

        moveDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);

        moveDirection = camTransform.TransformDirection(moveDirection).normalized * speed;

        moveDirection.y = 0.0f;

        moveDirection.y -= Time.deltaTime * mass * gravity;
        controller.Move(moveDirection * Time.deltaTime);
    }
}