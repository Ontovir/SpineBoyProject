using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��� ���������� ��������� ��� � ������������ ��� Spine.Unity.Examples. 
//� ����� ������������ ��� ������������ ��� ��� ����, ����� ��������� 
//��������� �������� ��������� ��� "����������"
namespace Spine.Unity.Examples
{
    public class PlayerEvent : MonoBehaviour
    {
        //����� ����� ���������� ��� ��������� �������������� "����������"
        [Header("Sliding force")]
        [SerializeField] float x = 5f;
        [SerializeField] float y = 5f;

        //���������� ��� � ��������, � ������ ��������� ����� ���������� ����
        [Header("Cube properties")]
        [SerializeField] GameObject cube;
        [SerializeField] Material cubeColorMaterial;

        //���������� ��� �������� �������������� "����������"
        [Header("Sliding Floats")]
        [SerializeField] float controlReturningTime = 1f;
        [SerializeField] float animationReturningTime = 2f;

        //"����������" ��������� ���������� ����� ��������� �������� �� ������. 
        private void OnTriggerEnter(Collider other)
        {
            //������� ���������� ����� ������ ControlOff() ��� ���������� ����������,
            //�������� �������� ��������� � ��� ������� ���� � ������ ����
            //�������� ��������, �������� �������� ��������� ��� "����������"
            //������� ����� ControlBack() ��� ����������� ���������� � ������� ���� ������� � �����

            Invoke("ControlOff", 0f);
            StartCoroutine(wait());
            Invoke("ControlBack", controlReturningTime);
        }

        //����� ControlOff() ��� ���������� ����������, �������� �������� ��������� � ��� ������� ���� � ������� ����
        private void ControlOff()
        {
            //�������� ����������
            //������ ������� ��������� ��� �������� "����������"
            //��������� ��� � ������� ����

            GetComponent<CharacterController>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().velocity += new Vector3(x, -y, 0);
            ColorRed();
        }

        //����� ControlBack() ��� �������� ���������� ��������� � ������� ���� � ����� ����
        private void ControlBack()
        {
            //��������� ����������
            //������� ����� ����������� ���� � ����� ����

            GetComponent<CharacterController>().enabled = true;
            ColorYellow();
        }

        private IEnumerator wait()
        {
            //����� �������� ��������� �� ���� ������ PlayAnimationForState() ��
            //������� ���������� ������� �������� ��������� SkeletonAnimationHandleExample
            //�������� ��������� �������� �� �������, ���� �������� "��������" �� ������
            //��������� �������� idle ���������, ����� �� ��������� "����������"
            //������������ ��������

            this.gameObject.GetComponent<SkeletonAnimationHandleExample>().PlayAnimationForState("slide", 0);
            yield return new WaitForSeconds(animationReturningTime);
            this.gameObject.GetComponent<SkeletonAnimationHandleExample>().PlayAnimationForState("idle", 0);
            StopCoroutine(wait());
        }

        //����� ��������� ����� ���� �� �������, ��������� ��� � ������ ControlOff()
        private void ColorRed()
        {
            cubeColorMaterial.color = Color.red;
        }

        //����� ��������� ����� ���� �� �����, ��������� ��� � ������ ControlBack()
        private void ColorYellow()
        {
            cubeColorMaterial.color = Color.yellow;
        }
    }
}