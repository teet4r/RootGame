public interface ICustomUpdate
{
    /* 
     * For example:
     * OnEnable()
     * {
     *     RegisterCustomUpdate();
     * }
     * 
     * RegisterCustomUpdate() { CustomUnityMessageManager.Instance.RegisterCustomUpdate(this); }
    */
    void RegisterCustomUpdate();

    /*
     * For example:
     * OnDisable()
     * {
     *     DeregisterCustomUpdate();
     * }
     * 
     * DeregisterCustomUpdate() { CustomUnityMessageManager.Instance.DeregisterCustomUpdate(this); }
     */
    void DeregisterCustomUpdate();

    void CustomUpdate();
}