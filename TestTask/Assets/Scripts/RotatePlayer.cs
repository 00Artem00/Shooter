using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] private float offset;
    private void Update()
    {
        LookAtMouse();
    }

    private void LookAtMouse()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position); // Нахождение катетов для расчёта тангенса, а в последствии и количества градусов угла. 
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Нахождение тангенса угла и перевод его в градусы.
        transform.rotation = Quaternion.Euler(0f, -angle + offset, 0f); // Вращение объекта на полученное количество градусов.
    }
}
