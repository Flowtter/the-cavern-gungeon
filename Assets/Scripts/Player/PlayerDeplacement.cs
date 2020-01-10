using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeplacement : MonoBehaviour
{
    public float speed;
    private Vector3 movement;
    private Vector2 target;
    public float DashSpeed;
    public bool Dash = true;

    
    public float DashTime;
    public float Cooldown;
    private float PlayerOnDash;

    [HideInInspector]
    public float ActualTime;

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(1) && ActualTime <= 0)
        {
            ActualTime = Cooldown;
            Dash = true;
            PlayerOnDash = DashTime;
        }


        if (Dash)
        {
            if (PlayerOnDash <= 0)
            {
                Dash = false;
            }
            if (moveHorizontal != 0 && moveVertical != 0)
            {
                Vector2 movement = new Vector3(moveHorizontal, moveVertical);
                transform.Translate(movement * DashSpeed);
            }
            else if (moveHorizontal != 0)
            {
                Vector2 movement = new Vector3(moveHorizontal, 0);
                transform.Translate(movement * DashSpeed);
            }
            else if (moveVertical != 0)
            {
                Vector2 movement = new Vector3(0, moveVertical);
                transform.Translate(movement * DashSpeed);
            }
            else
            {
                Vector2 movement = new Vector3(0, 0);
            }
        }
        else
        {

            if (moveHorizontal != 0 && moveVertical != 0)
            {
                Vector2 movement = new Vector3(moveHorizontal, moveVertical);
                transform.Translate(movement * speed);
            }
            else if (moveHorizontal != 0)
            {
                Vector2 movement = new Vector3(moveHorizontal, 0);
                transform.Translate(movement * speed);
            }
            else if (moveVertical != 0)
            {
                Vector2 movement = new Vector3(0, moveVertical);
                transform.Translate(movement * speed);
            }
            else
            {
                Vector2 movement = new Vector3(0, 0);
            }
        }

        if(ActualTime > 0)
        {
            ActualTime -= Time.deltaTime;
        }
        if(PlayerOnDash > 0)
        {
            PlayerOnDash -= Time.deltaTime;
        }
    }
}
