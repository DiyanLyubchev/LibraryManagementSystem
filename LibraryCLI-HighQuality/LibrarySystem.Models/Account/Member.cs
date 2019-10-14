namespace LibrarySystem
{
    public class Member : Account, IMember
    {

        public Member(string userName) : base(userName, AccountType.Member)
        {
            this.UserName = userName;
        }
    }
}