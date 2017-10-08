using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScreen : MonoBehaviour
{
    private float dragSpeed = -0.15f;
    private Vector3 dragOrigin;

    public bool cameraDragging = true;

    private float outerLeft = -4.69f;
    private float outerRight = 20.46f;
    private float outerUp = 3.11f;
    private float outerDown = -9.68f;

    void LateUpdate()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        float left = Screen.width * 0.05f;
        float right = Screen.width - (Screen.width * 0.13f);

        float up = Screen.height * 0.08f;
        float down = Screen.height - (Screen.height * 0.08f);

        if (mousePosition.x < left)
        {
            cameraDragging = true;
        }
        else if (mousePosition.x > right)
        {
            cameraDragging = true;
        }

        if (mousePosition.y < down)
        {
            cameraDragging = true;
        }
        else if (mousePosition.y > up)
        {
            cameraDragging = true;
        }

        if (cameraDragging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                dragOrigin = Input.mousePosition;
                return;
            }

            if (!Input.GetMouseButton(0)) return;

            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

            if (move.x > 0f)
            {
                if (this.transform.position.x < outerRight)
                {
                    transform.Translate(move, Space.World);
                }
            }
            else
            {
                if (this.transform.position.x > outerLeft)
                {
                    transform.Translate(move, Space.World);
                }
            }

            if (move.y > 0f)
            {
                if (this.transform.position.y < outerUp)
                {
                    transform.Translate(move, Space.World);
                }
            }
            else
            {
                if (this.transform.position.y > outerDown)
                {
                    transform.Translate(move, Space.World);
                }
            }

            if (transform.position.x < outerLeft)
            {
                transform.position = new Vector3(outerLeft, transform.position.y, -10);
            }
            else if (transform.position.x > outerRight)
            {
                transform.position = new Vector3(outerRight, transform.position.y, -10);
            }
            else if (transform.position.y < outerDown)
            {
                transform.position = new Vector3(transform.position.x, outerDown, -10);
            }
            else if (transform.position.y > outerUp)
            {
                transform.position = new Vector3(transform.position.x, outerUp, -10);
            }
        }
    }
}