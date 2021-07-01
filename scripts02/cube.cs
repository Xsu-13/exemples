using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cube : MonoBehaviour
{
    PlayerControlls playerControlls;
    Vector2 move;
    Vector2 rotate;
    void Awake()
    {
        playerControlls = new PlayerControlls();

        playerControlls.Gameplay.Grow.performed += ctx => Grow();

        playerControlls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        playerControlls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        playerControlls.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
        playerControlls.Gameplay.Rotate.canceled += ctx => rotate = Vector2.zero;
    }

    void Grow()
    {
        transform.localScale *= 1.1f;
    }

    private void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);

        Vector2 r = new Vector2(-rotate.y, -rotate.x) * 100f * Time.deltaTime;
        transform.Rotate(r, Space.World);
    }

    private void OnEnable()
    {
        playerControlls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        playerControlls.Gameplay.Disable();
    }
}
