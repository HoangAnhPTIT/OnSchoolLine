using System;
using System.Collections.Generic;

namespace OnSchoolLine.Data
{
    public class GradeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<ClassModel> ClassModels { get; set;}

        public List<SubjectModel> SubjectModels { get; set; }
    }
}
