using SLExtensions.Input;

namespace MyLiveMesh.Commands
{
    public static class DesktopCommands
    {
        static DesktopCommands()
        {
            FileCommand = new Command("FileCommand");
            FileUploaderCommand = new Command("FileUploaderCommand");
        }

        public static Command FileCommand { get; private set; }
        public static Command FileUploaderCommand { get; private set; }

    }
}
