using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private MousePositionReader mousePositionReader;
    [SerializeField] private Paddle paddle;
    [SerializeField] private Tank tank;

    private void Update()
    {
        ManageMenuCommands();

        ManagePlayerCommands();
    }

    private void ManageMenuCommands()
    {
        if (gameController.IsPlaying && gameController.IsPaused)
        {
            if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
            {
                gameController.UnpauseGame();
            }
        }
        else if (gameController.IsPlaying && !gameController.IsPaused)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                paddle.Move(Vector2.left);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                paddle.Move(Vector2.right);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameController.PauseGame();
            }
        }
    }

    private void ManagePlayerCommands()
    {
        CheckPlayerMovement();

        UpdateMousePosition();

        CheckPlayerFire();
    }

    private void CheckPlayerMovement()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right;
        }

        if (movement != Vector2.zero)
        {
            tank.Move(Vector3.Normalize(movement));
        }
    }

    private void UpdateMousePosition()
    {
        // Get the mouse position
        Vector3 mousePosition = mousePositionReader.MousePosition;

        // Pass it to the UI: TODO

        // Pass it to the player tank
        tank.UpdateFiringDirection(mousePosition);
    }

    private void CheckPlayerFire()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            tank.Fire();
        }
    }
}
