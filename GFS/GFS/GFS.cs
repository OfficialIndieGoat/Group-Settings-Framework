﻿using GFS.VoidBuilds;
using System.IO;

#region Legal stuff

/*

Copyright (c) 2017 IndieGoat

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */

#endregion

namespace GFS
{
    /// <summary>
    /// The GFS object
    /// </summary>
    public class GFS
    {
        //Debug version and Public version for
        //future plugin support
        public int DEBUGVERSION = 5;
        public int PUBLICVERSION = 1000;

        //Engine setting for major changes
        public int ENGINEVERSION = 1000;
        public int MINORENGINEVERSION = 1000;

        //Read-Setting from file
        public string ReadSetting(string SettingName) { return ClassRead.ReadSetting(SettingName, GetSettingDirectory); }
        public string ReadSetting(string SettingName, string CustomDirectory) { return ClassRead.ReadSetting(SettingName, CustomDirectory); }

        //Edit-Setting from file
        public void EditSetting(string SettingName, string SettingValue) { ClassEdit.EditSetting(SettingName, SettingValue, GetSettingDirectory); }
        public void EditSetting(string SettingName, string SettingValue, string FileDirectory) { ClassEdit.EditSetting(SettingName, SettingValue, FileDirectory); }

        //Check-Setting from file
        public bool CheckSetting(string SettingName) { return ClassCheck.CheckSetting(SettingName, GetSettingDirectory); }
        public bool CheckSetting(string SettingName, string FileDirectory) { return ClassCheck.CheckSetting(SettingName, FileDirectory); }

        #region Directory Methods

        /// <summary>
        /// The default directory for the setting file
        /// </summary>
        string GetMainDirectory
        {
            get
            {
                //The name of the application
                string name = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

                //Set a local var as the directory
                string mainDirectory = @"C:\" + "Vortex Studio" + @"\" + name + @"\";

                //Check if directory exist
                if (Directory.Exists(mainDirectory)) Directory.CreateDirectory(mainDirectory);

                //Returns the main directory
                return mainDirectory;
            }
        }

        string GetSettingDirectory
        {
            get
            {
                //The name of the application
                string name = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

                //Set a local var as the directory
                string directory = @"C:\" + "IndieGoat" + @"\" + name + @"\";

                //Set a local var as the directory to the setting file
                string settingDirectory = directory + "Settings.set";

                //Check if the directory exist
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                //Check if the setting file exist
                if (!File.Exists(settingDirectory)) File.Create(settingDirectory);

                //Return the setting directory
                return settingDirectory;
            }
        }

        #endregion

    }
}