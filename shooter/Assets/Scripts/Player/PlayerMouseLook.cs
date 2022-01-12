using UnityEngine;

public class PlayerMouseLook : MonoBehaviour
{
    [SerializeField] private float _mouseSens = 90f;
    [SerializeField] private Transform _player;
    private float _mouseX;
    private float _mouseY;
    private float _xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        FollowPlayer();       
    }

    void FollowPlayer()
    {
        _mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSens;
        _mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSens;
        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -45, 45);
        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _player.Rotate(Vector3.up * _mouseX);
    }
  
}
