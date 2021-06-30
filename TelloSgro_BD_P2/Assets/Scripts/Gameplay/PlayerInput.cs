using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shape))]
[RequireComponent(typeof(Weapon))]
public class PlayerInput : MonoBehaviour
{
    Shape shape;
    Weapon weapon;

    private void Awake()
    {
        shape = GetComponent<Shape>();
        weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Mathf.Abs(horizontal) > 0 || Mathf.Abs(vertical) > 0)
        {
            shape.Move(new Vector3(horizontal, 0, vertical));
        }

        Vector3 mouseDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = new Vector3(mouseDirection.x - transform.position.x, 0, mouseDirection.z - transform.position.z);
        shape.Aim(mouseDirection);

        if (Input.GetMouseButton(0))
        {
            weapon.Shoot();
        }

    }
}
