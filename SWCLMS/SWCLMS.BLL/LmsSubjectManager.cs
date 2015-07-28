using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCLMS.Models.Interfaces;
using SWCLMS.Models.Tables;

namespace SWCLMS.BLL
{
    public class LmsSubjectManager
    {
        public LmsSubjectManager(IlmsSubjectRepository lmsSubjectRepository)
        {
            _lmsSubjectRepository = lmsSubjectRepository;
        }

        public List<Subject> SubjectGetAll()
        {
            List<Subject> subjectNames = new List<Subject>();
            subjectNames = _lmsSubjectRepository.SubjectGetAll();

            return subjectNames;
        }

        public IlmsSubjectRepository _lmsSubjectRepository { get; set; }
    }
}

