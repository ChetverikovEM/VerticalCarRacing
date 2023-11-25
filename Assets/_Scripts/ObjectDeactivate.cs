using UnityEngine;

public class ObjectDeactivate : MonoBehaviour
{
    private Camera mainCamera;
    private bool isVisible = false;
    
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private bool OnScreen()
    {
            Vector3 screenPoint =
                mainCamera.WorldToViewportPoint(transform.position); // Вычисляем позицию объекта в координатах камеры 
            return screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 &&
                   screenPoint.y < 1; // Проверяем находится ли объект в поле видимости камеры

    }

    void FixedUpdate()
    {
        if (isVisible)
        {
            bool onScreen = OnScreen(); // Проверяем попадает ли объект в поле видимости камеры

            // Если объект вышел за пределы видимости - деактивируем его
            if (!onScreen)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (OnScreen()) isVisible = true;
        }
    }

}
