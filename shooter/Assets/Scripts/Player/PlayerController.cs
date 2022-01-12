using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private float _inputHorizontal;
    private float _inputVertical;

    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        _inputHorizontal = Input.GetAxis("Horizontal");
        _inputVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * _inputHorizontal);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * _inputVertical);
    }
}
