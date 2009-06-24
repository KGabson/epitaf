using SLExtensions.Input;

namespace MyLiveMesh.Commands
{
    public static class LoginCommands
    {
        public static Command AuthCommand { get; private set; }
        public static Command CreateAccountCommand { get; private set; }
        public static Command SubmitCreateAccountCommand { get; private set; }

        static LoginCommands()
        {
            AuthCommand = new Command("AuthCommand");
            CreateAccountCommand = new Command("CreateAccountCommand");
            SubmitCreateAccountCommand = new Command("SubmitCreateAccountCommand");
        }
    }
}
