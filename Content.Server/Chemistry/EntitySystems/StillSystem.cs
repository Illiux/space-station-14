using Content.Server.Chemistry.Components;
using Content.Shared.Chemistry;
using Robust.Shared.Containers;

namespace Content.Server.Chemistry.EntitySystems;

internal sealed class StillSystem : EntitySystem
{
    [Dependency] private readonly SharedAppearanceSystem _appearance = default!;

    private const string OutputSlotName = "outputSlot";
    private const string InputSlotName = "inputSlot";

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<StillComponent, EntInsertedIntoContainerMessage>(OnInserted);
        SubscribeLocalEvent<StillComponent, EntRemovedFromContainerMessage>(OnRemoved);
    }

    private void OnInserted(EntityUid uid, StillComponent component, EntInsertedIntoContainerMessage args)
    {
        var key = GetKey(args.Container.ID);
        if (key is null)
            return;

        _appearance.SetData(uid, key, true);
    }

    private void OnRemoved(EntityUid uid, StillComponent component, EntRemovedFromContainerMessage args)
    {
        var key = GetKey(args.Container.ID);
        if (key is null)
            return;

        _appearance.SetData(uid, key, false);
    }

    private static StillVisuals? GetKey(string containerId)
    {
        return containerId switch
        {
            InputSlotName => StillVisuals.Input,
            OutputSlotName => StillVisuals.Output,
            _ => null
        };
    }
}
