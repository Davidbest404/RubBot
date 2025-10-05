using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    // Частота вращения персонажа (скорость реакции)
    public float rotationSpeed = 10f;
    public Camera CameraPos;
    
    void Update()
    {
        // Получаем позицию камеры
        Vector3 cameraPosition = CameraPos.transform.position;
        
        // Определяем направление от игрока к камере
        Vector3 direction = cameraPosition - transform.position;
        
        // Устанавливаем поворот только по горизонтали (ось Y)
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        targetRotation.x = 0f;   // Обнуляем наклон вверх-вниз
        targetRotation.z = 0f;   // Обнуляем наклоны вправо-влево
        
        // Интерполируем текущее положение с целью плавного перехода
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}