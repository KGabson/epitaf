using SLExtensions.Input;

namespace MyLiveMesh.Commands
{
    public static class DesktopCommands
    {
        static DesktopCommands()
        {
            FileCommand = new Command("FileCommand");
        }

        public static Command FileCommand { get; private set; }
    }
}
