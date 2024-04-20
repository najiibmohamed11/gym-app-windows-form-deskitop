namespace gym_navigator
{
    public class UserUpdatedEventArgs
    {
        private string text;
        private object p;

        public UserUpdatedEventArgs(string text, object p)
        {
            this.text = text;
            this.p = p;
        }

        public int UpdatedUserImage { get; internal set; }
    }
}