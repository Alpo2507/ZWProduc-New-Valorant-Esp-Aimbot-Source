using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//369, 253

namespace BRAIMBOT
{

    public partial class Form1 : Form
    {

        #region Imports
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        #endregion

        #region strings
        string config = "C:\\Program Files (x86)\\Microsoft\\Temp\\config.ini";
        string proc_cheat = "C:\\Program Files (x86)\\Microsoft\\Temp\\overlay.exe";
        string cheat = "overlay";
        string dll_cheat = "C:\\Program Files (x86)\\Microsoft\\Temp\\win32.dll";
        string inter_cheat = "C:\\Program Files (x86)\\Microsoft\\Temp\\Interception.dll";
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void patch_news_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void setup_ld_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox2.Location = new Point(93, 26);
        }

        private void settings_ld_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox3.Location = new Point(93, 26);
        }

        /*
        #region INIFILES
        class INIFile
        {
            private string filePath;

            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section,
            string key,
            string val,
            string filePath);

            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string section,
            string key,
            string def,
            StringBuilder retVal,
            int size,
            string filePath);

            public INIFile(string filePath)
            {
                this.filePath = filePath;
            }

            public void Write(string section, string key, string value)
            {
                WritePrivateProfileString(section, key, value.ToLower(), this.filePath);
            }

            public string Read(string section, string key, string value)
            {
                StringBuilder SB = new StringBuilder(255);
                int i = GetPrivateProfileString(section, key, "", SB, 255, this.filePath);
                return SB.ToString();
            }

            public string FilePath
            {
                get { return this.filePath; }
                set { this.filePath = value; }
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
                if (File.Exists(config))
            {
                File.Delete(config);
            }
            
                        INIFile inif = new INIFile(config);
                        inif.Write("config", "sensitivity", textBox1.Text);
                        inif.Write("config", "smoothing", textBox2.Text); 
                        inif.Write("settings", "snapping area", comboBox2.Text);
                        inif.Write("settings", "toggle key", comboBox1.Text);
                       // inif.Write("settings", "hold or toggle", comboBox5.Text);
                        inif.Write("settings", "hFov", textBox4.Text);
                        inif.Write("settings", "vFov", textBox3.Text);

                        if (radioButton1.Checked)
                        {
                            inif.Write("settings", "aim color", radioButton1.Text);
                        }
                    } 

                    #region injector
                    private bool Inject(uint PID, string DLL)
                    {
                        try
                        {
                            IntPtr pHandle = OpenProcess(1082u, 1, PID);
                            IntPtr pAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                            IntPtr bAddress = VirtualAllocEx(pHandle, (IntPtr)null, (IntPtr)DLL.Length, 12288u, 64u);

                            byte[] DBytes = Encoding.ASCII.GetBytes(DLL);

                            _ = WriteProcessMemory(pHandle, bAddress, DBytes, (uint)DBytes.Length, 0) == 0;

                            _ = CreateRemoteThread(pHandle, (IntPtr)null, IntPtr.Zero, pAddress, bAddress, 0u, (IntPtr)null) == IntPtr.Zero;

                            CloseHandle(pHandle);

                            return true; //Sucess!
                        }
                        catch { return false; }
                    }
                    #endregion
        */
    }
}

namespace System.Windows.Input
{
    class MouseButtonEventArgs
    {
    }
}