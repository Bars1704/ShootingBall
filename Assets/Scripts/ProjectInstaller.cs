using Input;
using Reflex;
using Reflex.Scripts;

public class ProjectInstaller : Installer
{
    public override void InstallBindings(Container container)
    {
        container.BindSingleton<IPlayerChargeInput, TouchPlayerChargeInput>();
    }
}