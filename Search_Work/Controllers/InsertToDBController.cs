using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Search_Work.Data;
using Search_Work.Models;
using Search_Work.Models.ArreaDatabase;
using Search_Work.Models.ArreaDatabase.Resumes;
using Search_Work.Models.ArreaDatabase.Vacancies;
using Search_Work.Models.DefaultData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search_Work.Controllers
{
  public class InsertToDBController : Controller
  {
    private readonly oxana1404 db;
    private readonly UserManager<ApplicationUser> userManager;

    // private IHostingEnvironment _environment;

    public InsertToDBController(oxana1404 _db, UserManager<ApplicationUser> userManager)
    {
      db = _db;
      this.userManager = userManager;
    }
    public ActionResult Insert()
    {

      var count = userManager.Users.Count();


      if (count <= 20)
      {

        ApplicationUser employer = //userManager.Users.FirstOrDefault(u => u.Email == "employer@dominator.ua");
           new ApplicationUser() { Email = "employer@sw.ua", UserName = "employer@sw.ua" };
        ApplicationUser employer1 = //userManager.Users.FirstOrDefault(u => u.Email == "employe1@dominator.ua");
        new ApplicationUser() { Email = "employe1@swr.ua", UserName = "employer1@sw.ua" };
        ApplicationUser employer2 = //userManager.Users.FirstOrDefault(u => u.Email == "employer2@dominator.ua");
        new ApplicationUser() { Email = "employer2@sw.ua", UserName = "employer2@sw.ua" };




        var emplRes = this.userManager.CreateAsync(employer, "Q123_q").Result;
        if (emplRes.Succeeded)
        {
          var roleEmplRes = this.userManager.AddToRoleAsync(employer, "Employer").Result.Succeeded;
        }

        var empl1Res = this.userManager.CreateAsync(employer1, "Q123_q").Result;
        if (empl1Res.Succeeded)
        {
          var roleEmpl1Res = this.userManager.AddToRoleAsync(employer1, "Employer").Result.Succeeded;
        }

        var empl2Res = this.userManager.CreateAsync(employer2, "Q123_q").Result;
        if (empl2Res.Succeeded)
        {
          var roleEmpl2Res = this.userManager.AddToRoleAsync(employer2, "Employer").Result.Succeeded;

        }

       // -------------Activity Fiald------------
        List<FieldActivity> defaultActivitiesList = new List<FieldActivity>()
        {
          new FieldActivity()
          {
            Name = "IT, компьютеры, интернет",
          },
          new FieldActivity()
          {
            Name = "Культура, музыка, шоу-бизнес",
          },
          new FieldActivity()
          {
            Name = "Финансы, банк",
          },
          new FieldActivity()
          {
            Name = "Администрация, руководство среднего звена",
          },
          new FieldActivity()
          {
            Name = "Бухгалтерия, аудит",
          },
          new FieldActivity()
          {
            Name = "Гостинично-ресторанный бизнес, туризм",
          },
          new FieldActivity()
          {
            Name = "Дизайн, творчество",
          },
          new FieldActivity()
          {
            Name = "Красота, фитнес, спорт",
          },
          new FieldActivity()
          {
            Name = "Культура, музыка, шоу-бизнес",
          },
          new FieldActivity()
          {
            Name = "Логистика, склад, ВЭД",
          },
          new FieldActivity()
          {
            Name = "Маркетинг, реклама, PR",
          },
          new FieldActivity()
          {
            Name = "Медицина, фармацевтика",
          },
          new FieldActivity()
          {
            Name = "Недвижимость",
          },
          new FieldActivity()
          {
            Name = "Образование, наука",
          },
          new FieldActivity()
          {
            Name = "Охрана, безопасность",
          },
          new FieldActivity()
          {
            Name = "Продажи, закупки",
          },
          new FieldActivity()
          {
            Name = "Рабочие специальности, производство",
          },
          new FieldActivity()
          {
            Name = "Розничная торговля",
          },
          new FieldActivity()
          {
            Name = "Секретариат, делопроизводство, АХО",
          },
          new FieldActivity()
          {
            Name = "Сельское хозяйство, агробизнес",
          },
          new FieldActivity()
          {
            Name = "СМИ, издательство, полиграфия",
          },
          new FieldActivity()
          {
            Name = "Строительство, архитектура",
          },
          new FieldActivity()
          {
            Name = "Сфера обслуживания",
          },
          new FieldActivity()
          {
            Name = "Телекоммуникации и связь",
          },
          new FieldActivity()
          {
            Name = "Топ-менеджмент, руководство высшего звена",
          },
          new FieldActivity()
          {
            Name = "Транспорт, автобизнес",
          },
          new FieldActivity()
          {
            Name = "Управление персоналом, HR",
          },
          new FieldActivity()
          {
            Name = "Финансы, банк",
          },
          new FieldActivity()
          {
            Name = "Юриспруденция",
          },
          new FieldActivity()
          {
            Name = "Другие сферы деятельности",
          },
        };

        defaultActivitiesList.ForEach(fieldActivity => fieldActivity.Id = Guid.NewGuid());


        foreach (var activity in defaultActivitiesList)
        {
          db.FieldActivities.Add(activity);
        }
        db.SaveChanges();
        defaultActivitiesList = db.FieldActivities.ToList();
        // -----------------------------------------------------------

        Employer defaultEmployer1 = new Employer();
        defaultEmployer1.Id = Guid.NewGuid();

        Employer defaultEmployer2 = new Employer();
        defaultEmployer2.Id = Guid.NewGuid();

        Employer defaultEmployer3 = new Employer();
        defaultEmployer3.Id = Guid.NewGuid();

        // --------------- Default City -------------------
        var defaultCity1 = new City()
        {
          Id = Guid.NewGuid(),
          Name = "Київ"
        };


        var defaultCity2 = new City()
        {
          Id = Guid.NewGuid(),
          Name = "Дніпро"
        };


        var defaultCity3 = new City()
        {
          Id = Guid.NewGuid(),
          Name = "Харків"
        };


        //cityRepo.Add(defaultCity1);
        //cityRepo.Add(defaultCity2);
        //cityRepo.Add(defaultCity3);
        // db.Cities.SaveCh();

        // --------------- Default Company -------------------
        var defaultCompany1 = new Company()
        {
          Id = Guid.NewGuid(),
          Name = "AutoEs",
          Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque " +
                          "laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto " +
                          "beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut " +
                          "odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. "// +
                                                                                                                           //"Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, " +
                                                                                                                           //"sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat " +
                                                                                                                           //"voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit " +
                                                                                                                           //"laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit " +
                                                                                                                           //"qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum " +
                                                                                                                           //"fugiat quo voluptas nulla pariatur?"
        };

        var defaultCompany2 = new Company()
        {
          Id = Guid.NewGuid(),
          Name = "Vodafone",
          Description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis " +
                          "praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias " +
                          "excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui " +
                          "officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum " +
                          "facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi " +
                          "optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas "// +
                                                                                                                        //"assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut " +
                                                                                                                        //"rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. " +
                                                                                                                        //"Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias " +
                                                                                                                        //"consequatur aut perferendis doloribus asperiores repellat."
        };
        var defaultCompany3 = new Company()
        {
          Id = Guid.NewGuid(),
          Name = "Fora",
          Description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis " +
                          "praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias " +
                          "excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui " +
                          "officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum "// +
                                                                                                                   //"facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi " +
                                                                                                                   //"optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas " +
                                                                                                                   //"assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut " +
                                                                                                                   //"rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. " +
                                                                                                                   //"Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias " +
                                                                                                                   //"consequatur aut perferendis doloribus asperiores repellat."
        };



        defaultCompany1.City = defaultCity1;
        defaultCompany2.City = defaultCity2;
        defaultCompany3.City = defaultCity3;


        db.Companies.Add(defaultCompany1);
        db.Companies.Add(defaultCompany2);
        db.Companies.Add(defaultCompany3);
        db.SaveChanges();

        defaultEmployer1.Company = defaultCompany1;
        defaultEmployer2.Company = defaultCompany2;
        defaultEmployer3.Company = defaultCompany3;

        employer.Employer = defaultEmployer1;
        employer1.Employer = defaultEmployer2;
        employer2.Employer = defaultEmployer3;

        defaultCompany1.Employers.Add(defaultEmployer1);
        defaultCompany2.Employers.Add(defaultEmployer2);
        defaultCompany3.Employers.Add(defaultEmployer3);

        db.SaveChanges();

        // -----------------------------------------------

        List<City> cityForVacancyList = new List<City>() { defaultCity1, defaultCity2, defaultCity3 };

        List<FieldActivity> fieldActivityForVacancyList = new List<FieldActivity>() { };
        fieldActivityForVacancyList.AddRange(defaultActivitiesList);

        List<Employer> employerForVacancyList = db.Employers.ToList();
        new List<Employer>() { defaultEmployer1, defaultEmployer2, defaultEmployer3 };

        var vacancyNames = new List<string>()
                    {
                        "Менеджер по продажам ",
                        "Ассистент керівника ",
                        "PR-менеджер ",
                        "Торговельний представник",
                        "Специаліст бюро логистики ",
                        "Team Lead",
                        "Керівник відділу рекрутинга ",
                        "Графичний дизайнер",
                        "Іллюстратор",
                        "Мультиплікатор",
                        "HR",
                        "Бухгалтер",
                        "Sourcer",
                        "Рекрутер",
                        "Менеджер по продажам",
                        "Секретарь",
                        "Журналіст",
                        "Фотограф",
                        "Інженер",
                        "Інженер-технолог",
                        "Штурман",
                        "Бізнес-тренер",
                    };

        // --------------------------------------  EmploymentDef ------------------------------------------


        EmploymentType employmentDef1 = new EmploymentType()
        {
          Id = EmploymentDefault.Fulltime,
          Name = "Повний робочий день"

        };
        EmploymentType employmentDef2 = new EmploymentType()
        {
          Id = EmploymentDefault.Parttime,
          Name = "Не повний робочий день"

        };

        db.Employments.Add(employmentDef1);
        db.Employments.Add(employmentDef2);
        //repoEmployment.Save();

        Random rndEmp = new Random();


        // -----------------------------------------  Default Experience of work  ------------------------------------------------

        ExperienceOfWork expOfWork1 = new ExperienceOfWork()
        {
          Id = ExperienceOfWorkDefault.TwoYears,
          NameField = "2 роки"
        };
        ExperienceOfWork expOfWork2 = new ExperienceOfWork()
        {
          Id = ExperienceOfWorkDefault.ThreeYears,
          NameField = "3 роки"
        };
        ExperienceOfWork expOfWork3 = new ExperienceOfWork()
        {
          Id = ExperienceOfWorkDefault.FiveYears,
          NameField = "5 рокiв"
        };

        db.ExperienceOfWorks.Add(expOfWork1);
        db.ExperienceOfWorks.Add(expOfWork2);
        db.ExperienceOfWorks.Add(expOfWork3);
        db.SaveChanges();
        Random rand = new Random();


        //Random random = new Random();
        var experiencesOfWork = db.ExperienceOfWorks.ToList();
        int countExOfWork = rand.Next(experiencesOfWork.Count - 1);


        var employmentList = db.Employments.Include(e => e.Vacancies)
          .Include(e => e.Experiences).ToList();

        foreach (var vacancyName in vacancyNames)
        {


          int empCount = rand.Next(employmentList.Count);

          int r = rand.Next(cityForVacancyList.Count);
          int f = rand.Next(fieldActivityForVacancyList.Count);
          int e = rand.Next(employerForVacancyList.Count);
          int wage = rand.Next(5000, 50000);

          db.Vacancies.Add(new Vacancy()
          {
            Id = Guid.NewGuid(),
            Name = vacancyName,
            City = cityForVacancyList[r],
            FieldActivity = fieldActivityForVacancyList[f],
            Employer = employerForVacancyList[e],
            Wage = wage,
            DateCreate = DateTime.Now,
            IsActive = true,
            TypeEmployment = employmentDef1,
            ExperienceOfWork = experiencesOfWork[countExOfWork],
          

            Description = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis " +
                            "praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias " +
                            "excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui " +
                            "officia deserunt mollitia animi, id est laborum et dolorum fuga. ",

            Requirement = " Активна життєва позиція;" +
                                 " Грамотна мова," +
                                 " Хороші комунікативні навички; " +
                                 " Бажання працювати і багато заробляти; ",
            ForeignLanguages = "English - на рівні Intermediate і вище, " +
                                  "вільне володіння польскою мовою",
            AdditionalRequirements = "Посвідчення водія категорії В, стаж 5 років.",
            Responsibilities = "Do your job well."



          });
        }

        db.SaveChanges();

        for (int i = 0; i < 10; i++)
        {


          ApplicationUser randomAccountEmployer = new ApplicationUser()
          {
            Email = $"employer_{i}@sw.ua",
            UserName = $"employer_{i}@sw.ua"
          };
          // var randEmplRes = this.userManager.CreateAsync(randomAccountEmployer, "123456").Result;
          var randEmplRes = this.userManager.CreateAsync(randomAccountEmployer, "Q123_q").Result;
          if (randEmplRes.Succeeded)
          {
            var roleEmplRes = this.userManager.AddToRoleAsync(randomAccountEmployer, "Employer").Result
                .Succeeded;
          }

          Employer randomEmployer = new Employer()
          {
            Id = Guid.NewGuid(),
            AccountUser = randomAccountEmployer
          };

          // NEW 
          randomAccountEmployer.Employer = randomEmployer;

        

          var randomCompany = new Company()
          {
            Id = Guid.NewGuid(),
            Name = $"company_{i}",
            Email = randomAccountEmployer.Email,
            Status = true

          };

          randomCompany.City = defaultCity1;
          db.Companies.Add(randomCompany);

          randomEmployer.Company = randomCompany;
          randomCompany.Employers.Add(randomEmployer);


        }
        db.SaveChanges();

        // -----------------------------------------  Default formTraining  ------------------------------------------------

        FormTraining formDef1 = new FormTraining()
        {
          Id = FormTrainingDefault.Daytime,
          Name = "Денна"
        };
        FormTraining formDef2 = new FormTraining()
        {
          Id = FormTrainingDefault.PartTime,
          Name = "Заочна"
        };
        FormTraining formDef3 = new FormTraining()
        {
          Id = FormTrainingDefault.Evening,
          Name = "Вечірня"
        };
        FormTraining formDef4 = new FormTraining()
        {
          Id = FormTrainingDefault.Distance,
          Name = "Дистанційно"
        };


        db.FormTrainings.Add(formDef1);
        db.FormTrainings.Add(formDef2);
        db.FormTrainings.Add(formDef3);
        db.FormTrainings.Add(formDef4);
        db.SaveChanges();

        Random rnd = new Random();
        var formsTraining = db.FormTrainings.Include(f => f.Educations).ToList();
        int countFormTrain = rnd.Next(formsTraining.Count - 1);

        // --------------------------------------  LevelTechnologyPossessionDefault ------------------------------------------



        LevelTechnologyPossession levelTechnologi1 = new LevelTechnologyPossession()
        {
          Id = LevelTechnologyPossessionDefault.Base,
          Name = "Base"
        };
        LevelTechnologyPossession levelTechnologi2 = new LevelTechnologyPossession()
        {
          Id = LevelTechnologyPossessionDefault.Confident,
          Name = "Confident"
        };
        LevelTechnologyPossession levelTechnologi3 = new LevelTechnologyPossession()
        {
          Id = LevelTechnologyPossessionDefault.Expert,
          Name = "Expert"
        };

        db.LevelTechnologyPossessions.Add(levelTechnologi1);
        db.LevelTechnologyPossessions.Add(levelTechnologi2);
        db.LevelTechnologyPossessions.Add(levelTechnologi3);
        db.SaveChanges();


        var levelsTech = db.LevelTechnologyPossessions.Include(l => l.SoftWares).ToList();
        int countLevTech = rnd.Next(levelsTech.Count - 1);

        // -----------------------------------------  Default LevelLanguage  ------------------------------------------------

        LevelLanguage levelLang1 = new LevelLanguage()
        {
          Id = LevelLanguageDefault.Beginner,
          Name = "Beginer"

        };
        LevelLanguage levelLang2 = new LevelLanguage()
        {
          Id = LevelLanguageDefault.PreIntermediate,
          Name = "PreIntermediate"
        };
        LevelLanguage levelLang3 = new LevelLanguage()
        {
          Id = LevelLanguageDefault.Intermediate,
          Name = "Intermediate"

        };
        LevelLanguage levelLang4 = new LevelLanguage()
        {
          Id = LevelLanguageDefault.UpperIntermediate,
          Name = "UpperIntermediate"
        };
        LevelLanguage levelLang5 = new LevelLanguage()
        {
          Id = LevelLanguageDefault.Advanced,
          Name = "Advanced"
        };

        db.LevelLanguages.Add(levelLang1);
        db.LevelLanguages.Add(levelLang2);
        db.LevelLanguages.Add(levelLang3);
        db.LevelLanguages.Add(levelLang4);
        db.LevelLanguages.Add(levelLang5);
        db.SaveChanges();


        var levelsLeng = db.LevelLanguages.Include(l => l.ForeignLanguages).ToList();
        int countLevelLang = rnd.Next(levelsLeng.Count - 1);

        // --------------------------------------  LevelEducation ------------------------------------------



        LevelEducation level1 = new LevelEducation()
        {
          Id = DefaultLevelEducation.Higher,
          Name = "Вища"
        };
        LevelEducation level2 = new LevelEducation()
        {
          Id = DefaultLevelEducation.UnfinishedHigher,
          Name = "Незакінченна вища"
        };
        LevelEducation level3 = new LevelEducation()
        {
          Id = DefaultLevelEducation.Average,
          Name = "Середня"
        };

        db.LevelEducations.Add(level1);
        db.LevelEducations.Add(level2);
        db.LevelEducations.Add(level3);
        db.SaveChanges();


        var listLevelsEduc = db.LevelEducations.ToList();
        int countLevEduc = rnd.Next(listLevelsEduc.Count - 1);

        //// -----------------------------------------  Default resume  ------------------------------------------------

  

        //List<City> cityForResumeList = new List<City>() { defaultCity1, defaultCity2, defaultCity3 };

        var fieldActivityForResumeList = db.FieldActivities.ToList();
        //List<FieldActivity> fieldActivityForResumeList = new List<FieldActivity>() { };
        //fieldActivityForResumeList.AddRange(defaultActivitiesList);


        var resumeNames = new List<string>()
        {
            "Менеджер по продажам послуг",
            "Ассистент керівника ",
            "PR-менеджер ",
            "Торговельний представник",
            "Ведущий спеціаліст бюро логістики ",
            "Team Lead",
            "Руководитель отдела рекрутинга ",
            "Графічний дизайнер",
            "Мультиплікатор",
            "HR",
            "Бухгалтер",
        };

        // --------------------------------------  ChildrenDef ------------------------------------------


        Children children1 = new Children()
        {
          Id = ChildrenDefault.Yes,
          Name = "Немає"

        };
        Children children2 = new Children()
        {
          Id = ChildrenDefault.No,
          Name = "Є"
        };



        db.Childrens.Add(children1);
        db.Childrens.Add(children2);
        db.SaveChanges();


        int countChild = rand.Next(db.Childrens.ToList().Count - 1);


        // --------------------------------------  familyStatusDef ------------------------------------------




        FamilyStatus familyStatusDef1 = new FamilyStatus()
        {
          Id = FamelyStatusDefault.Married,
          Name = "Одружений"

        };
        FamilyStatus familyStatusDef2 = new FamilyStatus()
        {
          Id = FamelyStatusDefault.Single,
          Name = "Холостий"
        };


        db.FamilyStatuses.Add(familyStatusDef1);
        db.FamilyStatuses.Add(familyStatusDef2);
        db.SaveChanges();

        var allFamilyStatus = db.FamilyStatuses.Include(f => f.Candidates).ToList();
        int countFamilySt = rnd.Next(allFamilyStatus.Count - 1);

        //// ------------------------------------------------------------
        List<string> regions = new List<string>() { "Дніпропетровська", "Харківська", "Київська" };
        List<string> streets = new List<string>() { "Грушевського", "Гмирі", "Шевченка", "Свободи" };
        List<string> listNumApartament = new List<string>() { "56", "45B", "12A", "78", "52A", "13", "18", "58" };
        List<string> listPhone =
            new List<string>() { "+3809876543", "+3809876111", "+3809822223", "+3809833323" };


        // ----------------------------------- SavedVacancy --------------------------------

       
        var cityForResumeList = db.Cities.ToList();

        try
        {
          for (int i = 0; i < 10; i++)
          {
            int rndRegion = rand.Next(regions.Count - 1);
            int rndStreet = rand.Next(streets.Count - 1);
            int rndApartamentNum = rand.Next(listNumApartament.Count - 1);
            int rndPhone = rnd.Next(listPhone.Count - 1);

            int rndCity = rand.Next(cityForResumeList.Count - 1);
            // int rndS = rand.Next(sexList.Count);

            ApplicationUser randomAccountCandidat = new ApplicationUser()
            {

              Email = $"candidate_{i}@sw.ua",
              UserName = $"candidate_{i}@sw.ua"
            };

            var randEmplRes = this.userManager.CreateAsync(randomAccountCandidat, "Q123_q").Result;
            if (randEmplRes.Succeeded)
            {
              var roleCandidateRes = this.userManager
                  .AddToRoleAsync(randomAccountCandidat, "Candidate").Result.Succeeded;
            }

            int rndAge = rand.Next(20, 40);

            DateTime date = DateTime.Now.AddYears(-rndAge);



            Candidate randomCandidate = new Candidate()
            {
              AccountUser = randomAccountCandidat,
              Id = Guid.NewGuid(),
              Name = $"Name_{i}",
              City = cityForResumeList[rndCity],//*/ ,
              Birthday = date,
              FamilyStatus = allFamilyStatus[countFamilySt],
              Children = db.Childrens.ToList()[countChild],

              Country = "Україна",
              Region = "Київська",
              Street = streets[rndStreet],
              ApartmentNumber = "10A",
              
              PhoneNumber = "+3809876543" //listPhone[rndPhone]
            };
             // NEW 
            randomAccountCandidat.Candidate = randomCandidate;


            db.Candidates.Add(randomCandidate);





          }
          db.SaveChanges();


        }
        catch (Exception e)
        {
          var t = e;
        }

        var allCand = db.Candidates;

        // All Vacancies
        var allVacancy = db.Vacancies.ToList();


        // // ----------------------------------- Response Type  to resume --------------------------------



        ResponseTypeToResume resp1 = new ResponseTypeToResume()
        {
          Id = ResponseTypeIdToResumeDefault.Received,
          Name = "Доставлено"
        };
        ResponseTypeToResume resp2 = new ResponseTypeToResume()
        {
          Id = ResponseTypeIdToResumeDefault.Viewed,
          Name = "Переглянуто"
        };
        ResponseTypeToResume resp3 = new ResponseTypeToResume()
        {
          Id = ResponseTypeIdToResumeDefault.Denied,
          Name = "Відмовлено"
        };

        db.ResponsesTypeToResume.Add(resp1);
        db.ResponsesTypeToResume.Add(resp2);
        db.ResponsesTypeToResume.Add(resp3);


        db.SaveChanges();


        // ----------------------------------- Response Type to Vacancy --------------------------------



        ResponseType respType1 = new ResponseType()
        {
          Id = ResponseTypeIdDefault.Favorite,
        };
        ResponseType respType2 = new ResponseType()
        {
          Id = ResponseTypeIdDefault.Denide
        };

        db.ResponsesType.Add(respType1);
        db.ResponsesType.Add(respType2);


        db.SaveChanges();

        var allTypeResponse = db.ResponsesType.ToList();

        // ---------------------------- candidate --------------------------

        List<Candidate> candidates = allCand.ToList();

        int countField = fieldActivityForResumeList.Count - 1;
        int countCandidate = candidates.Count;

        var allCompany = db.Companies.ToList();

        //
        List<string> positions = new List<string>() { "Middle C# development", "Junior C# development", "Middle C# development" };
        List<string> softWares = new List<string>() { "Adobe Photoshop", "HTML & CSS", "Java script", "C#", "C++" };


        // ----------------------------------- RecomendVacancy --------------------------------

        var empl = db.Employments.FirstOrDefault();
        for (int i = 0; i < 7; i++)
        {
          foreach (var resumeName in resumeNames)
          {
            Random rIsAnonim = new Random();

            try
            {



              int f = rand.Next(0, countField);
              int wage = rand.Next(5000, 50000);
              //int fieldResumeListRandomIndex = rand.Next(0, fieldActivityForResumeList.Count - 1);
              //int fieldResumeListRandomIndex2 = rand.Next(0, fieldActivityForResumeList.Count - 1);
              //int fieldResumeListRandomIndex3 = rand.Next(0, fieldActivityForResumeList.Count - 1);

              Dictionary<int, int> fieldsResumeIndex = new Dictionary<int, int>();

              for (int x = 0; x < 3; x++)
              {
                int val = rand.Next(fieldActivityForResumeList.Count - 1);

                while (fieldsResumeIndex.ContainsValue(val))
                {
                  val = rand.Next(fieldActivityForResumeList.Count - 1);
                }

                fieldsResumeIndex.Add(x, val);
              }

              int c = rand.Next(0, countCandidate - 1);

              var dataFrom = new DateTime(1999, 9, 3);
              var dataTo = new DateTime(2004, 5, 29);

              var dataFromEx = new DateTime(2004, 6, 1);
              var dataToEx = new DateTime(2008, 5, 29);
              var newResume = new Resume()
              {

                Id = Guid.NewGuid(),
                Name = resumeName,
                Candidate = candidates[c],
                DateCreate = DateTime.Now,
                DateChange = DateTime.Now,
                Salary = wage,
                // Employment = employmentDef1,
                IsActiveResume = true,
                Experiences = new List<Experience>() { new Experience()
                                      {
                                          Id = Guid.NewGuid(),
                                          NameOrganization = "TOB Логістика Плюс",
                                          DateWorkFrom = dataFromEx,
                                          DateWorkTo = dataToEx,
                                          IsWorkingNow = false,
                                          Employment = empl,
                                          //ExperienceOfWork = experiencesOfWork[rnd.Next(experiencesOfWork.Count - 1)],
                                          Position = resumeNames[rnd.Next(resumeNames.Count - 1)],
                                          Task = "Create new project, startap?",
                                          Progres = "Got a boost..."
                                      } },

                Educations = new List<Education>() { new Education()
                                      {
                                          Id = Guid.NewGuid(),
                                          LevelEducation = listLevelsEduc[countLevEduc],
                                          City = cityForResumeList[cityForResumeList.Count -1].Name,
                                          NameInstitution = "Київський політехнічний інститут ім. Сікорського",
                                          Specialization = "Системне програмування",
                                          FormTraining = formsTraining[countFormTrain],
                                          DateWorkFrom = dataFrom,
                                          DateWorkTo =  dataTo
                                      } },
                ForeignLanguages = new List<ForeignLanguage>()
                                      {
                                          new ForeignLanguage()
                                          {
                                              Id = Guid.NewGuid(),
                                              Name = "Английский",
                                              LevelLanguage = levelsLeng[countLevelLang]

                                          },

                                          new ForeignLanguage()
                                          {

                                              Id = Guid.NewGuid(),
                                              Name = "Російський",
                                              LevelLanguage = levelsLeng[countLevelLang]
                                          }
                                      },
                SoftWares = new List<SoftWare>()
                                      {
                                          new SoftWare()
                                          {
                                              Id = Guid.NewGuid(),
                                              Name =  softWares[rnd.Next(softWares.Count - 1)],
                                              LevelTechnologyPossession = levelsTech[countLevTech],

                                          },
                                          new SoftWare()
                                          {
                                              Id = Guid.NewGuid(),
                                              Name =  softWares[rnd.Next(softWares.Count - 1)],
                                              LevelTechnologyPossession = levelsTech[countLevTech],

                                          }
                                      },
                Awards = new List<Award>()
                                      {
                                          new Award()
                                          {
                                              Id= Guid.NewGuid(),
                                              Name = "Cisco - 3 місце ",
                                              Date = DateTime.Now

                                          }
                                      },



              };

              Random rndField = new Random();
              int field = rnd.Next(fieldActivityForResumeList.Count);


              newResume.FieldActivities.Add(new FieldActivityResume()
              {
                Id = Guid.NewGuid(),
                //FieldActivity = activity1,
                FieldActivity = fieldActivityForResumeList[fieldsResumeIndex[0]],
                Resume = newResume,

              });
              newResume.FieldActivities.Add(new FieldActivityResume()
              {
                Id = Guid.NewGuid(),
                FieldActivity = fieldActivityForResumeList[fieldsResumeIndex[1]],
                Resume = newResume,
              });
              newResume.FieldActivities.Add(new FieldActivityResume()
              {
                Id = Guid.NewGuid(),
                FieldActivity = fieldActivityForResumeList[fieldsResumeIndex[2]],
                Resume = newResume,
              });

              //bool randIsUseCompanyContacts = rIsAnonim.Next(0, 2) > 1;

              //if (randIsUseCompanyContacts)
              //{
              //  newResume.IsAnonymousResume = true;
              //  newResume.IsHideContact = false;
              //}



              db.Resumes.Add(newResume);
              db.SaveChanges();



              //// -------------------------------------------------- Resp to Resume  -------------------------
              Random rndResp = new Random();
              var allTypeResponseToResumes = db.ResponsesTypeToResume.ToList();

              ResponseToResume respToResum = new ResponseToResume()
              {
                Id = Guid.NewGuid(),
                Resume = newResume,
                Vacancy = allVacancy[rndResp.Next(allVacancy.Count - 1)],
                DataResponse = DateTime.Now,
                ResponseTypeToResume = allTypeResponseToResumes[2]
              };
              db.ResponsesToResume.Add(respToResum);



              //// -------------------------------------------------- Resp -------------------------
              //var repoResonse = new ResponseRepository(this.dbContext);
              int v = rnd.Next(allVacancy.Count - 1);
              int t = rnd.Next(allTypeResponse.Count - 1);

              ResponseToVacancy newResponse = new ResponseToVacancy()
              {
                Id = Guid.NewGuid(),
                Resume = newResume,
                Vacancy = allVacancy[v],
                ResponseType = allTypeResponse[t],
                DataResponse = DateTime.Now

              };



              db.ResponsesToVacancy.Add(newResponse);
              //repoResonse.Save();

              // -------------------------------------------------- View -------------------------
              //  var repoViewRes = new ViewPageRepository(this.dbContext);
              int countVac = rnd.Next(allVacancy.Count - 1);

              int countEmployer = rnd.Next(employerForVacancyList.Count - 1);

              ViewPage viewResume = new ViewPage()
              {
                Id = Guid.NewGuid(),
                Resume = newResume,
                DataView = DateTime.Now,
                Employer = allVacancy[countVac].Employer
              };
              db.ViewsPages.Add(viewResume);
              //repoViewResume.Save();


              // ----------------------------------- ShoweResume --------------------------------

              // var repoShowResum = new ShowResumeRepository(this.dbContext);

              ShowResume show1 = new ShowResume()
              {
                Id = Guid.NewGuid(),
                Resume = newResume
              };

              db.ShowsResume.Add(show1);

              //repoShowResum.Save();



              //// ----------------------------------- SavedResume --------------------------------

              //var repoSaveResum = new SavedResumeRepository(this.dbContext);
              int countComp = rnd.Next(allCompany.Count - 1);

              SavedResume save1 = new SavedResume()
              {
                Id = Guid.NewGuid(),
                Resume = newResume,
                Employer = allVacancy[countVac].Employer,
                DateSaved = DateTime.Now
              };

              db.SavedResumes.Add(save1);

              //repoShowResum.Save();

              // var allSaved = repoSaveResum.GetAll().ToList();



              //// ----------------------------------- RecomendVacancy --------------------------------
              var allCandidate = db.Candidates.ToList();
              int countCand = rand.Next(allCandidate.Count - 1);

              RecommendedVacancy rec1 = new RecommendedVacancy()
              {
                Id = Guid.NewGuid(),
                Vacancy = allVacancy[countVac],
                Candidate = allCandidate[countCand],
                DateSaved = DateTime.Now

              };

              db.RecommendedVacancies.Add(rec1);

              // -------------------------------- Saved Vacancy -------------------------------
              SavedVacancy savVac1 = new SavedVacancy()
              {
                Id = Guid.NewGuid(),
                Candidate = allCandidate[countCand],
                Vacancy = allVacancy[countVac],
                DateSaved = DateTime.Now

              };

              db.SavedVacancies.Add(savVac1);

              db.SaveChanges();

              ////repoRecVac.Save();

              ////candidateRepo.Save();

            }
            catch (Exception e) { }

          }

          //try
          //{

          //}
          //catch (Exception e)
          //{
          //  var text = e;
          //}



          //--------------------------------------------------Patern------------------------ -
         
          var listEducation = db.Educations.ToList();

          var allResume = db.Resumes.ToList();

          try
          {

            PaternSearchResume patSearch1 = new PaternSearchResume()
            {
              Id = Guid.NewGuid(),
              Request = allResume[0].Name,
              City = allResume[0].Candidate.CityId.Value, //newResume.Candidate.City.Id,
              FieldActivity = allResume[0].FieldActivities.FirstOrDefault().Id, //fieldActivityForResumeList[rnd.Next(fieldActivityForResumeList.Count - 1)].Id,
              Education = allResume[0].Educations.FirstOrDefault().Id,
              Salary = allResume[0].Salary,
              ExperienceOfWork = experiencesOfWork[countExOfWork].Id,
              Employment = allResume[0].Experiences.FirstOrDefault().Employment.Id,

              IsInName = true,
              IsLiteTestPassed = true
            };

            PaternSearchResume patSearch2 = new PaternSearchResume()
            {
              Id = Guid.NewGuid(),
              Request = allResume[0].Name,
              City = allResume[2].Candidate.CityId.Value, //newResume.Candidate.City.Id,

              FieldActivity = allResume[2].FieldActivities.FirstOrDefault().Id, //fieldActivityForResumeList[rand.Next(fieldActivityForResumeList.Count - 1)].Id,
              Education = allResume[2].Educations.FirstOrDefault().Id,
              Salary = allResume[2].Salary,
              ExperienceOfWork = experiencesOfWork[countExOfWork].Id,
              Employment = allResume[2].Experiences.FirstOrDefault().Employment.Id,

              IsInName = true,
              IsLiteTestPassed = true
            };
            PaternSearchResume patSearch3 = new PaternSearchResume()
            {
              Id = Guid.NewGuid(),
              Request = allResume[5].Name,
              City = allResume[5].Candidate.CityId.Value, //newResume.Candidate.City.Id,

              FieldActivity = allResume[5].FieldActivities.FirstOrDefault().Id, //fieldActivityForResumeList[rand.Next(fieldActivityForResumeList.Count - 1)].Id,
              Education = allResume[5].Educations.FirstOrDefault().Id,
              Salary = allResume[5].Salary,
              ExperienceOfWork = experiencesOfWork[countExOfWork].Id,
              Employment = allResume[5].Experiences.FirstOrDefault().Employment.Id,

              IsInName = true,
              IsLiteTestPassed = true
            };

            PaternSearchResume patSearch4 = new PaternSearchResume()
            {
              Id = Guid.NewGuid(),

              City = cityForResumeList[rand.Next(cityForResumeList.Count - 1)].Id,


            };
            PaternSearchResume patSearch5 = new PaternSearchResume()
            {
              Id = Guid.NewGuid(),
              Request = "T",
              City = cityForResumeList[rand.Next(cityForResumeList.Count - 1)].Id,


            };



            db.PaternSearchResumes.Add(patSearch1);
            db.PaternSearchResumes.Add(patSearch2);
            db.PaternSearchResumes.Add(patSearch3);
            db.PaternSearchResumes.Add(patSearch4);
            db.PaternSearchResumes.Add(patSearch5);
            db.SaveChanges();

          }
          catch (Exception e)
          {
            var t = e;
          }

          //-------------------------------------------------- Patern Vacancy ------------------------ -

          try {
            PaternSearchVacancy patVacancy1 = new PaternSearchVacancy()
            {
              Id = Guid.NewGuid(),
              Request = allVacancy[2].Name,
              City = allVacancy[2].City.Id,
              FieldActivity = allVacancy[2].FieldActivityId,
              Salary = allVacancy[2].Wage,
              Employment = allVacancy[2].TypeEmployment.Id,
              ExperienceOfWork = allVacancy[2].ExperienceOfWork.Id
            };
            PaternSearchVacancy patVacancy2 = new PaternSearchVacancy()
            {
              Id = Guid.NewGuid(),

              City = allVacancy[3].City.Id

            };
            PaternSearchVacancy patVacancy3 = new PaternSearchVacancy()
            {
              Id = Guid.NewGuid(),
              Request = allVacancy[4].Name,
              City = allVacancy[4].City.Id,
              FieldActivity = allVacancy[4].FieldActivityId,
              Salary = allVacancy[4].Wage,
              Employment = allVacancy[4].TypeEmployment.Id,
              ExperienceOfWork = allVacancy[4].ExperienceOfWork.Id
            };
            PaternSearchVacancy patVacancy4 = new PaternSearchVacancy()
            {
              Id = Guid.NewGuid(),
              Request = "S",
              City = allVacancy[1].City.Id,

            };

            db.PaternSearchVacancies.Add(patVacancy1);
            db.PaternSearchVacancies.Add(patVacancy2);
            db.PaternSearchVacancies.Add(patVacancy3);
            db.PaternSearchVacancies.Add(patVacancy4);
            db.SaveChanges();

          }
          catch (Exception e)
          {
            var t = e;
          }




        }




      }
      return Content("");
    }

  }
}


