using System;
public interface INvpEventModel
{
    void SubscribeToEvent(NvpGameEvents e, Action<object, object> callback);
    void UnsubscribeFromEvent(NvpGameEvents e, Action<object, object> observer);
    void InvokeEvent(NvpGameEvents e, object sender, object eventArgs);
    void Reset();
}