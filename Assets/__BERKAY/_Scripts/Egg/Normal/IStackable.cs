using UnityEngine;

namespace Berkay
{
    public interface IStackable
    {
        void GetStack(Vector3 targetPos);
        void Follow(Vector3 followPos, float duration);

        void CloseConstrains();
        

    }
}