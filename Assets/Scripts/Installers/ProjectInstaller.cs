using Input;
using Reflex;
using Reflex.Scripts;
using UnityEngine;

public class ProjectInstaller : Installer
{
    [SerializeField] private TouchPlayerChargeInput Input;
    public override void InstallBindings(Container container)
    {
        container.BindInstanceAs<IPlayerChargeInput>(Input);
    }
}