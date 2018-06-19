using CodingSolution.Data.Domen;
using CodingSolution.Data.Interfaces;
using CodingSolution.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSolution.Data.Services
{
    public class ApplicantsService : IApplicants
    {
        private readonly IUnitOfWork unit;
        string errorMessage = string.Empty;
        public ApplicantsService(IUnitOfWork unit) => this.unit = unit;

        public void Add(List<Applicants> applicants)
        {

            try
            {
                if (applicants != null)
                {
                    foreach (var applicant in applicants)
                    {
                        int candid = applicant.CandidateId;
                        int sectorid = applicant.SectorId;
                        var validateApplicant = this.unit.Repository<Applicants>().FindBy(x => x.CandidateId == candid && x.SectorId == sectorid);
                        if (!validateApplicant.Any())
                        {
                            applicant.CreateDate = DateTime.Now;
                            var newApplicant = this.unit.Repository<Applicants>().Insert(applicant);
                            this.unit.Save();
                        }

                    }
                }

            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                //add error to log

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                //Add error to log
            }


        }

        public void Apply(int candid, RegisterForm registerForm)
        {

            var applicants = new List<Applicants>();
            var listSelector = registerForm.Sector.Where(c => c > 0).ToList();
            for (int i = 0; i < listSelector.Count; i++)
            {

                applicants.Add(new Applicants { CandidateId = candid, SectorId = listSelector[i] });
            }

            Add(applicants);



        }

        public bool Delete(Applicants applicant)
        {
            bool res = false;
            try
            {
                this.unit.Repository<Applicants>().Delete(applicant);
                this.unit.Save();
                res = true;
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                //add error to log
                res = false;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                //Add error to log
            }
            return res;
        }
    }
}
