using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVR;

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser;        // ������
    private RaycastHit Collided_object; // �浹�� ��ü
    private GameObject currentObject;   // ���� �ֱٿ� �浹�� ��ü�� �����ϱ� ���� ��ü
    private GameObject chackObject;

    public float raycastDistance = 20f; // ������ ������ ���� �Ÿ�
    public OVRInput.Controller m_controller;

    void Start()
    {
        // ��ũ��Ʈ�� ���Ե� ��ü�� ���� ��������� ������Ʈ�� �ְ��ִ�.
        layser = this.gameObject.AddComponent<LineRenderer>();

        // ������ �������� ���� ǥ��
        Material material = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        material.color = new Color(0, 195, 255, 0.3f);
        layser.material = material;
        // �������� �������� 2���� �ʿ� �� ���� ������ ��� ǥ�� �� �� �ִ�.
        layser.positionCount = 2;
        // ������ ���� ǥ��
        layser.startWidth = 0.01f;
        layser.endWidth = 0.01f;
    }
        
    void Update()
    {
        layser.SetPosition(0, transform.position); // ù��° ������ ��ġ
                                                   // ������Ʈ�� �־� �����ν�, �÷��̾ �̵��ϸ� �̵��� ���󰡰� �ȴ�.
                                                   //  �� �����(�浹 ������ ����)
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f);

        // �浹 ���� ��
        if (Physics.Raycast(transform.position, transform.forward, out Collided_object, raycastDistance))
        {            
            layser.SetPosition(1, Collided_object.point);
            // �浹 ��ü�� �±װ� Button�� ���
            if (Collided_object.collider.gameObject.CompareTag("Button"))
            {
                layser.material.color = new Color(0, 195, 255, 0.5f);
                // ��ŧ���� �� �����ܿ� ū ���׶�� �κ��� ���� ���
                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    // ��ư�� ��ϵ� onClick �޼ҵ带 �����Ѵ�.
                    Collided_object.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
                else
                {
                    Collided_object.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);
                    currentObject = Collided_object.collider.gameObject;
                }
            }

            // �浹 ��ü�� �±װ� weapon ���
            if (Collided_object.collider.gameObject.CompareTag("weapon"))
            {
                layser.material.color = new Color(0, 134, 0, 0.5f);

                chackObject = Collided_object.collider.gameObject;
                chackObject.GetComponent<Outline>().enabled = true;
                chackObject.GetComponent<Outline>().OutlineColor = Color.green;
                chackObject.GetComponent<Outline>().OutlineWidth = 3f;
                StartCoroutine(VibrateController(0.05f, 0.3f, 0.2f, m_controller));

                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    Collided_object.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
                else
                {
                    Collided_object.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);
                    currentObject = Collided_object.collider.gameObject;
                }
            }
            if (!Collided_object.collider.gameObject.CompareTag("weapon"))
            {
                if (chackObject != null)
                {
                    chackObject.GetComponent<Outline>().enabled = false;
                    chackObject = null;
                }
            }

        }
        else
        {
            // �������� ������ ���� ���� ������ ������ �ʱ� ���� ���̸�ŭ ��� �����.
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));            
           
            // �ֱ� ������ ������Ʈ�� Button�� ���
            // ��ư�� ���� �����ִ� �����̹Ƿ� �̰��� Ǯ���ش�.
            if (currentObject != null)
            {
                currentObject.GetComponent<Button>().OnPointerExit(null);
                currentObject = null;
                layser.material.color = new Color(255, 255, 255, 0.5f);
            }
        }
    }
    protected IEnumerator VibrateController(float waitTime, float frequenct, float amplitude, OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(frequenct, amplitude, controller);
        yield return new WaitForSeconds(waitTime);
        OVRInput.SetControllerVibration(0, 0, controller);
    }
}