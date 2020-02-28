using System.Linq;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.FloatingScreen;
using BS_Utils.Utilities;
using BSplash.Settings;
using BSplash.UI.Controllers;
using IPA;
using IPA.Config;
using IPA.Loader;
using IPA.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Config = IPA.Config.Config;
using IPALogger = IPA.Logging.Logger;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text;

namespace BSplash
{
    public class Plugin : IBeatSaberPlugin //config.Value.BSPanelRotation
    {
        #region Properties
        internal static Ref<PluginConfig>           config;
        internal static IConfigProvider             configProvider;
        internal static PluginLoader.PluginMetadata BSplashMetadata;
        public static Vector3 pos;
        public static Quaternion rot;
        public static string pp;
        public static string Rank;
        public static string name = BS_Utils.Gameplay.GetUserInfo.GetUserName();

        static UI.FlowCoordinators.BSplashFlowCoordinator settingsFC;



        #endregion

        #region BSIPA events
        public void Init(IPALogger logger, [Config.Prefer("json")] IConfigProvider cfgProvider)
        {
            BSplash.Logger.log = logger;
            BSEvents.menuSceneLoadedFresh += MenuLoadFresh;
            configProvider = cfgProvider;

            config = cfgProvider.MakeLink<PluginConfig>((p, v) => {
                if (v.Value == null || v.Value.RegenerateConfig)
                    p.Store(v.Value = new PluginConfig() { RegenerateConfig = false });
                config = v;
            });
            Main();
        }



        public void OnApplicationQuit() { }

        public void OnFixedUpdate() { }

        public void OnUpdate() { }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene) { }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) { }

        public void OnSceneUnloaded(Scene scene) { }
        #endregion

        #region Custom events
        private static void MenuLoadFresh()
        {



            //ExperienceSystem.instance.Invoke("TestLevel", 5f); //TODO: Remove later, FPFC testing

            var settings = FloatingScreen.CreateFloatingScreen(new Vector2(102f, 52f), true, new Vector3(20, 40, 0), Quaternion.identity);

            settings.screenMover.OnRelease += (pos, rot) =>

            settings.SetRootViewController(BeatSaberUI.CreateViewController<OverlayMenuViewController>(), true);
            settings.GetComponent<Image>().enabled = false;

            var floatingScreen = FloatingScreen.CreateFloatingScreen(new Vector2(120, 100), config.Value.handle, new Vector3(), new Quaternion(0,0,0,0));


            floatingScreen.SetRootViewController(BeatSaberUI.CreateViewController<OverlayCustomViewController>(), true);
            floatingScreen.GetComponent<Image>().enabled = false;

            
        }



        private static void OnMenuSceneActive()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://new.scoresaber.com/api/player/" + BS_Utils.Gameplay.GetUserInfo.GetUserID() + "/basic");
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json; charset=utf-8";
            string file0;
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                file0 = sr.ReadToEnd();
            }
            JsonSerializer serializer = new JsonSerializer();
            string[] fil = { Utils.Clean(file0) };
            System.IO.File.WriteAllLines(@"C:\UserData\path.json", fil);
            pp = File.ReadLines(@"C:\UserData\path.json").Skip(3).Take(1).First();
            pp = Utils.GetNumbers(pp);

        }

        private static void OnGameSceneActive()
        {
           
           
        
          
            }

        public void OnApplicationStart()
        {
           
        }
        string Main()
        {
              
            
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://new.scoresaber.com/api/player/" + BS_Utils.Gameplay.GetUserInfo.GetUserID() + "/basic");
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json; charset=utf-8";
            string file0;
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                file0 = sr.ReadToEnd();
            }
            JsonSerializer serializer = new JsonSerializer();
            string[] fil = { Utils.Clean(file0) };
            System.IO.File.WriteAllLines(@"C:\UserData\path.json", fil);
             pp = File.ReadLines(@"C:\UserData\path.json").Skip(3).Take(1).First();
            pp = Utils.GetNumbers(pp);
            //Rank = File.ReadLines(@"C:\UserData\path.json").Skip(3).Take(1).First();
            //Rank = Utils.GetNumbers(Rank);


            return null;
        }

    }
    static public class Utils
    {
        public static string Clean(this string s) // ,"countryrank
        {
            return new StringBuilder(s)
                  .Replace("{", "{\n")
                   .Replace("\",", ",\n")
                   //.Replace("\"", "")
                  .Replace("}", "\n}")
                  //.Replace(",\"countryrank\"", ",\ncountryrank")
                  .ToString()
                  .ToLower();
        }
        public static string Clean2(this string s)
        {
            return new StringBuilder(s)
                  .Replace("\"\"", "")
                  .Replace(":", "")
                  .Replace(",", "")

                  .ToString()
                  .ToLower();
        }
        public static string GetNumbers(string input)
        {

            //var oof = new string(input.Where(c => !char.IsLetter(c)).ToArray());
            return Utils.Clean2(new string(input.Where(c => !char.IsLetter(c)).ToArray()));
        }

    }
        #endregion
    }
