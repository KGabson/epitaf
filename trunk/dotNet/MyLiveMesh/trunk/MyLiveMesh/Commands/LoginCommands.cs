using SLExtensions.Input;

namespace MyLiveMesh.Commands
{
    public static class LoginCommands
    {
        static LoginCommands()
        {
            AuthCommand = new Command("AuthCommand");
        }

        public static Command AuthCommand { get; private set; }
    }
}
