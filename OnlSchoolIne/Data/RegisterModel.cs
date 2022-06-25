using System;

namespace OnSchoolLine.Data
{
    public class RegisterModel
    {
        public string UserId { get; set; }

        public Guid SubjectId { get; set; }

        public DateTime RegisterDate { get; set; }

        public AppUser UserModel { get; set; }

        public SubjectModel SubjectModel { get; set; }
    }
}