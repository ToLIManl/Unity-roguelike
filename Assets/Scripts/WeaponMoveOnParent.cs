using UnityEngine;

public class MoveObjectOnButtonPress : MonoBehaviour
{
    public Transform targetFolder; // Перетащите в инспекторе объект-папку, в которую хотите переместить
    public Transform player; // Перетащите в инспекторе объект игрока

    public Vector3 offset; // Смещение относительно игрока
    public float zRotation; // Угол поворота по оси Z

    private void Update()
    {
        // При нажатии на клавишу "E" телепортируем объект к игроку и перемещаем в указанную папку
        if (Input.GetKeyDown(KeyCode.E))
        {
            TeleportToPlayer();
            MoveToFolder(targetFolder);
        }
    }

    private void TeleportToPlayer()
    {
        // Запоминаем текущую позицию объекта относительно игрока
        Vector3 localOffset = Quaternion.Euler(0f, 0f, zRotation) * offset;

        // Телепортируем объект к позиции игрока с учетом сохраненного смещения
        transform.position = player.position + localOffset;
    }

    private void MoveToFolder(Transform folder)
    {
        // Устанавливаем нового родителя для объекта
        transform.SetParent(folder);

        

        // Устанавливаем угол поворота по оси Z
        transform.localRotation = Quaternion.Euler(0f, 0f, zRotation);
    }
}