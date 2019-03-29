using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models
{
    public class ResponseToResumeViewModel
    {
        public List<DataResponseToResumeViewModel> Vacannies { get; set; }
    }


    public class DataResponseToResumeViewModel
    {
        public Guid Id { get; set; }
        public string VacancyName { get; set; }
        public string CompanyName { get; set; }
        public DateTime DataCreate { get; set; }

        public List<ResumeRespViewModel> ResumeRespList { get; set; }
    }
    public class ResumeRespViewModel
    {
        

        public DateTime DataSend { get; set; }

        public string Status { get; set; }
    }
}

