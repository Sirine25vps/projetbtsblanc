using System;
using System.Windows.Forms;
using projetbtsblanc.Views; 

namespace projetbtsblanc
{
    internal static class Program
    {
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // lance le formulaire de connexion
            Application.Run(new LoginForm());
        }
    }
}