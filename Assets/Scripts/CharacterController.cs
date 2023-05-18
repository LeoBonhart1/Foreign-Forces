using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float fastSpeed = 10f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private bool isFastWalking = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        float currentSpeed = isFastWalking ? fastSpeed : normalSpeed;

        
        float horizontalMovement = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        transform.Translate(horizontalMovement, 0f, 0f);

       
        float verticalMovement = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        transform.Translate(0f, 0f, verticalMovement);

        
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
        }

        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isFastWalking = true;
        }
        else
        {
            isFastWalking = false;
        }
    }
}
