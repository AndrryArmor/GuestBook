﻿namespace GuestBook
{
    public class GuestBookService
    {
        private const string SampleUserName = "UserName";
        private const string SampleComment = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt " +
            "ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip " +
            "ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla " +
            "pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        private readonly List<UserComment> _userComments = new();

        public GuestBookService()
        {
            for (int i = 0; i < 10; i++)
            {
                _userComments.Add(new UserComment()
                {
                    Id = i,
                    UserName = SampleUserName,
                    Comment = SampleComment
                });
            }
        }

        public List<UserComment> GetUserComments()
        {
            return _userComments;
        }

        public void AddUserComment(UserComment userComment)
        {
            _userComments.Add(userComment);
        }
    }
}
