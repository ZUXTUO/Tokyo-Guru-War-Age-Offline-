using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace DJZJ
{
    public class mainmenu : MonoBehaviour
    {
        public static void startLOGO()
        {
            SceneManager.LoadScene("awake");
        }
        public static void start()
        {
            SceneManager.LoadScene("start");
        }
        public static void menuloding()
        {
            SceneManager.LoadScene("loadingmenu");
        }
        public static void menu()
        {
            SceneManager.LoadScene("menu");
        }
        public static void game_one_loding()
        {
            SceneManager.LoadScene("loadinggame_one");
        }
        public static void game_two_loding()
        {
            SceneManager.LoadScene("loadinggame_two");
        }
        public static void game_one()
        {
            SceneManager.LoadScene("game_one");
        }
        public static void game_two()
        {
            SceneManager.LoadScene("game_two");
        }
        public static void Quit()
        {
            Application.Quit();
        }
    }
}