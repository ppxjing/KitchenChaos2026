using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private GameInput gameInput;

    private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        Vector3 direction = gameInput.GetMovementDirectionVector();
        
        isWalking = direction != Vector3.zero;

        transform.position += direction * moveSpeed * Time.deltaTime;

        if(direction != Vector3.zero)
        {

            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime*rotateSpeed);

        }

       
    }
    public bool IsWalking
{
    get
    {
        return isWalking;
    }
}
}
