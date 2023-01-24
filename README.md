# SpineBoyProject - проект №1
## Поставленная задача
Сделать 2D-платформер с камерой Perspective. Уровень состоит из двух горизотнальных параллельных плоскостей,
соединённых наклоном 45*. Персонаж должен двигаться по прямой линии с анимацией бега. Как только он подходит к 
наклону, анимация должна измениться на любую другую, контроль должен пропасть. Когда персонаж
проскользит по склону, анимация возвращается и возвращается контроль. Позади персонажа должен быть куб или шар, который
будет двигаться за персонажем. В момент скольжения этот объект должен менять цвет.

## Условия задания:
1. Использовать Spine Runtime 4.0;
2. Камера должна быть Perspective;
3. За персонажем должен следовать объект;
4. Когда персонаж достигает склона - изменяется анимация персонажа и цвет следующего за персонажем объекта, пропадает управление;

## Как я выполнял задачу:
1.	Создал проект в unity, импортировал runtime Spine 4.0 и модель персонажа Spine Boy
2.	Добавил на сцену:
    *	Персонаж
    *	3D-Куб
    * Стены и пол (sprites и box collider)
3.	Посмотрел в spine sample scenes каким образом у персонажа назначить контроль и анимацию
4.	Добавил скрипты контроля и анимации на своего персонажа Spine Boy
5.	Создал box collider и назначил ему свойство trigger
6.	Написал код PlayerEvent.cs для Game Object “Player”, содержащего в своей иерархии модель Spine Boy и куб.
7.	Протестировал, что код работает и записал видео.

## Какие материалы использовал при выполнении задания:
1. [Как назначать материалу цвет](https://forum.unity.com/threads/changing-a-material-at-runtime-on-a-meshrenderer.540890/#:~:text=Unity%20Technologies&text=You%20can't%20change%20directly,whole%20array%20to%20the%20MeshRenderer) 
2. [Как задать направление движения Game Object’у для «скольжения»](https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html)
3. [Метод Invoke](https://docs.unity3d.com/ScriptReference/MonoBehaviour.Invoke.html)
4. [Использовал Coroutine для изменения анимации персонажа и для отсрочки invoke](https://docs.unity3d.com/Manual/Coroutines.html)

## Управление персонажем:
1. Вперёд - "D"
2. Назад - "A"
3. Прыжок - "Space"

## Получившийся результат:
### Скриншоты
<a href="https://ibb.co/SV7DfN0"><img src="https://i.ibb.co/SV7DfN0/1.png" alt="1" border="0"></a> <a href="https://ibb.co/cJRRQvy"><img src="https://i.ibb.co/cJRRQvy/2.png" alt="2" border="0"></a> <a href="https://ibb.co/1qphNJk"><img src="https://i.ibb.co/1qphNJk/3.png" alt="3" border="0"></a>
### Видео
https://user-images.githubusercontent.com/120922587/214321555-f40d5df0-f071-43b1-82bc-daa4b9573ba2.mp4

