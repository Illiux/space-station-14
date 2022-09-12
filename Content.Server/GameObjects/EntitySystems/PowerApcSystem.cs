using System.Collections.Generic;
using Content.Server.GameObjects.Components.NodeContainer.NodeGroups;
using Content.Server.GameObjects.Components.Power.ApcNetComponents;
using JetBrains.Annotations;
using Robust.Server.Interfaces.Timing;
using Robust.Shared.GameObjects.Systems;
using Robust.Shared.IoC;

namespace Content.Server.GameObjects.EntitySystems
{
    [UsedImplicitly]
    internal sealed class PowerApcSystem : EntitySystem
    {
        public override void Update(float frameTime)
        {
            foreach (var apc in ComponentManager.EntityQuery<ApcComponent>(false))
            {
                apc.Net.Update(frameTime);
                apc.Update();
            }
        }
    }
}
