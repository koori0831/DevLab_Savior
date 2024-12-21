public class GameManager : MonoSingleton<GameManager>
{
    public CameraManager cameraManager;
    public void DestoryManager()
    {
        Destroy(gameObject);
    }
}
