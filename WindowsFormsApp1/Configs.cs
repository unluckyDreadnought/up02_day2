using System;
using System.Configuration;
using System.Reflection;

namespace WindowsFormsApp1
{
    // Класс для доступа к настройкам приложения в App.config-файле
    public static class Configs
    {
        private static Configuration _config = ConfigurationManager.OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);

        // Функция получения значения настройки по ключу
        private static string GetSetting(string key)
        {
            ConfigurationManager.RefreshSection("appSettings");
            return _config.AppSettings.Settings[key].Value.ToString();
        }

        // Функция установки значения по ключу
        private static void SetSetting(string key, string value)
        {
            _config.AppSettings.Settings[key].Value = value;
        }

        // Возвращает / Устанавливает пароль к настройкам подключения
        public static string localPswd
        {
            get { return GetSetting("localP"); }
            set { SetSetting("localP", value); }
        }

        public static string localLogin
        {
            get { return GetSetting("localL"); }
            set { SetSetting("localL", value); }
        }

        public static int timeout
        {
            get { return Convert.ToInt32(GetSetting("timeout")); }
            set { 
                SetSetting("timeout", (value).ToString());
                SaveModified();
            }
        }

        // Функция для записи изменений настроек в файл
        public static void SaveModified()
        {
            _config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
