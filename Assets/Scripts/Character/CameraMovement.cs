using UnityEngine;

namespace Character
{
    public class CameraMovement : MonoBehaviour
    {
        //This Script goes on the body of the player
        [SerializeField] private Vector2 sensibility;
        [SerializeField] private new Transform camera;
        private void Start()
        {
            camera = transform.Find("CameraPlayer");
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (Cursor.lockState == CursorLockMode.None) return;
            
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");
            
            transform.Rotate(Vector3.up * (horizontal * sensibility.x));

            if (vertical != 0)
            {
                float angle = (camera.localEulerAngles.x - vertical * sensibility.y + 360) % 360;
                if (angle > 180){angle -= 360;}
            
                angle = Mathf.Clamp(angle, -80f, 80f);
                camera.localEulerAngles = Vector3.right * angle;
            }
        }
    }
}
