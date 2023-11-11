using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public bool LockScenary = false;
    public float raycastDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // ������� ���, ������ �� ������ ������ � �����������, ���� ������� ������
        RaycastHit hit; // ���������� � ��������� ����

        if (Physics.Raycast(ray, out hit, raycastDistance)) // ���������, ���������� �� ��� � �����-���� �������� �� ���������� �� raycastDistance
        {
            // �������� ����� ������ ��� ��������� ��������� ���� � ������
            if(hit.collider.tag == "Lock")
            {
                LockScenary = true;
            }

        }
    }
}
