using System;
using System.Collections.Generic;

namespace OnSchoolLine.Data
{
    public class SubjectModel
    {
        public Guid Id { get; set; }    

        public string Name { get; set; }

        public Guid GradeId { get; set; }

        public GradeModel GradeModel { get; set; }

        public List<RegisterModel> RegisterModels { get; set; }
    }
}
