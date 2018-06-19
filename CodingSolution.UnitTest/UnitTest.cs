using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodingSolution.Data.Models;
using CodingSolution.Data.Unit;
using CodingSolution.Data.Domen;
using CodingSolution.Data.Interfaces;
using CodingSolution.Data.Services;
using System.Linq;
using System.Collections.Generic;

namespace CodingSolution.UnitTest
{
    [TestClass]
    public class UnitTest
    {
        ApplicationDbContext context;
        UnitOfWork unit;
        ISector sectorService;
        ICandidate candService;
        IApplicants applicantService;
      

        [TestMethod]
        public void TestMethodUnitOfWork()
        {
            this.context = new ApplicationDbContext();
            this.unit = new UnitOfWork(this.context);
            this.sectorService = new SectorService(this.unit);
            this.candService = new CandidatesService(this.unit);
            this.applicantService = new ApplicantsService(this.unit);
        }


        [TestMethod]
        public void TestMethodGetSectors()
        {
            this.context = new ApplicationDbContext();
            this.unit = new UnitOfWork(this.context);
            this.sectorService = new SectorService(this.unit);
            var sectors = this.sectorService.FindBy(x => !x.ParentId.HasValue);
            Assert.AreEqual(true, sectors!=null);
        }

        [TestMethod]
        public void TestMethodApplicants()
        {
            this.context = new ApplicationDbContext();
            this.unit = new UnitOfWork(this.context);
            this.sectorService = new SectorService(this.unit);
            this.applicantService = new ApplicantsService(this.unit);
            var list = new List<Applicants>();
            list.Add(new Applicants { CandidateId = 14, SectorId = 27 });
            this.applicantService.Add(list);

           
        }

       

    }
}
