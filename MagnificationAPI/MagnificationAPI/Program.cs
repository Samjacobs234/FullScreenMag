using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

//We will need to utilize interopservices inorder to inport our required magnification stuff
using System.Runtime.InteropServices;


//The Program class generally handles all "paper"work. Here, we will simply import all the methods we will need form User32 and maginifcation API
namespace MagnificationAPI
{


    static class Program
    {

		
	#region Import_Maginification.dll_Functions
		[DllImport("Magnification.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MagInitialize();

       
		[DllImport("Magnification.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MagSetFullscreenColorEffect(float [] pEffect);

        [DllImport("Magnification.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MagSetFullscreenTransform(float magLevel, int xOffset, int yOffset);
        

        #endregion
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

	}
}
