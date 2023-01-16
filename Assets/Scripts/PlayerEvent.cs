using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Код управления анимацией был в пространстве имён Spine.Unity.Examples. 
//Я решил использовать это пространство имён для того, чтобы настроить 
//изменение анимации персонажа при "скольжении"
namespace Spine.Unity.Examples
{
    public class PlayerEvent : MonoBehaviour
    {
        //Здесь вывел переменные для настройки реалистичности "скольжения"
        [Header("Sliding force")]
        [SerializeField] float x = 5f;
        [SerializeField] float y = 5f;

        //привязываю куб и назначаю, у какого материала будет изменяться цвет
        [Header("Cube properties")]
        [SerializeField] GameObject cube;
        [SerializeField] Material cubeColorMaterial;

        //переменные для создания реалистичности "скольжения"
        [Header("Sliding Floats")]
        [SerializeField] float controlReturningTime = 1f;
        [SerializeField] float animationReturningTime = 2f;

        //"Скольжение" персонажа происходит после активации триггера на склоне. 
        private void OnTriggerEnter(Collider other)
        {
            //триггер активирует вызов метода ControlOff() для выключения управления,
            //придания импульса персонажу и для окраски куба в другой цвет
            //стартует корутина, меняющая анимацию персонажа при "скольжении"
            //вызываю метод ControlBack() для возвращения управления и окраски куба обратно в жёлтый

            Invoke("ControlOff", 0f);
            StartCoroutine(wait());
            Invoke("ControlBack", controlReturningTime);
        }

        //Метод ControlOff() для выключения управления, придания импульса персонажу и для окраски куба в красный цвет
        private void ControlOff()
        {
            //отключаю управление
            //придаю импульс персонажу для имитации "скольжения"
            //окрашиваю куб в красный цвет

            GetComponent<CharacterController>().enabled = false;
            this.gameObject.GetComponent<Rigidbody>().velocity += new Vector3(x, -y, 0);
            ColorRed();
        }

        //Метод ControlBack() для возврата управления персонажу и окраске куба в жёлтый цвет
        private void ControlBack()
        {
            //Возвращаю управление
            //Вызываю метод окрашивания куба в жёлтый цвет

            GetComponent<CharacterController>().enabled = true;
            ColorYellow();
        }

        private IEnumerator wait()
        {
            //меняю анимацию персонажа за счёт вызова PlayAnimationForState() из
            //скрипта управления списком анимаций персонажа SkeletonAnimationHandleExample
            //разделяю изменение анимации во времени, пока персонаж "скользит" по склону
            //Возвращаю анимацию idle персонажу, когда он завершает "скольжение"
            //останавливаю корутину

            this.gameObject.GetComponent<SkeletonAnimationHandleExample>().PlayAnimationForState("slide", 0);
            yield return new WaitForSeconds(animationReturningTime);
            this.gameObject.GetComponent<SkeletonAnimationHandleExample>().PlayAnimationForState("idle", 0);
            StopCoroutine(wait());
        }

        //метод изменения цвета куба на красный, использую его в методе ControlOff()
        private void ColorRed()
        {
            cubeColorMaterial.color = Color.red;
        }

        //метод изменения цвета куба на жёлтый, использую его в методе ControlBack()
        private void ColorYellow()
        {
            cubeColorMaterial.color = Color.yellow;
        }
    }
}