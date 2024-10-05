using Unity.Entities;
using UnityEngine;

// The Baker class converts the GameObject's data to ECS-compatible data.
public class RotateSpeedAuthoring : MonoBehaviour
{
    public float speed; // Speed for rotation


    // Baker that converts the GameObject's RotateSpeedAuthoring to the ECS component RotateSpeed
    private class RotateSpeedBaker : Baker<RotateSpeedAuthoring>
    {
        public override void Bake(RotateSpeedAuthoring authoring)
        {
            // This method retrieves the Entity associated with the GameObject that is being baked. The TransformUsageFlags.Dynamic
            // flag ensures that the entity has a dynamic transform that can be moved or changed during runtime (ideal for objects
            // that are not static in the world).
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            // Adds the RotateSpeed component to the entity
            AddComponent(entity, new RotateSpeed
            {
                speed = authoring.speed // Assign the value from the MonoBehaviour
            });
        }
    }
}
