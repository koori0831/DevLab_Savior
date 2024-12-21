public class GameManager : MonoSingleton<GameManager>
{
    public CameraManager CameraManager;
    public void DestoryManager()
    {
        Destroy(gameObject);
    }
}
