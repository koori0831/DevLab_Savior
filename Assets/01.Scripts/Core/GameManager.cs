public class GameManager : MonoSingleton<GameManager>
{

    public void DestoryManager()
    {
        Destroy(gameObject);
    }
}
