using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SLExtensions.Input;

namespace MyLiveMesh.Commands
{
    public static class ExplorerCommands
    {
        static ExplorerCommands()
        {
            AddFolderCommand = new Command("addFolderCommand");
        }

        public static Command AddFolderCommand {get; set;}
    }
}
