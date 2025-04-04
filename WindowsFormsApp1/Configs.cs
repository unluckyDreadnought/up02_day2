﻿using System;
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

        // Возвращает / Устанавливает адрес размещения БД
        public static string dbHost
        {
            get { return GetSetting("host"); }
            set { SetSetting("host", value); }
        }

        // Возвращает / Устанавливает пользователя БД
        public static string dbUser
        {
            get { return GetSetting("user"); }
            set { SetSetting("user", value); }
        }

        // Возвращает / Устанавливает пароль пользователя БД
        public static string dbUserPass
        {
            get { return GetSetting("usrpswd"); }
            set { SetSetting("usrpswd", value); }
        }

        // Возвращает имя базы данных
        public static string dbName
        {
            get { return "project_office"; }
        }

        public static string director
        {
            get { return GetSetting("director"); }
            set { SetSetting("director", value); }
        }

        // Функция для записи изменений настроек в файл
        public static void SaveModified()
        {
            _config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
