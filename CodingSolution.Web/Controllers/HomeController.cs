using CodingSolution.Data.Domen;
using CodingSolution.Data.Interfaces;
using CodingSolution.Data.Models;
using CodingSolution.Data.Services;
using CodingSolution.Data.Unit;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingSolution.Web.Controllers
{
    public class HomeController : Controller
    {
        string errorMessage = string.Empty;
        private readonly ApplicationDbContext db;
        private readonly IUnitOfWork unitofWork;
        private readonly ISector selectorService;
        private readonly ICandidate candidateService;
        private readonly IApplicants applicantService;
        /// <summary>
        /// Applied Ninject Ioc container
        /// </summary>
        /// <param name="_db"></param>
        /// <param name="_unitofWork"></param>
        /// <param name="_selectorService"></param>
        /// <param name="_candidateService"></param>
        /// <param name="_applicantService"></param>
        public HomeController(
             ApplicationDbContext _db,
             IUnitOfWork _unitofWork,
             ISector _selectorService,
             ICandidate _candidateService,
             IApplicants _applicantService
             )
        {

            this.db = _db;
            this.unitofWork = _unitofWork;
            this.selectorService = _selectorService;
            this.candidateService = _candidateService;
            this.applicantService = _applicantService;
        }

      
        public ActionResult Index()
        {

            var model = this.selectorService.FindBy(x => !x.ParentId.HasValue).ToList();
            return View(model);
        }

        /// <summary>
        /// This method in order to   edit users data during the session according 3.4 step in task.
        /// We also can apply Login module
        /// </summary>
        /// <param name="regForm"></param>
        /// <returns></returns>
        private bool AddCandidateToSession(RegisterForm regForm)
        {
            var res = false;
            try
            {
                if (Session["CandId"] == null)
                {
                    var registeredForm = this.candidateService.Insert(new Candidates { Name = regForm.Name, AgreementStatus = regForm.Agree });
                    if (registeredForm != null)
                    {
                        Session["CandId"] = registeredForm.Id;
                        res = true;
                    }
                }
                else
                {
                    var candid = Convert.ToInt32(Session["CandId"]);
                    var registeredForm = this.candidateService.Update(new Candidates { Id = candid, Name = regForm.Name, AgreementStatus = regForm.Agree });
                    if (registeredForm)
                        res = true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                //add errorMessage to log 
            }


            return res;

        }



        /// <summary>
        /// This method in order to get user's all chosen sector during
        /// the session
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetUsersSectorsList()
        {

            return Json(UsersSectorsList(), JsonRequestBehavior.AllowGet);

        }
        
        public RegisterFormResult UsersSectorsList()
        {

            if (Session["CandId"] != null)
            {
                var candid = Convert.ToInt32(Session["CandId"]);
                var sectorsList = this.candidateService.GetSectorsById(candid);
                var name = this.candidateService.Get(candid).Name;

                return new RegisterFormResult { StatusCode = 0, Message = "You are registered successfly!", Name = name, Sectors = sectorsList };
            }

            return new RegisterFormResult { StatusCode = 1, Message = "Session has expired!" };
        }
        
        [HttpPost]
        public JsonResult Delete(Applicants Applicants)
        {

            this.applicantService.Delete(Applicants);
            return Json(UsersSectorsList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegisterForm(RegisterForm RegisterForm)
        {
            var validateSession = AddCandidateToSession(RegisterForm);
            if (validateSession)
            {
                var candid = Convert.ToInt32(Session["CandId"]);
                this.applicantService.Apply(candid, RegisterForm);
            }
            return Json(UsersSectorsList(), JsonRequestBehavior.AllowGet);
        }

    }
}