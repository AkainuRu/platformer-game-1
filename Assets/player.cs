using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJump : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Скорость движения

    private void Update()
    {
        Vector2 inputVector = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = -speed; // Движение влево
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector.x = speed; // Движение вправо
        }

        // Применяем движение к объекту
        transform.Translate(inputVector * Time.deltaTime);

        // Выводим в консоль текущее значение inputVector
        Debug.Log(inputVector);
    }
}