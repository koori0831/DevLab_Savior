public class GameManager : MonoSingleton<GameManager>
{
    public CameraManager CameraManager;
    public UIManager UIManager;
    public void DestoryManager()
    {
        Destroy(gameObject);
    }
}
