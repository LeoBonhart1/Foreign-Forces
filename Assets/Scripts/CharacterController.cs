using UnityEngine;
public class CharacterController : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float fastSpeed = 10f;

    private Quaternion _targetRotation;
    private bool _isFastWalking;
    public Animator _animator;
    

    private void Update()
    {
        if (GameManager.Instance.isGameOver) return;
        Movement();
    }

    private void Movement()
    {
        _isFastWalking = Input.GetKey(KeyCode.LeftShift);
        var currentSpeed = _isFastWalking ? fastSpeed : normalSpeed;
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (movement == Vector3.zero)
        {
            _animator.SetBool("Walk", false);
            return;
        }

        _animator.SetBool("Walk", true);
        _targetRotation = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, 0.15f);
        transform.Translate(Vector3.forward * (currentSpeed * Time.deltaTime));
    }
}