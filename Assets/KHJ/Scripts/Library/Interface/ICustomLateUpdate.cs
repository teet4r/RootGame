public interface ICustomLateUpdate
{
    void RegisterCustomLateUpdate();
    void DeregisterCustomLateUpdate();
    void CustomLateUpdate();
}
