using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PrescriptionManager : IPrescriptionService
    {
        private IPrescriptionDal _prescriptionDal;
        private IPrescriptionDetailDal _prescriptionDetailDal;

        public PrescriptionManager(IPrescriptionDal prescriptionDal, IPrescriptionDetailDal prescriptionDetailDal)
        {
            _prescriptionDal = prescriptionDal;
            _prescriptionDetailDal = prescriptionDetailDal;
        }

        public IResult CreatePrescription(PrescriptionForCreateDto prescriptionForCreateDto)
        {
            Prescription prescription = MapToPrescription(prescriptionForCreateDto);
            FillThePrescription(prescriptionForCreateDto, prescription);
            return new SuccessResult(Message.Success);
        }

        private void FillThePrescription(PrescriptionForCreateDto prescriptionForCreateDto, Prescription prescription)
        {
            foreach (var drug in prescriptionForCreateDto.Drugs)
            {
                _prescriptionDetailDal.Add(new PrescriptionDetail
                {
                    PrescriptionId = prescription.Id,
                    DrugId = drug.DrugId,
                    CountOfDose = drug.CountOfDose,
                    CountOfUsesPerDay = drug.CountOfUsesPerDay
                });
            }
        }

        private Prescription MapToPrescription(PrescriptionForCreateDto prescriptionForCreateDto)
        {
            return new Prescription
            {
                Date = DateTime.Now,
                ExpiryDate= DateTime.Now.AddDays(7),
                DoctorRegistrationNumber = prescriptionForCreateDto.DoctorRegistrationNumber,
                HealtInstitutionNumber = prescriptionForCreateDto.HealtInstitutionNumber,
                PatientIdCardNumber = prescriptionForCreateDto.PatientIdCardNumber
            };
        }
    }
}
