using BOOSE;

namespace BOOSEapp
{
    internal class AppCommandFactory : CommandFactory
    {
        public override ICommand MakeCommand(string commandType)
        {
            switch (commandType.ToLower())
            {
                case "circle": return new AppCircle();
                default: return base.MakeCommand(commandType);
            }
        }
    }
}
