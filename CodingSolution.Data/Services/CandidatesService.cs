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
    public class CandidatesService : ICandidate
    {
        private readonly IUnitOfWork unit;
        string errorMessage = string.Empty;
        public CandidatesService(IUnitOfWork unit) => this.unit = unit;

        public Candidates Get(int candId)
        {
            return this.unit.Repository<Candidates>().GetById(candId);
        }

        public List<CandidatesSectors> GetSectorsById(int candId)
        {

            return (from a in this.unit.Repository<Applicants>().Table
                    join c in this.unit.Repository<Candidates>().Table on a.CandidateId equals c.Id
                    join s in this.unit.Repository<Sectors>().Table on a.SectorId equals s.Id
                    where a.CandidateId == candId
                    select new CandidatesSectors
                    {

                        CandId = a.CandidateId,
                        SectorId = a.SectorId,
                        SectorName = s.Name


                    }).ToList<CandidatesSectors>();
        }

        public Candidates Insert(Candidates candidates)
        {

            try
            {
                candidates.CreateDate = DateTime.Now;
                var candidate = this.unit.Repository<Candidates>().Insert(candidates);
                this.unit.Save();
                return candidate;
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
                return null;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                //add error to log
                return null;
            }

        }

        public bool Update(Candidates candidates)
        {
            var res = true;
            try
            {
                candidates.CreateDate = DateTime.Now;
                this.unit.Repository<Candidates>().Update(candidates);
                this.unit.Save();

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
                //add error to log
                res = false;
            }
            return res;
        }
    }
}
