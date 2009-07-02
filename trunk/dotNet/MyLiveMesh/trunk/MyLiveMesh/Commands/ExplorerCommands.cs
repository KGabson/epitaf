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
            AddFolderCommand = new Command("AddFolderCommand");
            ShareFolderCommand = new Command("ShareFolderCommand");
            SubmitSharingCommand = new Command("SubmitSharingCommand");
        }

        public static Command AddFolderCommand {get; set;}
        public static Command ShareFolderCommand { get; set; }
        public static Command SubmitSharingCommand { get; set; }
    }
}
