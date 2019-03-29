using Search_Work.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Arrea.Candidate.Models
{
  
    public class CandidateResumesViewModel
    {
      public Guid UserId { get; set; }
      public string UserName { get; set; }
      public List<PageResumeCandidateViewModel> Resumes { get; set; }
      public CataloguePaginationViewModel Pagination { get; set; }

      public Guid CandidatId { get; set; }
      public int CurentPage { get; set; }

    }

    public class PageResumeCandidateViewModel
    {
      public Guid Id { get; set; }
      public string NameResum { get; set; }
      public int Wage { get; set; }
      public string City { get; set; }

      public string Comment { get; set; }
      public DateTime DatePublication { get; set; }
      public DateTime DateChange { get; set; }
      public int CountShow { get; set; }
      public int CountView { get; set; }

    public bool Status { get; set; }

    public bool IsAnonimus { get; set; }
    //public bool IsAnonimus { get; set; }

  }
  }
