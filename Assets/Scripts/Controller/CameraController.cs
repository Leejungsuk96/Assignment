using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target; // ī�޶� ���� ��� = Player
    [SerializeField] private float CameraSpeed = 5f; // ī�޶� ���� �ӵ�
    private Vector3 targetPosition; // ����� ���� ��ġ


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target.gameObject != null)
        {
            // this�� ī�޶� �ǹ� (z���� ī�޶��� �״�� ����)
            targetPosition.Set(target.transform.position.x, target.transform.position.y, -10);

            // vectorA -> B���� T�� �ӵ��� �̵�
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, CameraSpeed);
        }
    }
}
