using System.Linq;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Parser;
using BSplash.Settings;
using BSplash.UI.FlowCoordinators;
using HMUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BSplash.UI.Controllers;
using IPA.Config;
using IPA.Utilities;
using IPA.Loader;

namespace BSplash.UI.Controllers
{
    internal class OverlayCustomViewController : BSplashViewController

    {
        public override string ResourceName    => "BSplash.UI.Views.OverlayCustomView.bsml";
        public override string ContentFilePath => "C:/Users/Owens/Documents/GitHub/BSplash/UI/Views/OverlayCustomView.bsml";

        internal static Ref<PluginConfig> config;
        internal static IConfigProvider configProvider;
        public static string PPP = BSplash.Plugin.pp;
        public static string Name = BSplash.Plugin.name;
        readonly UserData of = Plugin.O0f;



        public static OverlayCustomViewController instance;

        #region Properties
        [UIParams] private BSMLParserParams parserParams;

        private bool                       _shouldOpenPage = true;
        private BSplashFlowCoordinator _flowCoordinatorOwner;


        [UIComponent("textheader2")]
        private TextMeshProUGUI textComponent2;

        [UIComponent("Header0")]
        private TextMeshProUGUI header0;

        [UIComponent("textheader1")] private RawImage img;
        #endregion
        protected override void DidActivate(bool firstActivation, ActivationType type)
        {
            base.DidActivate(firstActivation, type);
            
            textComponent2.text = "pp:" + of.PP;
            textComponent2.fontSize = 10.2f;
            header0.text = Name;
            header0.fontSize = 11.0f;
            var tex = BS_Utils.Gameplay.GetUserInfo.GetUserAvatar();
            img.texture = tex;
            var scale = img.transform.localScale;
            scale[1] *= -1;
            img.transform.localScale = scale;
        }
        





    }
}