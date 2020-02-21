using BeatSaberMarkupLanguage.ViewControllers;
using BSplash.UI.FlowCoordinators;

namespace BSplash.UI.Controllers
{
    internal abstract class BSplashViewController : HotReloadableViewController
    {
        public BSplashFlowCoordinator flowCoordinatorOwner;
    }
}