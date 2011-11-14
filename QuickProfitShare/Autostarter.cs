using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Reflection;

namespace QuickProfitShare
{
    //git for us
    /// <summary>
    /// Enables or disables the autostart (with the OS) of the application.
    /// </summary>
    public static class AutoStarter
    {
        private const string RUN_LOCATION = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string VALUE_NAME = "QuickProfitShare";

        /// <summary>
        /// Set the autostart value for the assembly.
        /// </summary>
        public static void SetAutoStart()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
            key.SetValue(VALUE_NAME, Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Returns whether auto start is enabled.
        /// </summary>
        public static bool IsAutoStartEnabled
        {
            get
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_LOCATION);
                if (key == null)
                    return false;

                string value = (string)key.GetValue(VALUE_NAME);
                if (value == null)
                    return false;
                return (value == Assembly.GetExecutingAssembly().Location);
            }
        }

        /// <summary>
        /// Unsets the autostart value for the assembly.
        /// </summary>
        public static void UnSetAutoStart()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RUN_LOCATION);
                key.DeleteValue(VALUE_NAME);
            }
            catch { }
        }

        /// <summary>
        /// To read a registry key.
        /// input: KeyName (string)
        /// output: value (string) 
        /// </summary>
        public static string Read(string KeyName)
        {
            // Opening the registry key
            RegistryKey rk = Registry.CurrentUser;
            // Open a subKey as read-only
            RegistryKey sk1 = rk.OpenSubKey(RUN_LOCATION);
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 == null)
            {
                return null;
            }
            else
            {
                try
                {
                    // If the RegistryKey exists I get its value
                    // or null is returned.
                    return (string)sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    // AAAAAAAAAAARGH, an error!
                    MessageBox.Show(e.Message, "Reading registry " + KeyName.ToUpper());
                    return null;
                }
            }
        }
    }
}
