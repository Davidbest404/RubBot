using UnityEngine;

public class RotateToCamera : MonoBehaviour
{
    // ������� �������� ��������� (�������� �������)
    public float rotationSpeed = 10f;
    public Camera CameraPos;
    
    void Update()
    {
        // �������� ������� ������
        Vector3 cameraPosition = CameraPos.transform.position;
        
        // ���������� ����������� �� ������ � ������
        Vector3 direction = cameraPosition - transform.position;
        
        // ������������� ������� ������ �� ����������� (��� Y)
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        targetRotation.x = 0f;   // �������� ������ �����-����
        targetRotation.z = 0f;   // �������� ������� ������-�����
        
        // ������������� ������� ��������� � ����� �������� ��������
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}