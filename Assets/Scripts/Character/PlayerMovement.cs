using UnityEngine;

namespace Character
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private float speed = 2.5f; //The value that is going to be modified depending on the action
        [SerializeField] private float walkSpeed = 2.5f;//Speed at the moment of walk
        [SerializeField] private float runSpeed = 5f;//Speed at the moment of run

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Walking();
        }

        private void Walking()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 velocity;
            
            speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
            
            if (horizontal != 0 || vertical != 0)
            {
                velocity = (transform.forward * vertical + transform.right * horizontal) * speed;
            }
            else velocity = Vector3.zero;
            
            velocity.y = rb.velocity.y;
            rb.velocity = velocity;
        }
    }
}
