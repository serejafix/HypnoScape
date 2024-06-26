using UnityEngine;

public class ParallaxEffect2D : MonoBehaviour
{
    public Transform player; // ������ �� ��������� ���������
    public float[] parallaxFactors; // ������ �������� ���������� ��� ������� ����
    public float viewZone = 10f; // ���� ���������, �� ��������� ������� ���� ������������

    private Vector3 previousPlayerPosition; // ���������� ��������� ���������
    private float layerLengthX; // ����� ���� �� ��� X
    private float layerLengthY; // ����� ���� �� ��� Y

    private void Start()
    {
        // ������������� ����������� ��������� ���������
        previousPlayerPosition = player.position;

        // ������������, ��� ��� ���� ����������� ������� � ����� ������ ������� ����
        if (transform.childCount > 0)
        {
            layerLengthX = transform.GetChild(0).GetComponent<Renderer>().bounds.size.x;
            layerLengthY = transform.GetChild(0).GetComponent<Renderer>().bounds.size.y;
        }
    }

    private void Update()
    {
        // ��������� �������� ������ � ������� ���������� �����
        Vector3 deltaMovement = player.position - previousPlayerPosition;

        // ���������� ��� �������� ������� � ��������� ���������-������
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            float parallaxFactor = parallaxFactors[i];

            // ������� ���� � ����������� �� ���������-�������
            Vector3 newPosition = child.position + new Vector3(deltaMovement.x * parallaxFactor, deltaMovement.y * parallaxFactor, 0);
            child.position = newPosition;

            // �������� � ������������ ���� �� ��� X
            if (player.position.x - child.position.x > layerLengthX)
            {
                child.position = new Vector3(child.position.x + layerLengthX * 2, child.position.y, child.position.z);
            }
            else if (child.position.x - player.position.x > layerLengthX)
            {
                child.position = new Vector3(child.position.x - layerLengthX * 2, child.position.y, child.position.z);
            }

            // �������� � ������������ ���� �� ��� Y
            if (player.position.y - child.position.y > layerLengthY)
            {
                child.position = new Vector3(child.position.x, child.position.y + layerLengthY * 2, child.position.z);
            }
            else if (child.position.y - player.position.y > layerLengthY)
            {
                child.position = new Vector3(child.position.x, child.position.y - layerLengthY * 2, child.position.z);
            }
        }

        // ��������� ���������� ��������� ������
        previousPlayerPosition = player.position;
    }
}
